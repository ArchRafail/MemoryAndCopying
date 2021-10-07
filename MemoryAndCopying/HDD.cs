using System;

namespace MemoryAndCopying
{
    class HDD : Storage
    {
        private double velocity;
        private int partsQty;
        private double partsVolume;
        private int count_equip;
        public HDD()
        {
            this.name = "No name";
            this.model = "No model";
            this.velocity = 0.469;
            this.partsQty = 1;
            this.partsVolume = 256;
        }
        public HDD(string name, string model, double velocity, int partsQty, double partsVolume)
        {
            this.name = name;
            this.model = model;
            this.velocity = velocity;
            this.partsQty = partsQty;
            this.partsVolume = partsVolume;
        }
        private int Copy(double total_volume, double file_volume)
        {
            int files_per_memory;
            if (GetVolume() < total_volume)
                files_per_memory = (int)(GetVolume() / file_volume);
            else
                files_per_memory = (int)(total_volume / file_volume);
            count_equip = (int)(total_volume / (files_per_memory * file_volume));
            return files_per_memory;
        }
        public override double GetVolume() => partsQty * partsVolume;
        public override double GetFreeVolume(double total_volume, double file_volume)
        {
            return GetVolume() - Copy(total_volume, file_volume) * file_volume;
        }
        public override double GetTime(double total_volume) => total_volume / this.velocity;
        public override void Show(double total_volume, double file_volume)
        {
            Console.WriteLine("An information about HDD memory.");
            Console.WriteLine($"Name: {Name}\tModel: {Model}");
            Console.WriteLine($"Total space: {this.GetVolume()} Gb.\tHDD velocity: {velocity} Gb/sec.");
            Copy(total_volume, file_volume);
            Console.WriteLine($"Total q-ty of memory equipment: {count_equip}");
            Console.WriteLine($"Total time to copy information: {Math.Ceiling(GetTime(total_volume)) * 2} sec. or {Math.Ceiling(GetTime(total_volume) * 2 / 60)} min.");
            Console.Write("Free space on ");
            Console.Write(this.count_equip > 1 ? "each " : "");
            Console.WriteLine($"HDD after copy: {Math.Round(GetFreeVolume(total_volume, file_volume), 2)} Gb.");
            Console.WriteLine("\n");
        }
    }
}
