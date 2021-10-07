using System;


namespace MemoryAndCopying
{
    class DVD : Storage
    {
        private double velocity;
        public enum Side { oneside, doublesides};
        private double volume;
        private int count_equip;
        public DVD()
        {
            this.name = "No name";
            this.model = "No model";
            this.velocity = 0.021;
            this.volume = 4.7;
        }
        public DVD(string name, string model, double velocity, Side side)
        {
            this.name = name;
            this.model = model;
            this.velocity = velocity;
            switch (side)
            {
                case DVD.Side.oneside:
                    this.volume = 4.7;
                    break;
                case DVD.Side.doublesides:
                    this.volume = 9;
                    break;
            }
        }
        private int Copy(double total_volume, double file_volume)
        {
            int files_per_memory;
            if (GetVolume() < total_volume)
                files_per_memory = (int)(this.volume / file_volume);
            else
                files_per_memory = (int)(total_volume / file_volume);
            count_equip = (int)Math.Ceiling(total_volume / (files_per_memory * file_volume));
            return files_per_memory;
        }
        public override double GetVolume() => volume;
        public override double GetFreeVolume(double total_volume, double file_volume)
        {
            return this.volume - Copy(total_volume, file_volume) * file_volume;
        }
        public override double GetTime(double total_volume) => total_volume / this.velocity;
        public override void Show(double total_volume, double file_volume)
        {
            Console.WriteLine("An information about DVD memory.");
            Console.WriteLine($"Total space: {this.volume} Gb.\tDVD velocity: {this.velocity} Gb/sec.");
            Copy(total_volume, file_volume);
            Console.WriteLine($"Total q-ty of memory equipment: {count_equip}");
            Console.WriteLine($"Total time to copy information: {Math.Ceiling(GetTime(total_volume)) * 2} sec. or {Math.Ceiling(GetTime(total_volume) * 2 / 60)} min.");
            Console.Write("Free space on ");
            Console.Write(this.count_equip > 1 ? "each " : "");
            Console.WriteLine($"DVD after copy: {Math.Round(GetFreeVolume(total_volume, file_volume), 2)} Gb.");
            Console.WriteLine("\n");
        }
    }
}
