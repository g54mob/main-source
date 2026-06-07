using UnityEngine;

namespace Jundroo.Common.Meshes
{
	public class MeshDataScript : MonoBehaviour
	{
		[SerializeField]
		private int[] _polyCounts;

		[SerializeField]
		private Vector3 _size = Vector3.zero;

		[SerializeField]
		private int _totalPolyCount;

		public int[] PolyCounts => _polyCounts;

		public Vector3 Size => _size;

		public int TotalPolyCount => _totalPolyCount;

		protected virtual void Start()
		{
			MeshRenderer[] componentsInChildren = GetComponentsInChildren<MeshRenderer>();
			if (componentsInChildren.Length != 0)
			{
				Bounds bounds = componentsInChildren[0].bounds;
				MeshRenderer[] array = componentsInChildren;
				foreach (MeshRenderer meshRenderer in array)
				{
					bounds.Encapsulate(meshRenderer.bounds);
				}
				_size = bounds.size;
			}
			RecalculateData();
		}

		protected virtual void Update()
		{
			RecalculateData();
		}

		private void RecalculateData()
		{
			MeshFilter[] componentsInChildren = GetComponentsInChildren<MeshFilter>();
			if (PolyCounts == null || componentsInChildren.Length != PolyCounts.Length)
			{
				_totalPolyCount = 0;
				_polyCounts = new int[componentsInChildren.Length];
				int num = 0;
				MeshFilter[] array = componentsInChildren;
				for (int i = 0; i < array.Length; i++)
				{
					int num2 = array[i].sharedMesh.triangles.Length / 3;
					_totalPolyCount += num2;
					PolyCounts[num++] = num2;
				}
			}
		}
	}
}
