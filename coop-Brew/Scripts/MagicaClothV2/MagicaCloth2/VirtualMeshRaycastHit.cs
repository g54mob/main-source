using System;
using Unity.Mathematics;

namespace MagicaCloth2
{
	public struct VirtualMeshRaycastHit : IComparable<VirtualMeshRaycastHit>, IValid
	{
		public VirtualMeshPrimitive type;

		public int index;

		public float3 position;

		public float3 normal;

		public float distance;

		public int CompareTo(VirtualMeshRaycastHit other)
		{
			return 0;
		}

		public bool IsValid()
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
