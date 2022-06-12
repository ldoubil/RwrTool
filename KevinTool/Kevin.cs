using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RwrTool.KevinTool
{
    public class Kevin
    {
        /// <summary>
        /// 获取随机整数
        /// </summary>
        /// <param name="count">你需要几个随机数</param>
        /// <param name="minNum">下限</param>
        /// <param name="maxNum">上限</param>
        /// <returns>返回随机数的数组，长度根据个数而定</returns>
        public static int[] GetRandomArray(int count, int minNum, int maxNum)
        {
            int[] randomArr = new int[count];
            Random r = new Random();
            for (int j = 0; j < count; j++)
            {
                int i = r.Next(minNum, maxNum + 1);
                int num = 0;
                for (int k = 0; k < j; k++)
                {
                    if (randomArr[k] == i) num = num + 1;
                }
                if (num == 0)
                    randomArr[j] = i;
                else
                    j = j - 1;
            }
            return randomArr;
        }

        /// <summary>
        /// 获取随机浮点数
        /// </summary>
        /// <param name="minimum">下限</param>
        /// <param name="maximum">上限</param>
        /// <param name="Len">小数点保留位数</param>
        /// <returns>随机的浮点数</returns>
        public static double GetRandomNumber(double minimum, double maximum, int Len)
        {
            Random random = new Random();
            //注意：不用间隔时间，使用for循环获取，返回的几个随机数会一模一样
            System.Threading.Thread.Sleep(1);
            return Math.Round(random.NextDouble() * (maximum - minimum) + minimum, Len);
        }


    }
}
