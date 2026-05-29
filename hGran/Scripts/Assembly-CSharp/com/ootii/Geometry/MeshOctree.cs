using UnityEngine;

namespace com.ootii.Geometry
{
	public class MeshOctree
	{
		public string Name;

		public MeshOctreeNode Root;

		public MeshOctree()
		{
		}

		public MeshOctree(Mesh rMesh)
		{
		}

		public void Initialize(Mesh rMesh)
		{
		}

		public bool ContainsPoint(Vector3 rPoint)
		{
			return false;
		}

		public Vector3 ClosestPoint(Vector3 rPoint)
		{
			return default(Vector3);
		}

		public Vector3 ClosestPoint(Vector3 rPoint, float rRadius)
		{
			return default(Vector3);
		}

		public void OnSceneGUI(Transform rTransform)
		{
		}
	}
}
