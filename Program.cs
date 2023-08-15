namespace ConsoleTesteNUnit
{
    public class Program
    {


        private readonly string name;

        public Program(string name)
        {
            this.name = name;
        }

        public void Run()
        {
            Thread.Sleep(100);
            Console.Write(name);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var r = 4;
            var w = 2;
            var x = 1;
            var _ = 0;
            var result1 = r + w + x;
            var result2 = r + _ + x;
            var result3 = _ + w + _;
            Console.WriteLine(result1);
            Console.WriteLine(result2);
            Console.WriteLine(result3);




            var AllPrefixes = (new string[] { "flow", "flowers", "flew", "flag", "fm" });

            var result = AllPrefixes.Where(x => x.Length >= 3).Distinct();

            foreach (var prefix in result)
            {

                if (prefix.Length == 4)
                {
                    Console.WriteLine(prefix.Substring(0, 3));
                }


            }
         

            Thread t1 = new Thread(new Program("1").Run);
            Thread t2 = new Thread(new Program("2").Run);
            Thread t3 = new Thread(new Program("3").Run);
            Thread t4 = new Thread(new Program("4").Run);
            Thread t5 = new Thread(new Program("5").Run);

      
            t5.Start();
            t3.Start();
            t1.Start();
            t3.Join();
            t2.Start();
            t1.Join();
            t4.Start();
            t2.Join();
            t4.Join();
            t5.Join();

            // { "flo", "fle", "fla" }

        }



        


        public static bool DataAluquel(DateTime dataInicio, DateTime dataFinal, List<DateTime?> listaPreenchidaInicio, List<DateTime?> listaPreenchidaFinal)
        {
            if (dataInicio >= dataFinal)
            {
                return false;
            }
            if(listaPreenchidaInicio.Any() && listaPreenchidaFinal.Any())
            {
                listaPreenchidaInicio.Add(dataInicio);
                listaPreenchidaFinal.Add(dataFinal);
                return true;
            }

            foreach (var inicio in listaPreenchidaInicio)
            {
                foreach (var final in listaPreenchidaFinal)
                {
                    if (dataInicio.Date == inicio?.Date && dataInicio.Hour == inicio?.Hour || dataFinal.Date == final?.Date && dataFinal.Hour == final?.Hour)
                    {
                        return false;
                    }
                }
            }

            listaPreenchidaInicio.Add(dataInicio);
            listaPreenchidaFinal.Add(dataFinal);
            return true;
        }


        public class Shelf
        {
            private List<string> items = new List<string>();

            public void Put(string item)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    this.items.Add(item);
                }
            }

            public bool Take(string item)
            {
                if (items.Contains(item))
                {
                    items.Remove(item);
                    return true;
                }

                return false;
            }
        }

    }
}