using System.Text.RegularExpressions;

namespace CalcLB
{
    public class Calc
    {
        public int Add(string numb)
        {
            string[] separator = { ",", "\n" };
            return Add(numb, separator);
        }

        public int Add(string numb, string[] delimiterCharacters)
        {
            try
            {
                string[] separator = delimiterCharacters;
                string[] num = numb.Split(separator, StringSplitOptions.None);
                int[] nums = new int[num.Length];
                int result = 0;

                if (delimiterCharacters.Length == 0) { return Add(numb); } //если список разделителей пуст

                for (int i = 0; i < num.Length; i++)
                {
                    if (i >= 5)
                        return result;
                    else if (Int32.Parse(num[i]) > 20) // если i-ое больше 20
                        continue;
                    else
                    {
                        nums[i] = Int32.Parse(num[i]);
                        result += nums[i];
                    }
                }
                return result;
            }
            catch(Exception ex)
            {
                if (String.IsNullOrWhiteSpace(numb) || String.IsNullOrEmpty(numb))
                {
                    return 0;
                }

                else
                {
                    throw new ArgumentException("Ошибка сложения строки!");
                }                
            }
            return 0;
        }
    }


    

}