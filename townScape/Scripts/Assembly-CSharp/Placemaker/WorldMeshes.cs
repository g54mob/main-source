using System.Collections.Generic;
using UnityEngine;

namespace Placemaker
{
	public class WorldMeshes : MonoBehaviour
	{
		[SerializeField]
		private int mfIterator;

		[SerializeField]
		private int meshIterator;

		[SerializeField]
		private List<Mesh> meshStack;

		private Mesh GetNewMesh()
		{
			return null;
		}

		public Mesh GetMesh()
		{
			return null;
		}

		private MeshFilter GetNewMeshFilter(Transform parent)
		{
			return null;
		}

		public MeshFilter GetMeshFilterOnly(Transform parent)
		{
			return null;
		}

		public MeshFilter GetMeshFilter(Transform parent)
		{
			return null;
		}

		public void ReturnMesh(Mesh mesh)
		{
		}

		public void ReturnMeshFilterOnly(MeshFilter mf)
		{
		}

		public void ReturnMeshFilter(MeshFilter mf)
		{
		}

		public void ReturnMeshFilters(Transform container)
		{
		}

		public bool IterateRefillPools(WorldMaster master)
		{
			return false;
		}
	}
}
