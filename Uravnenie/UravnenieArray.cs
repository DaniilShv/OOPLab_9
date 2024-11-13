using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UravnenieLib
{
    public class UravnenieArray
    {
        Uravnenie[] arr;
        int length = 0;
        public int Length
        {
            get { return length; }
        }
        public UravnenieArray() { }
        public UravnenieArray(int size)
        {
            arr = new Uravnenie[size];
            Uravnenie u;
            for (int i = 0; i < size; i++)
            {
                u = new Uravnenie();
                arr[i] = u.Random();
                length++;
            }
        }
        public UravnenieArray(params Uravnenie[] param)
        {
            arr = new Uravnenie[param.Length];
            for (int i = 0; i < param.Length; i++)
            {
                arr[i] = param[i];
            }
        }
        public void Show()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i].ToString());
            }
        }
        public void Add(ref Uravnenie u)
        {
            if (arr == null)
            {
                arr = new Uravnenie[1];
                arr[0] = u;
                length++;
            }
            else
            {
                Uravnenie[] tempArr = new Uravnenie[arr.Length + 1];
                for (int i = 0; i < arr.Length; i++)
                {
                    tempArr[i] = arr[i];
                }
                tempArr[arr.Length] = u;
                length++;
                arr = tempArr;
            }
        }
        public Uravnenie this[int index]
        {
            get 
            {
                if (arr.Length == 0)
                    throw new NullReferenceException();
                if (index < arr.Length && index >= 0)
                    return arr[index];
                else
                    throw new IndexOutOfRangeException();
            }
            set 
            {
                if (arr.Length == 0)
                    throw new NullReferenceException();
                if (index < arr.Length && index >= 0)
                    arr[index] = value;
                else
                    throw new IndexOutOfRangeException();
            }
        }
    }
}
