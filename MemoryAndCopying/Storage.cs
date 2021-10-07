using System;


namespace MemoryAndCopying
{
    abstract class Storage
    {
        protected string name;
        protected string model;
        public string Name
        { get => name; }
        public string Model
        { get => model; }
        abstract public double GetVolume();
        abstract public double GetFreeVolume(double total_volume, double file_volume);
        abstract public double GetTime(double total_volume);
        abstract public void Show(double total_volume, double file_volume);
    }
}
