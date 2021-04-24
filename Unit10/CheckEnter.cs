using System;
using System.Collections.Generic;
using System.Text;

namespace Unit10
{
    class CheckEnter
    {
        public CheckEnter()
        { 

        }

       public bool CheckEnterNum (string SNum)
        {
            decimal Num;
            bool okCheck = true;

            try
            {
                Num = decimal.Parse(SNum);
                okCheck = true;
            }
            catch (FormatException)
            {
                 okCheck = false;
            }
            

             return okCheck;
        }
    }
}
