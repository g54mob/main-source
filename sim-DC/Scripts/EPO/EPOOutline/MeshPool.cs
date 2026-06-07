using System;
using System.Collections.Generic;
using UnityEngine;

namespace EPOOutline
{
	public class MeshPool : IDisposable
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

		public void Dispose()
		{
		}
	}
}
