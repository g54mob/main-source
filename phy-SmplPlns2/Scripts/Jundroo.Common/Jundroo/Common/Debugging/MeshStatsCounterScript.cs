using UnityEngine;

namespace Jundroo.Common.Debugging
{
	[ExecuteAlways]
	public class MeshStatsCounterScript : MonoBehaviour
	{
		[SerializeField]
		private int totalTriangles;

		[SerializeField]
		private int totalVertices;

		[SerializeField]
		private bool onlyCountActive = true;

		[ContextMenu("Update Stats")]
		public void UpdateMeshStats()
		{
			CalculateMeshStats();
			Debug.Log($"Mesh Stats Updated: {totalVertices} vertices, {totalTriangles} triangles");
		}

		private void CalculateMeshStats()
		{
			totalVertices = 0;
			totalTriangles = 0;
			MeshFilter[] componentsInChildren = GetComponentsInChildren<MeshFilter>();
			foreach (MeshFilter meshFilter in componentsInChildren)
			{
				if (meshFilter.sharedMesh != null)
				{
					totalVertices += meshFilter.sharedMesh.vertexCount;
					totalTriangles += meshFilter.sharedMesh.triangles.Length / 3;
				}
			}
		}

		private void OnValidate()
		{
			CalculateMeshStats();
		}
	}
}
