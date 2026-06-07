using Unity.Mathematics;

namespace MagicaCloth2
{
	public struct VirtualMeshBoneWeight
	{
		public float4 weights;

		public int4 boneIndices;

		public bool IsValid => false;

		public int Count => 0;

		public VirtualMeshBoneWeight(int4 boneIndices, float4 weights)
		{
			this.weights = default(float4);
			this.boneIndices = default(int4);
		}

		public void AddWeight(int boneIndex, float weight)
		{
		}

		public void AddWeight(in VirtualMeshBoneWeight bw)
		{
		}

		public void AdjustWeight()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
