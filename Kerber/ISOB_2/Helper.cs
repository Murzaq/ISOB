﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;

namespace ISOB_2
{
    public class Helper
    {
        // расширяем длину массива
        public static byte[] ExtendData(byte[] data)
        {
            int diff = 8 - (data.Length % 8);
            byte[] res = new byte[data.Length + diff];
            data.CopyTo(res, 0);
            return res;
        }

        // удаление лишних нулевых байт
        public static byte[] RecoverData(List<byte> data)
        {
            int i = data.Count - 1;
            while (data[i] == 0)
            {
                data.RemoveRange(i, data.Count - i);
                i--;
            }
            return data.ToArray();
        }

        // расширение длины ключа
        public static byte[] ExtendKey(string data)
        {
            StringBuilder stringBuilder = new StringBuilder(data);
            if (data.Length > 7)
            {
                return Encoding.UTF8.GetBytes(stringBuilder.Remove(7, data.Length - 7).ToString());
            }

            int diff = 7 - data.Length;
            for(int i = 0; i < diff; i++)
            {
                stringBuilder.Append(data[i % data.Length]);
            }
            return Encoding.UTF8.GetBytes(stringBuilder.ToString());
 
        }
        public static bool CheckTime(DateTime t1, DateTime t2, long duration)
        {
            TimeSpan ts = new TimeSpan(duration);
            if(t2 < t1 + ts)
            {
                return true;
            }
            return false;
        }
    }
}
