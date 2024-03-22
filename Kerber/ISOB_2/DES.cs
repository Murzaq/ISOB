﻿using System.Collections;
using System.Text;

namespace ISOB_2
{
    public class DES
    {
        private static readonly byte Rounds = 16;

        // таблица для начальной перестановки
        static readonly byte[] IP = new byte[]
        {
            58, 50, 42, 34, 26, 18, 10, 2, 60, 52, 44, 36, 28, 20, 12, 4,
            62, 54, 46, 38, 30, 22, 14, 6, 64, 56, 48, 40, 32, 24, 16, 8,
            57, 49, 41, 33, 25, 17, 9,  1,  59, 51, 43, 35, 27, 19, 11, 3,
            61, 53, 45, 37, 29, 21, 13, 5,  63, 55, 47, 39, 31, 23, 15, 7
        };

        // таблица для обратной перестановки
        static readonly byte[] IP_reverse = new byte[]
        {
            40, 8, 48, 16, 56, 24, 64, 32, 39, 7, 47, 15, 55, 23, 63, 31,
            38, 6, 46, 14, 54, 22, 62, 30, 37, 5, 45, 13, 53, 21, 61, 29,
            36, 4, 44, 12, 52, 20, 60, 28, 35, 3, 43, 11, 51, 19, 59, 27,
            34, 2, 42, 10, 50, 18, 58, 26, 33, 1, 41, 9, 49, 17, 57, 25
        };

        // таблица для расширения 32-битного входа до 48 бит для каждого раунда
        static readonly byte[] E = new byte[]
        {
            32, 1, 2, 3, 4, 5,
            4, 5, 6, 7, 8, 9,
            8, 9, 10, 11, 12, 13,
            12, 13, 14, 15, 16, 17,
            16, 17, 18, 19, 20, 21,
            20, 21, 22, 23, 24, 25,
            24, 25, 26, 27, 28, 29,
            28, 29, 30, 31, 32, 1
        };

        // S-box таблица замен, используемых в функции замены
        static readonly byte[,] S = new byte[,]
        {
            {
                14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7,
                0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8,
                4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0,
                15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13
            },
            {
                15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10,
                3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5,
                0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15,
                13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9
            },
            {
                10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8,
                13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1,
                13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7,
                1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12
            },
            {
                7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15,
                13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9,
                10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4,
                3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14
            },
            {
                2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9,
                14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6,
                4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14,
                11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3
            },
            {
                12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11,
                10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8,
                9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6,
                4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13
            },
            {
                4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1,
                13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6,
                1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2,
                6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12
            },
            {
                13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7,
                1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2,
                7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8,
                2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11
            }
        };

        // таблица перестановки P-блоками
        static readonly byte[] P = new byte[]
        {
            16, 7, 20, 21, 29, 12, 28, 17,
            1, 15, 23, 26, 5, 18, 31, 10,
            2, 8, 24, 14, 32, 27, 3, 9,
            19, 13, 30, 6, 22, 11, 4, 25
        };

        // таблица перестановки для исходного 64-битного ключа перед его использованием
        static readonly byte[] CD = new byte[]
        {
            57, 49, 41, 33, 25, 17, 9, 1, 58, 50, 42, 34, 26, 18,
            10, 2, 59, 51, 43, 35, 27, 19, 11, 3, 60, 52, 44, 36,
            63, 55, 47, 39, 31, 23, 15, 7, 62, 54, 46, 38, 30, 22,
            14, 6, 61, 53, 45, 37, 29, 21, 13, 5, 28, 20, 12, 4
        };

        // таблица количества бит, на которое необходимо сдвигать биты исходного ключа при генерации подключей для каждого раунда
        static readonly byte[] Shifts = new byte[]
        {
            1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1
        };

        // таблица для перестановки битов исходного 64-битного ключа и формирования 58-битного ключа
        static readonly byte[] Choice_key = new byte[]
        {
            14, 17, 11, 24, 1, 5, 3, 28, 15, 6, 21, 10, 23, 19, 12, 4,
            26, 8, 16, 7, 27, 20, 13, 2, 41, 52, 31, 37, 47, 55, 30, 40,
            51, 45, 33, 48, 44, 49, 39, 56, 34, 53, 46, 42, 50, 36, 29, 32
        };
        
        // циклические сдвиг битов влево на заданное кличество
        private static BitArray LeftShift(BitArray data, int count)
        {
            // храним тут биты, которые будут вытеснены при сдвиге
            BitArray temp = new BitArray(count);

            for (int i = 0; i < count; i++)
            {
                // берем биты с конца исходного массива, так как именно они и будут вытеснены
                temp[i] = data[data.Length - count + i];
            }

            // создаем компию исходного массива после чего сдвигаем ее влево
            BitArray res = ((BitArray)data.Clone()).LeftShift(count);
            for (int i = 0; i < count; i++)
            {
                // возвращаем биты в массив
                res[i] = temp[i];
            }
            return res;
        }

        // эта функция буквально тоже самое, только сдвиг происходит вправо
        private static BitArray RightShift(BitArray data, int count)
        {
            BitArray temp = new BitArray(count);

            for (int i = 0; i < count; i++)
            {
                temp[i] = data[i];
            }
            BitArray res = ((BitArray)data.Clone()).RightShift(count);
            for (int i = 0; i < count; i++)
            {
                res[data.Length - count + i] = temp[i];
            }
            return res;
        }

        // перестановка битов в соответствии с заданной таблицей перестановки
        private static BitArray Permutation(BitArray data, byte[] map)
        {
            BitArray res = new BitArray(map.Length);

            for (int i = 0; i < map.Length; i++)
            {   
                // берем соответствующие биты из исходного массива
                // так как индексы начинаются с 0, то перед использованием элемента map он уменьшается на 1
                res[i] = data[map[i] - 1];
            }

            return res;
        }

        // делим массив битов на две части
        private static void GetLR(BitArray data, out BitArray Left, out BitArray Right)
        {
            Left = new BitArray(data.Length / 2);
            Right = new BitArray(data.Length / 2);
            for (int i = 0; i < data.Length / 2; i++)
            {
                Left[i] = data[i];
            }
            for (int i = data.Length / 2; i < data.Length; i++)
            {
                Right[i - data.Length / 2] = data[i];
            }
        }

        // преобразование битового массива в массив байтов
        private static byte[] getBytes(BitArray data)
        {
            // создаем массив байтов (/8 чтобы узнать, сколько байтов нужно для хранения определенного количества битов)
            byte[] bytes = new byte[data.Length / 8];
            // копируем содержимое в массив байтов
            data.CopyTo(bytes, 0);
            return bytes;
        }

        // преобразуем битовый массив в байт
        private static byte getByte(BitArray data)
        {
            if (data.Length <= 8)
            {
                // нам нужен только один 
                byte[] bytes = new byte[1];
                data.CopyTo(bytes, 0);
                return bytes[0];
            }
            else return 0;
        }

        // преобразуем в битовый массив
        private static BitArray getBitArray(byte data)
        {
            byte[] bytes = new byte[1] { data };
            return new BitArray(bytes);
        }


        private static void getAB(BitArray R, out byte a, out byte b)
        {
            BitArray A = new BitArray(2);
            BitArray B = new BitArray(4);
            A[0] = R[0];
            A[1] = R[R.Length - 1];
            for (int i = 1; i < R.Length - 1; i++)
            {
                B[i - 1] = R[i];
            }
            // преобразуем в байты
            a = getByte(A);
            b = getByte(B);
        }

        // объединям левую и правую сторону в один массив
        private static BitArray Merge(BitArray L, BitArray R)
        {
            BitArray res = new BitArray(L.Length * 2);

            for (int i = 0; i < L.Length; i++)
            {
                res[i] = L[i];
                res[L.Length + i] = R[i];
            }

            return res;
        }

        // расширение ключа до 64 бит (каждый 8 бит - бит четности)
        private static BitArray ExtendKey(BitArray key)
        {
            BitArray res = new BitArray(64);

            for (int i = 0; i < 8; i++)
            {
                int count = 0;
                for (int j = 0; j < 7; j++)
                {
                    if (key[i * 7 + j])
                        count++;
                    res[i * 8 + j] = key[i * 7 + j];
                }
                res[i * 8 + 7] = count % 2 == 0 ? true : false;
            }

            return res;
        }

        // генерируем след ключ путем циклического сдвига влево каждой части + объединение
        private static BitArray GenereteNextKey(BitArray key, int shift_count)
        {
            GetLR(key, out BitArray L, out BitArray R);
            return Merge(LeftShift(L, shift_count), LeftShift(R, shift_count));
        }
        private static BitArray GeneretePrevKey(BitArray key, int shift_count)
        {
            GetLR(key, out BitArray L, out BitArray R);
            return Merge(RightShift(L, shift_count), RightShift(R, shift_count));
        }

        // преобразуем ключ в битовый массив
        private static BitArray GetFirstKey(byte[] key)
        {
            BitArray byte_key = new BitArray(key);
            return Permutation(ExtendKey(byte_key), CD);
        }

        // функция шифрования
        private static BitArray F(BitArray R, BitArray k)
        {
            // расширяем до 48 бит 32битную последовательность
            BitArray R_extend = Permutation(R, E);
            R_extend = R_extend.Xor(k);
            BitArray B_res = new BitArray(32);
            for (int i = 0; i < 8; i++)
            {
                BitArray B = new BitArray(6);
                for (int j = 0; j < 6; j++)
                {
                    B[j] = R_extend[i * 6 + j];
                }
                // разделяем входно блок данных на а и б
                getAB(B, out byte a, out byte b);
                // выбираем значения из s-блока на основе полученных значений
                byte s = S[i, a * 16 + b];
                BitArray s_bits = getBitArray(s);
                for (int t = 0; t < 4; t++)
                {
                    B_res[i * 4 + t] = s_bits[t];
                }
            }
            // применяем перестановку по таблице Р
            B_res = Permutation(B_res, P);

            return B_res;
        }

        // сдвиг ключа на 1 или 2 взависимости от раунда
        private static BitArray GetLastKey(byte[] key)
        {
            BitArray K = GetFirstKey(key);
            for(int i = 0; i < Rounds; i++)
            {
                K = GenereteNextKey(K, Shifts[i]);
            }
            return K;
        }

        // шифруем данные
        public static byte[] Encrypt(byte[] data, byte[] key)
        {
            // получаем ключ
            BitArray bitKey = GetFirstKey(key);
            byte[] res = new byte[data.Length];
            
            for (int i = 0; i < data.Length; i += 8)
            {
                byte[] block = new byte[8];
                // проходимся по байтам текущего блока
                for (int j = i; j < i + 8; j++)
                {
                    if (j >= data.Length)
                        break;
                    block[j - i] = data[j];
                }
                BitArray bit_block = new BitArray(block);
                // перестановка данных при помощи таблицы IP
                bit_block = Permutation(bit_block, IP);
                GetLR(bit_block, out BitArray L, out BitArray R);
                for (int k = 0; k < Rounds; k++)
                {
                    // генерируем ключ при помощи таблицы сдвига
                    BitArray K = GenereteNextKey(bitKey, Shifts[k]);

                    BitArray temp_R = new BitArray(R);

                    R = L.Xor(F(R, Permutation(K, Choice_key)));
                    L = temp_R;
                    bitKey = K;
                }

                BitArray kek = Merge(L, R);

                // обратная перестановка
                BitArray bit_res = Permutation(kek, IP_reverse);
                // преобразуем массив в массив байтов
                byte[] res_block = getBytes(bit_res);

                for(int j = i; j < i + 8; j++)
                {
                    res[j] = res_block[j - i];
                }
            }
            return res;
        }
        public static byte[] Decrypt(byte[] data, byte[] key)
        {
            BitArray bitKey = GetLastKey(key);
            byte[] res = new byte[data.Length];
            for (int i = 0; i < data.Length; i += 8)
            {
                byte[] block = new byte[8];
                for (int j = i; j < i + 8; j++)
                {
                    block[j - i] = data[j];
                }
                BitArray bit_block = new BitArray(block);
                bit_block = Permutation(bit_block, IP);

                GetLR(bit_block, out BitArray L, out BitArray R);
                BitArray K = bitKey;
                for (int k = 0; k < Rounds; k++)
                {
                    BitArray temp_L = new BitArray(L);

                    L = R.Xor(F(L, Permutation(K, Choice_key)));
                    R = temp_L;
                    K = GeneretePrevKey(bitKey, Shifts[Shifts.Length - 1 - k]);
                    bitKey = K;
                }

                BitArray kek = Merge(L, R);
                BitArray bit_res = Permutation(kek, IP_reverse);
                byte[] res_block = getBytes(bit_res);
                for (int j = i; j < i + 8; j++)
                {
                    res[j] = res_block[j - i];
                }
            }
            return res;
        }
        public static byte[] Encrypt(string data, string key)
        {
            var data_bytes = Encoding.ASCII.GetBytes(data);
            var key_bytes = Encoding.ASCII.GetBytes(key);
            return Encrypt(data_bytes, key_bytes);
        }
        public static byte[] Decrypt(string data, string key)
        {
            var data_bytes = Encoding.ASCII.GetBytes(data);
            var key_bytes = Encoding.ASCII.GetBytes(key);
            return Decrypt(data_bytes, key_bytes);
        }
    }
}
