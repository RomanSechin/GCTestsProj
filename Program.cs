
internal class Program
{
    private static void Main(string[] args)
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        var clones = new List<EvilClone>();

        while (true) {
            switch (Console.ReadKey(true).KeyChar) {
                case 'a':
                    clones.Add(new EvilClone());
                    break;
                case 'c':
                    Console.WriteLine("Clearing list at time {0}", stopwatch.ElapsedMilliseconds);
                    clones.Clear();
                    break;
                case 'g':
                    Console.WriteLine("Collecting at time {0}", stopwatch.ElapsedMilliseconds);
                    GC.Collect();
                    break;

            }
        }

//        EvilClone evilClone = new EvilClone();        
    }

    class EvilClone {
        public static int CloneCount = 0;
        public int CloneID { get; } = ++CloneCount;
        public EvilClone() => Console.WriteLine("Clone #{0} wreaking havoc", CloneID);
        ~EvilClone() {
            Console.WriteLine("Clone #{0} destroyed", CloneID);
        }
    }
}