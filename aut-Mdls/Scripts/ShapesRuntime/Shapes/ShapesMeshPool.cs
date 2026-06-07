using System.Collections.Generic;
using UnityEngine;

namespace Shapes
{
	public static class ShapesMeshPool
	{
		private static int meshesAllocated = 0;

		private static Stack<Mesh> meshPool = new Stack<Mesh>();

		public static int MeshCountInPool => meshPool.Count;

		public static int MeshesAllocatedCount => meshesAllocated;

		public static int MeshCountInUse => MeshesAllocatedCount - MeshCountInPool;

		public static Mesh GetMesh()
		{
			if (meshPool.Count > 0)
			{
				return meshPool.Pop();
			}
			meshesAllocated++;
			return new Mesh
			{
				name = "Pooled Mesh",
				hideFlags = HideFlags.DontSave
			};
		}

		public static void Release(Mesh m)
		{
			m.Clear();
			meshPool.Push(m);
		}
	}
}
