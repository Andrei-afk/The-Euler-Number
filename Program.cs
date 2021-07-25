using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantaLuiEuler
{
    class Program
    {
        public static List<int> scadere(List<int> desc, List<int> sca)
        {
            int i;
            List<int> rez = new List<int>();
            bool ok = true;
            if (sca.Count() > desc.Count())
            {
                return desc;
            }
            if (sca.Count() == desc.Count())
            {
                for (i = 0; i < sca.Count(); i++)
                {
                    if (sca[i] != desc[i])
                        ok = false;
                }
                if (ok == true)
                {
                    rez.Add(0);
                    return rez;
                }
            }
            i = sca.Count() - 1;
            if (sca.Count() == desc.Count())
            {
                while (sca[i] == desc[i])
                {


                    if (sca[i] > desc[i])
                    {
                        rez.Add(-1);
                        return rez;
                    }
                    i--;
                }
            }

            i = sca.Count() - 1;
            int j = desc.Count() - 1;
            int cs, cd, c;
            bool imp = false;
            while (i > -1)
            {
                cs = sca[i];
                cd = desc[j];

                if (imp == true)
                {
                    if (cd == 0)
                        cd = 9;
                    else
                    {
                        cd--;
                        imp = false;
                    }

                }

                if (cd >= cs)
                {
                    c = cd - cs;
                }
                else
                {
                    c = cd + 10 - cs;
                    imp = true;
                }

                rez.Insert(0, c);

                i--; j--;
            }

            while (j > -1)
            {
                if (imp == true)
                {
                    while (desc[j] == 0)
                    {
                        rez.Insert(0, 9);
                        j--;
                    }
                    rez.Insert(0, desc[j] - 1);
                    imp = false;
                    j--;
                }
                else
                {
                    rez.Insert(0, desc[j]);
                    j--;
                }

            }
            int h;
            bool k = true;
            for (h = 0; h < rez.Count(); h++)
                if (rez[h] != 0)
                    k = false;
            if (k == false)
            {
                while (rez[0] == 0)
                    rez.RemoveAt(0);
            }
            else
            {
                rez.Clear();
                rez.Add(0);
            }
            return rez;
        }

        public static List<int> produs(List<int> a, int x)
        {
            List<int> rez = new List<int>();
            int i;
            int c;
            int rest = 0;

            for (i = a.Count() - 1; i >= 0; i--)
            {
                c = a[i] * x + rest;
                rez.Insert(0, c % 10);
                rest = c / 10;
            }
            while (rest != 0)
            {
                rez.Insert(0, rest % 10);
                rest /= 10;
            }
            return rez;
        }

        public static int comp(List<int> a, List<int> b)
        {
            if (a.Count() > b.Count())
                return 1;
            if (a.Count() < b.Count())
                return 2;
            int i;
            for (i = 0; i < a.Count(); i++)
            {
                if (a[i] > b[i])
                    return 1;
                if (a[i] < b[i])
                    return 2;
            }
            return 0;
        }

        public static List<int> impartire(List<int> impartitor, int precizie)
        {
            List<int> cat = new List<int>();
            List<int> deimpartit = new List<int>();
            int i;
            int lungimeCurentaCat = 0;
            if (impartitor.Count() == 1 && impartitor[0] == 1)
            {
                cat.Add(1);
                return cat;
            }
            deimpartit.Add(1);
            for (i = 1; i < impartitor.Count(); i++)
            {
                cat.Add(0);
                deimpartit.Add(0);
                lungimeCurentaCat++;
            }
            int j, comparare;
            List<int> p = new List<int>();
            List<int> s = new List<int>();

            while (lungimeCurentaCat <= precizie)
            {
                for (j = 0; j <= 9; j++)
                {
                    p = produs(impartitor, j);
                    s = scadere(deimpartit, p);

                    comparare = comp(s, impartitor);
                    if (comparare == 2)
                    {


                        break;
                    }

                }
                cat.Add(j);
                deimpartit = s;
                deimpartit.Add(0);

                lungimeCurentaCat++;
            }

            cat.RemoveAt(0);
            return cat;
        }

        public static List<int> adunare(List<int> a, List<int> b)
        {
            List<int> rez = new List<int>();
            int i;
            if (a.Count() < b.Count())
            {
                i = a.Count();
                while (i < b.Count())
                {
                    a.Insert(0, 0);
                    i++;
                }
            }
            else
            {
                if (a.Count() > b.Count())
                {
                    i = b.Count();
                    while (i < a.Count())
                    {
                        b.Insert(0, 0);
                        i++;
                    }
                }
            }

            int rest = 0, c;
            for (i = a.Count() - 1; i >= 0; i--)
            {
                c = a[i] + b[i] + rest;
                rez.Insert(0, c % 10);
                rest = c / 10;
            }
            return rez;
        }

        public static bool verf0(List<int> a)
        {
            int i;
            for (i = 0; i < a.Count(); i++)
            {
                if (a[i] != 0)
                    return false;
            }
            return true;
        }

        public static List<int> makeSuma0(int precizie)
        {
            List<int> sum = new List<int>();
            int i;
            for (i = 0; i < precizie - 1; i++)
            {
                sum.Add(0);
            }
            return sum;
        }

        static void Main(string[] args)
        {
            int precizie;
            Console.WriteLine("Introduceti precizia de calcul: ");
            precizie = int.Parse(Console.ReadLine());
            List<int> factorial = new List<int>();
            List<int> constantaEu = new List<int>();
            List<int> termen = new List<int>();
            List<int> prod = new List<int>();
            List<int> suma = new List<int>();
          
            
            
            suma = makeSuma0(precizie);
            factorial.Add(1);

            int i=2;
            while(true)
            {
                factorial = produs(factorial, i);
                termen = impartire(factorial, precizie);
                suma = adunare(suma, termen);
              
              
                i++;
                if(verf0(termen) == true)
                {
                    break;
                }

            }
            StreamWriter sw = new StreamWriter("solutie.txt");
            foreach (Object o in suma)
            {
                sw.Write(o);
            }
            Console.WriteLine("Partea zecimala este scrisa in fisier.");
            sw.Flush();
            sw.Close();
            Console.ReadLine();

        }
    }
}
