using System;
using System.Collections.Generic;

namespace ServerPrototype
{
    public interface IServer
    {
        IServer Clone();
        void GetInfo();
    }

    public class CpuServer : IServer
    {
        public int CpuCores { get; set; }
        public int Memory { get; set; }
        public int Storage { get; set; }
        
        public CpuServer(int cpuCores, int memory, int storage)
        {
            CpuCores = cpuCores;
            Memory = memory;
            Storage = storage;
        }

        public IServer Clone()
        {
            return (IServer)this.MemberwiseClone();
        }
        
        public void GetInfo()
        {
            Console.WriteLine($"CPU Server: {CpuCores} CPU Cores, {Memory} GB RAM, {Storage} GB Storage");
        }
    }

    public class GpuServer : IServer
    { 
        public int GpuCount { get; set; }
        public int Memory { get; set; }
        public int Storage { get; set; }
        
        public GpuServer(int gpuCount, int memory, int storage)
        {
            GpuCount = gpuCount;
            Memory = memory;
            Storage = storage;
        }
        
        public IServer Clone()
        {
            return (IServer)this.MemberwiseClone();
        }
        
        public void GetInfo()
        {
            Console.WriteLine($"GPU Server: {GpuCount} GPUs, {Memory} GB RAM, {Storage} GB Storage");
        }
    }

    public class TpuServer : IServer
    {
        public int TpuCount { get; set; }
        public int Memory { get; set; }
        public int Storage { get; set; }
        
        public TpuServer(int tpuCount, int memory, int storage)
        {
            TpuCount = tpuCount;
            Memory = memory;
            Storage = storage;
        }
        
        public IServer Clone()
        {
            return (IServer)this.MemberwiseClone();
        }
        
        public void GetInfo()
        {
            Console.WriteLine($"TPU Server: {TpuCount} TPU Cores, {Memory} GB RAM, {Storage} GB Storage");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
            CpuServer cpuPrototype = new CpuServer(cpuCores: 16, memory: 64, storage: 2000);
            GpuServer gpuPrototype = new GpuServer(gpuCount: 4, memory: 128, storage: 4000);
            TpuServer tpuPrototype = new TpuServer(tpuCount: 8, memory: 256, storage: 8000);

            List<IServer> servers = new List<IServer>();
            
            CpuServer cpuServer1 = (CpuServer)cpuPrototype.Clone();
            cpuServer1.Memory = 128;
            servers.Add(cpuServer1);

            GpuServer gpuServer1 = (GpuServer)gpuPrototype.Clone();
            gpuServer1.GpuCount = 8;
            servers.Add(gpuServer1);

            TpuServer tpuServer1 = (TpuServer)tpuPrototype.Clone();
            tpuServer1.TpuCount = 72;
            tpuServer1.Storage = 16000;
            servers.Add(tpuServer1);

            foreach (var server in servers)
            {
                server.GetInfo();
            }
            */
        }
    }
}