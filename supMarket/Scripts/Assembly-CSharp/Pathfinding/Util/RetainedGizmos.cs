using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding.Util
{
	public class RetainedGizmos
	{
		public struct Hasher
		{
			private ulong hash;

			private bool includePathSearchInfo;

			private bool includeAreaInfo;

			private PathHandler debugData;

			public ulong Hash => 0uL;

			public Hasher(AstarPath active)
			{
				hash = 0uL;
				includePathSearchInfo = false;
				includeAreaInfo = false;
				debugData = null;
			}

			public void AddHash(int hash)
			{
			}

			public void HashNode(GraphNode node)
			{
			}
		}

		public class Builder : IAstarPooledObject
		{
			private List<Vector3> lines;

			private List<Color32> lineColors;

			private List<Mesh> meshes;

			public void DrawMesh(RetainedGizmos gizmos, Vector3[] vertices, List<int> triangles, Color[] colors)
			{
			}

			public void DrawWireCube(GraphTransform tr, Bounds bounds, Color color)
			{
			}

			public void DrawLine(Vector3 start, Vector3 end, Color color)
			{
			}

			public void Submit(RetainedGizmos gizmos, Hasher hasher)
			{
			}

			private void SubmitMeshes(RetainedGizmos gizmos, ulong hash)
			{
			}

			private void SubmitLines(RetainedGizmos gizmos, ulong hash)
			{
			}

			void IAstarPooledObject.OnEnterPool()
			{
			}
		}

		private struct MeshWithHash
		{
			public ulong hash;

			public Mesh mesh;

			public bool lines;
		}

		private List<MeshWithHash> meshes;

		private HashSet<ulong> usedHashes;

		private HashSet<ulong> existingHashes;

		private Stack<Mesh> cachedMeshes;

		public Material surfaceMaterial;

		public Material lineMaterial;

		public GraphGizmoHelper GetSingleFrameGizmoHelper(AstarPath active)
		{
			return null;
		}

		public GraphGizmoHelper GetGizmoHelper(AstarPath active, Hasher hasher)
		{
			return null;
		}

		private void PoolMesh(Mesh mesh)
		{
		}

		private Mesh GetMesh()
		{
			return null;
		}

		public bool HasCachedMesh(Hasher hasher)
		{
			return false;
		}

		public bool Draw(Hasher hasher)
		{
			return false;
		}

		public void DrawExisting()
		{
		}

		public void FinalizeDraw()
		{
		}

		public void ClearCache()
		{
		}

		private void RemoveUnusedMeshes(List<MeshWithHash> meshList)
		{
		}
	}
}
