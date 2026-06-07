using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;

namespace AwesomeTechnologies.VegetationSystem
{
	public class VegetationPackageInstances
	{
		public readonly List<NativeList<MatrixInstance>> VegetationItemMatrixList = new List<NativeList<MatrixInstance>>();

		public NativeList<int> LoadStateList;

		public readonly List<ComputeBufferInfo> VegetationItemComputeBufferList = new List<ComputeBufferInfo>();

		public readonly List<IndirectInstanceInfo> VegetationItemInstancedIndirectInstanceList = new List<IndirectInstanceInfo>();

		public JobHandle LoadVegetationJobHandle;

		public VegetationPackageInstances(int vegetationItemCount)
		{
			VegetationItemMatrixList.Capacity = vegetationItemCount;
			LoadStateList = new NativeList<int>(vegetationItemCount, Allocator.Persistent);
			for (int i = 0; i <= vegetationItemCount - 1; i++)
			{
				VegetationItemMatrixList.Add(new NativeList<MatrixInstance>(Allocator.Persistent));
				VegetationItemInstancedIndirectInstanceList.Add(new IndirectInstanceInfo());
				VegetationItemComputeBufferList.Add(new ComputeBufferInfo());
				LoadStateList.Add(0);
			}
		}

		public void ClearInstanceMemory()
		{
			for (int i = 0; i <= VegetationItemMatrixList.Count - 1; i++)
			{
				NativeList<MatrixInstance> nativeList = VegetationItemMatrixList[i];
				if (nativeList.IsCreated)
				{
					nativeList.Clear();
					nativeList.Capacity = 0;
				}
			}
		}

		public void Dispose()
		{
			for (int i = 0; i <= VegetationItemMatrixList.Count - 1; i++)
			{
				VegetationItemMatrixList[i].Dispose();
			}
			VegetationItemMatrixList.Clear();
			for (int j = 0; j <= VegetationItemInstancedIndirectInstanceList.Count - 1; j++)
			{
				if (VegetationItemInstancedIndirectInstanceList[j].Created)
				{
					VegetationItemInstancedIndirectInstanceList[j].InstancedIndirectInstanceList.Dispose();
				}
			}
			for (int k = 0; k <= VegetationItemComputeBufferList.Count - 1; k++)
			{
				ComputeBufferInfo computeBufferInfo = VegetationItemComputeBufferList[k];
				if (computeBufferInfo.Created)
				{
					computeBufferInfo.ComputeBuffer.Dispose();
					computeBufferInfo.Created = false;
				}
			}
			if (LoadStateList.IsCreated)
			{
				LoadStateList.Dispose();
			}
		}
	}
}
