using System;
using UnityEngine;

namespace MagicaCloth2
{
	public class VirtualMeshContainer : IDisposable
	{
		public VirtualMesh shareVirtualMesh;

		public VirtualMesh.UniqueSerializationData uniqueData;

		public bool hasUniqueData => false;

		public VirtualMeshContainer()
		{
		}

		public VirtualMeshContainer(VirtualMesh vmesh)
		{
		}

		public void Dispose()
		{
		}

		public int GetTransformCount()
		{
			return 0;
		}

		public Transform GetTransformFromIndex(int index)
		{
			return null;
		}

		public Transform GetCenterTransform()
		{
			return null;
		}
	}
}
