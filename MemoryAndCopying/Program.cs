using System;

namespace MemoryAndCopying
{
    class Program
    {
        static void Main(string[] args)
        {
            Storage[] storage = new Storage[3];
            storage[0] = new Flash("Kingston", "DataTraveler", 4.8, 128);
            storage[1] = new DVD("Verbatim", "DVD-R", 0.021, DVD.Side.doublesides);
            storage[2] = new HDD("Seagate", "Exos 7E8", 0.469, 1, 1024);
            foreach (var i in storage)
                i.Show(565, 0.76);
        }
    }
}
