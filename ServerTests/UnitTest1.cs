using NUnit.Framework;
using ServerPrototype;

namespace ServerPrototype.Tests
{
    [TestFixture]
    public class ServerTests
    {
        [Test]
        public void Clone_ExactCopy_CPU()
        {
            var cpuPrototype = new CpuServer(cpuCores: 16, memory: 64, storage: 2000);
            
            var cpuClone = (CpuServer)cpuPrototype.Clone();

            NUnit.Framework.Legacy.ClassicAssert.AreEqual(cpuPrototype.CpuCores, cpuClone.CpuCores);
            NUnit.Framework.Legacy.ClassicAssert.AreEqual(cpuPrototype.Memory, cpuClone.Memory);
            NUnit.Framework.Legacy.ClassicAssert.AreEqual(cpuPrototype.Storage, cpuClone.Storage);
            NUnit.Framework.Legacy.ClassicAssert.AreNotEqual(cpuPrototype, cpuClone);
        }

        [Test]
        public void Gpu_ModifyClone_NotAffectPrototype()
        {
            var gpuPrototype = new GpuServer(gpuCount: 4, memory: 128, storage: 4000);

            var gpuClone = (GpuServer)gpuPrototype.Clone();
            gpuClone.GpuCount = 8;
            gpuClone.Memory = 256;

            NUnit.Framework.Legacy.ClassicAssert.AreEqual(4, gpuPrototype.GpuCount);
            NUnit.Framework.Legacy.ClassicAssert.AreEqual(128, gpuPrototype.Memory);
            NUnit.Framework.Legacy.ClassicAssert.AreEqual(8, gpuClone.GpuCount);
            NUnit.Framework.Legacy.ClassicAssert.AreEqual(256, gpuClone.Memory);
        }

        [Test]
        public void Tpu_GetInfo_CorrectString()
        {
            var tpuServer = new TpuServer(tpuCount: 2, memory: 256, storage: 8000);

            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                tpuServer.GetInfo();
                var result = sw.ToString().Trim();

                NUnit.Framework.Legacy.ClassicAssert.AreEqual("TPU Server: 2 TPU Cores, 256 GB RAM, 8000 GB Storage", result);
            }
        }

        [Test]
        public void CpuServer_ModifyClone_NotAffectOriginal()
        {
            var cpuPrototype = new CpuServer(cpuCores: 16, memory: 64, storage: 2000);
            var cpuClone = (CpuServer)cpuPrototype.Clone();

            cpuClone.CpuCores = 32;
            cpuClone.Memory = 128;

            NUnit.Framework.Legacy.ClassicAssert.AreEqual(16, cpuPrototype.CpuCores);
            NUnit.Framework.Legacy.ClassicAssert.AreEqual(64, cpuPrototype.Memory);
            NUnit.Framework.Legacy.ClassicAssert.AreEqual(32, cpuClone.CpuCores);
            NUnit.Framework.Legacy.ClassicAssert.AreEqual(128, cpuClone.Memory);
        }

        [Test]
        public void GpuServer_Clone_CreateNewInstance()
        {
            var gpuPrototype = new GpuServer(gpuCount: 4, memory: 128, storage: 4000);

            var gpuClone = (GpuServer)gpuPrototype.Clone();

            NUnit.Framework.Legacy.ClassicAssert.AreNotEqual(gpuPrototype, gpuClone);
        }

        [Test]
        public void TpuServer_Clone_ChangeStorage_NotAffectOriginal()
        {
            var tpuPrototype = new TpuServer(tpuCount: 2, memory: 256, storage: 8000);

            var tpuClone = (TpuServer)tpuPrototype.Clone();
            tpuClone.Storage = 16000;

            NUnit.Framework.Legacy.ClassicAssert.AreEqual(8000, tpuPrototype.Storage);
            NUnit.Framework.Legacy.ClassicAssert.AreEqual(16000, tpuClone.Storage);
        }

        [Test]
        public void AllServers_ImplementIServerInterface()
        {
            var cpuServer = new CpuServer(16, 64, 2000);
            var gpuServer = new GpuServer(4, 128, 4000);
            var tpuServer = new TpuServer(2, 256, 8000);
            
            NUnit.Framework.Legacy.ClassicAssert.IsInstanceOf<IServer>(cpuServer);
            NUnit.Framework.Legacy.ClassicAssert.IsInstanceOf<IServer>(gpuServer);
            NUnit.Framework.Legacy.ClassicAssert.IsInstanceOf<IServer>(tpuServer);
        }

        [Test]
        public void CpuServer_Clone_WithDifferentValues_ShouldNotBeEqual()
        {
            var cpuPrototype = new CpuServer(cpuCores: 16, memory: 64, storage: 2000);
            var cpuClone = (CpuServer)cpuPrototype.Clone();
            cpuClone.CpuCores = 32;

            NUnit.Framework.Legacy.ClassicAssert.AreNotEqual(cpuPrototype.CpuCores, cpuClone.CpuCores);
        }

        [Test]
        public void GpuServer_GetInfo_OutputShouldMatch()
        {
            var gpuServer = new GpuServer(gpuCount: 4, memory: 128, storage: 4000);

            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                gpuServer.GetInfo();
                var result = sw.ToString().Trim();

                NUnit.Framework.Legacy.ClassicAssert.AreEqual("GPU Server: 4 GPUs, 128 GB RAM, 4000 GB Storage", result);
            }
        }

        [Test]
        public void Clone_Method_ShouldReturnCorrectType()
        {
            var cpuPrototype = new CpuServer(cpuCores: 16, memory: 64, storage: 2000);

            var clone = cpuPrototype.Clone();

            NUnit.Framework.Legacy.ClassicAssert.IsInstanceOf<CpuServer>(clone);
        }
    }
}