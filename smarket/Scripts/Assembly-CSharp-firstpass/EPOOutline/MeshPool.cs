using System.Collections.Generic;
using UnityEngine;

namespace EPOOutline
{
	public class MeshPool
	{
		private Queue<Mesh> freeMeshes;

		private List<Mesh> allMeshes;

		public Mesh AllocateMesh()
		{
			return null;
		}

		public void ReleaseAllMeshes()
		{
		}
	}
}
