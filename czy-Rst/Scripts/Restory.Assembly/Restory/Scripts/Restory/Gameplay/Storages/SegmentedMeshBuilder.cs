using UnityEngine;

namespace Restory.Scripts.Restory.Gameplay.Storages
{
	public class SegmentedMeshBuilder : MonoBehaviour
	{
		[SerializeField]
		private MeshFilter meshFilter;

		[SerializeField]
		private MeshCollider meshCollider;

		[SerializeField]
		private LineRenderer sourceLine;

		[SerializeField]
		private float meshHeight = 0.3f;

		private Mesh mesh;

		private void Start()
		{
			BuildMesh();
		}

		private void BuildMesh()
		{
			if (sourceLine.positionCount < 2)
			{
				Debug.LogError("Source LineRenderer has fewer than 2 points");
				return;
			}
			int positionCount = sourceLine.positionCount;
			Vector3[] array = new Vector3[positionCount];
			sourceLine.GetPositions(array);
			Vector3[] array2 = new Vector3[positionCount * 2];
			int[] array3 = new int[(positionCount - 1) * 6];
			for (int i = 0; i < positionCount; i++)
			{
				array2[i + positionCount] = (array2[i] = array[i]) + Vector3.up * meshHeight;
			}
			int num = 0;
			for (int j = 0; j < positionCount - 1; j++)
			{
				int num2 = j;
				int num3 = j + 1;
				int num4 = j + positionCount;
				int num5 = j + 1 + positionCount;
				array3[num++] = num2;
				array3[num++] = num4;
				array3[num++] = num3;
				array3[num++] = num3;
				array3[num++] = num4;
				array3[num++] = num5;
			}
			if (!mesh)
			{
				mesh = new Mesh
				{
					name = "SegmentedMesh"
				};
			}
			else
			{
				mesh.Clear();
			}
			mesh.vertices = array2;
			mesh.triangles = array3;
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
			meshFilter.sharedMesh = mesh;
			meshCollider.sharedMesh = mesh;
		}
	}
}
