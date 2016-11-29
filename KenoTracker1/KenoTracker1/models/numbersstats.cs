using System;
using System.Collections.Generic;
using System.Text;

namespace KenoTracker1.models
{
   public class numbersstats
    {
        private string _number;
        private int _count;

       public numbersstats(string numx ="")
       {
           Number = numx;
           Count = 0;
       }
        public string Number
        {
            get
            {
                return _number;
            }

            set
            {
                _number = value;
            }
        }

        public int Count
        {
            get
            {
                return _count;
            }

            set
            {
                _count = value;
            }
        }

        public void add()
        {
            _count++;

        }

        public override string ToString()
        {
            var str = _number + " came out " + _count.ToString() + " times";
            return str;
        }
    }
}
