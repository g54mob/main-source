using UnityEngine;

namespace TH20
{
	[ExecuteInEditMode]
	public class ShallowWaves : MonoBehaviour
	{
		[SerializeField]
		private MeshFilter _meshFilter;

		[SerializeField]
		private Transform[] _waveTransforms;

		[SerializeField]
		private float _waterPlaneHeight;

		[SerializeField]
		private float _fadeOutFromEdgeDistance;

		private Mesh _mesh;

		public void Start()
		{
			_mesh = new Mesh();
			_meshFilter.sharedMesh = _mesh;
			UpdateMesh();
		}

		private void UpdateMesh()
		{
			_mesh.Clear();
			int childCount = base.transform.childCount;
			Vector3[] array = new Vector3[childCount * 2];
			Vector3[] array2 = new Vector3[childCount * 2];
			Color[] array3 = new Color[childCount * 2];
			Vector2[] array4 = new Vector2[childCount * 2];
			int[] array5 = new int[(childCount - 1) * 6];
			Plane plane = new Plane(Vector3.up, new Vector3(0f, _waterPlaneHeight, 0f));
			float num = 0f;
			for (int i = 0; i < childCount; i++)
			{
				Transform child = base.transform.GetChild(i);
				float num2 = 4f * child.localScale.z;
				Ray ray = new Ray(child.localPosition, child.forward);
				Vector3 vector = plane.ClosestPointOnPlane(ray.origin);
				float num3 = Vector3.Distance(ray.origin, vector);
				float num4 = Mathf.Sqrt(num2 * num2 - num3 * num3);
				Vector3 direction = ray.direction;
				direction.y = 0f;
				direction = direction.normalized;
				array[2 * i] = ray.origin;
				array[2 * i + 1] = vector + direction * num4;
				array2[2 * i] = child.up;
				array2[2 * i + 1] = child.up;
				if (i > 0)
				{
					num += Vector3.Distance(base.transform.GetChild(i - 1).localPosition, ray.origin);
				}
				Mathf.Clamp01(num / _fadeOutFromEdgeDistance);
				array3[2 * i] = new Color(1f, 1f, 1f, 1f);
				array3[2 * i + 1] = new Color(1f, 1f, 1f, 1f);
				array4[2 * i] = new Vector2(num * 0.01f, 1f);
				array4[2 * i + 1] = new Vector2(num * 0.01f, 0f);
			}
			if (childCount > 0)
			{
				int num5 = 0;
				array3[2 * num5] = new Color(1f, 1f, 1f, 0f);
				array3[2 * num5 + 1] = new Color(1f, 1f, 1f, 0f);
				num5 = childCount - 1;
				array3[2 * num5] = new Color(1f, 1f, 1f, 0f);
				array3[2 * num5 + 1] = new Color(1f, 1f, 1f, 0f);
			}
			for (int j = 0; j < childCount - 1; j++)
			{
				array5[6 * j] = 2 * j;
				array5[6 * j + 1] = 2 * j + 3;
				array5[6 * j + 2] = 2 * j + 1;
				array5[6 * j + 3] = 2 * j;
				array5[6 * j + 4] = 2 * j + 2;
				array5[6 * j + 5] = 2 * j + 3;
			}
			_mesh.vertices = array;
			_mesh.normals = array2;
			_mesh.colors = array3;
			_mesh.triangles = array5;
			_mesh.uv = array4;
			_mesh.UploadMeshData(markNoLongerReadable: false);
		}
	}
}
