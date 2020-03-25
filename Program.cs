using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0224
{
    class Program
    {
        static void Main(string[] args)
        {
            int aqq = 10;
            int b = aqq;
            b = 20;
            Console.WriteLine(aqq);

            //boxing的部分
            int i = 123;
            object o = i;
            i = 456;
            Console.WriteLine("i={0}", i);
            Console.WriteLine("o={0}", o);
            //i=456 o=123
            int j = (int)o;
            Console.WriteLine("unboxing ok!"); //unboxing成功
            try
            {
                int jj = (short)o;
                Console.WriteLine("j: unboxing ok!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("jj error:{0}", ex.Message);//unboxing失敗
            }
            //Method
            int k = 123;
            PassByValue(k);//不會影響
            Console.WriteLine("k:{0}", k);

            Human superman = new Human();//重心定義詞就會影響
            superman.Age = 18;
            PassByValue(superman);
            Console.WriteLine("k:{0}", superman.Age);

            PassByRef(ref k);//會影響
            Console.WriteLine("k:{0}", k);

            int kout;
            PassByOut(out kout);//會影響
            Console.WriteLine("k:{0}", kout);

            //參考陣列
            string result = Average("jack", 90, 80, 50, 40);
            Console.WriteLine(result);
            //參數
            string myAddr = AddAddress(addrCity: "台北市", addrCode: "113", addrRoad: "內湖路");
            Console.WriteLine(myAddr);

            int a = 123;
            Console.WriteLine(a.ToString());
            Human h1 = new Human();
            Console.WriteLine(h1.ToString());//如無設定則回傳Class名稱

            int price1 = 10;
            string price2 = "10";
            string outputPrice = price2 + price1;
            Console.WriteLine(outputPrice);//字串加數字會把會數字自動轉成字串再相加

            string x = "ggg123";
            int y;
            if (int.TryParse(x, out y) == true)//使用TryParse來檢查是否含有字元
            {
                Console.WriteLine("true");
            }
            Console.WriteLine(y);

            string m = "9999999999999";
            int n = 0;
            try
            {
                i = int.Parse(m);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);//字元數字太大無法顯示
            }

            DateTime dd = DateTime.Now;
            Console.WriteLine(dd.ToString("yyyy/MM/dd HH:mm:ss"));

            if (MethodTrue() == true & MethodFalse() == true)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }

            int r = 0;
            Console.WriteLine(++r);

            int s = 0;
            Console.WriteLine(s++);
            Console.WriteLine(s);

            int[] array = {9, 1, 2, 3, 4, 5 };
            foreach (int ar in array)
            {
                Console.WriteLine(ar);
            }

            String[] pairs = { "Color1=red", "Color2=green", "Color3=blue","Title=Code Repository" };
            foreach (var pair in pairs)
            {
                int position = pair.IndexOf("=");
                if (position < 0)
                    continue;
                Console.WriteLine("Key: {0}, Value: '{1}'",
                               pair.Substring(0, position),
                               pair.Substring(position + 1));
            }

            int uu = 0;
            do//先執行
            {
                Console.WriteLine(uu);
                uu++;
            } while (uu < 0);

            int nqq = 0;
            while (nqq < 5)//先判斷
            {
                Console.WriteLine(nqq);
                nqq++;
            }         
            Console.Read();
            
        }
        public static void PassByValue(int j)
        {
            j = 0;
        }
        public static void PassByValue(Human man)
        {
            man.Age = 12;
        }
        public static void PassByRef(ref int j)
        {
            j = 99;
        }
        public static void PassByOut(out int j)
        {
            j = 0;
        }

        public static string Average(string userman, params int[] grades)
        {
            string result = string.Empty;//string.Empty 就是 = ""

            double total = 0;
            for (int i = 0; i < grades.Count(); i++)
            {
                total += grades[i];
            }

            result = string.Format("{0} : {1}分", userman, total / grades.Count());
            return result;
        }

        public static string AddAddress(string addrCode, string addrCity, string addrRoad, string addrCounty = "taiwan")
        {
            string x = $"({addrCode}){ addrCity},{addrRoad},{addrCounty}";//$"()"字串相加
            return x;
        }

        public static bool MethodFalse()
        {
            Console.WriteLine("false");
            return false;
        }
        public static bool MethodTrue()
        {
            Console.WriteLine("true");
            return true;
        }
    }
    class Human
    {
        public int Age { get; set; }
    }
}
