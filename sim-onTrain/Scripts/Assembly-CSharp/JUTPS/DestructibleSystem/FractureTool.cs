using System.Collections.Generic;
using UnityEngine;

namespace JUTPS.DestructibleSystem
{
	[AddComponentMenu("JU TPS/Tools/Fracture Tool")]
	public class FractureTool : MonoBehaviour
	{
		public class PartMesh
		{
			private List<Vector3> _Verticies = new List<Vector3>();

			private List<Vector3> _Normals = new List<Vector3>();

			private List<List<int>> _Triangles = new List<List<int>>();

			private List<Vector2> _UVs = new List<Vector2>();

			public Vector3[] Vertices;

			public Vector3[] Normals;

			public int[][] Triangles;

			public Vector2[] UV;

			public GameObject NewFracture;

			public Bounds Bounds;

			public void AddTriangle(int submesh, Vector3 vert1, Vector3 vert2, Vector3 vert3, Vector3 normal1, Vector3 normal2, Vector3 normal3, Vector2 uv1, Vector2 uv2, Vector2 uv3)
			{
				if (_Triangles.Count - 1 < submesh)
				{
					_Triangles.Add(new List<int>());
				}
				_Triangles[submesh].Add(_Verticies.Count);
				_Verticies.Add(vert1);
				_Triangles[submesh].Add(_Verticies.Count);
				_Verticies.Add(vert2);
				_Triangles[submesh].Add(_Verticies.Count);
				_Verticies.Add(vert3);
				_Normals.Add(normal1);
				_Normals.Add(normal2);
				_Normals.Add(normal3);
				_UVs.Add(uv1);
				_UVs.Add(uv2);
				_UVs.Add(uv3);
				Bounds.min = Vector3.Min(Bounds.min, vert1);
				Bounds.min = Vector3.Min(Bounds.min, vert2);
				Bounds.min = Vector3.Min(Bounds.min, vert3);
				Bounds.max = Vector3.Min(Bounds.max, vert1);
				Bounds.max = Vector3.Min(Bounds.max, vert2);
				Bounds.max = Vector3.Min(Bounds.max, vert3);
			}

			public void FillArrays()
			{
				Vertices = _Verticies.ToArray();
				Normals = _Normals.ToArray();
				UV = _UVs.ToArray();
				Triangles = new int[_Triangles.Count][];
				for (int i = 0; i < _Triangles.Count; i++)
				{
					Triangles[i] = _Triangles[i].ToArray();
				}
			}

			public void MakeGameobject(FractureTool original)
			{
				NewFracture = new GameObject(original.name);
				NewFracture.transform.position = original.transform.position;
				NewFracture.transform.rotation = original.transform.rotation;
				NewFracture.transform.localScale = original.transform.localScale;
				NewFracture.transform.SetParent(original.NewFracturedObject.transform);
				Mesh mesh = new Mesh();
				mesh.name = original.GetComponent<MeshFilter>().sharedMesh.name;
				mesh.vertices = Vertices;
				mesh.normals = Normals;
				mesh.uv = UV;
				for (int i = 0; i < Triangles.Length; i++)
				{
					mesh.SetTriangles(Triangles[i], i, calculateBounds: true);
				}
				Bounds = mesh.bounds;
				NewFracture.AddComponent<MeshRenderer>().materials = original.GetComponent<MeshRenderer>().sharedMaterials;
				NewFracture.AddComponent<MeshFilter>().mesh = mesh;
				NewFracture.AddComponent<MeshCollider>().convex = true;
				NewFracture.AddComponent<Rigidbody>();
			}
		}

		private bool edgeSet;

		private Vector3 edgeVertex = Vector3.zero;

		private Vector2 edgeUV = Vector2.zero;

		private Plane edgePlane;

		[Range(2f, 15f)]
		[Tooltip("Number of fractures. Numbers far above 10 can crash your Unity")]
		public int Fractures = 2;

		[Range(0f, 0.4f)]
		[Tooltip("Minimum fracture size, this excludes very small invoices that are not needed")]
		public float MinFracturedSize = 0.2f;

		[SerializeField]
		[Tooltip("Reference of the new fractured GameObject generated")]
		private GameObject NewFracturedObject;

		public static string PathToSave;

		public void DestroyMesh()
		{
			Mesh sharedMesh = GetComponent<MeshFilter>().sharedMesh;
			sharedMesh.RecalculateBounds();
			List<PartMesh> list = new List<PartMesh>();
			List<PartMesh> list2 = new List<PartMesh>();
			if (NewFracturedObject == null)
			{
				NewFracturedObject = new GameObject(base.gameObject.name + " Fractured");
				NewFracturedObject.transform.position = base.transform.position;
			}
			else
			{
				Object.DestroyImmediate(NewFracturedObject);
				NewFracturedObject = new GameObject(base.gameObject.name + " Fractured");
				NewFracturedObject.transform.position = base.transform.position;
			}
			PartMesh partMesh = new PartMesh
			{
				UV = sharedMesh.uv,
				Vertices = sharedMesh.vertices,
				Normals = sharedMesh.normals,
				Triangles = new int[sharedMesh.subMeshCount][],
				Bounds = sharedMesh.bounds
			};
			for (int i = 0; i < sharedMesh.subMeshCount; i++)
			{
				partMesh.Triangles[i] = sharedMesh.GetTriangles(i);
			}
			list.Add(partMesh);
			for (int j = 0; j < Fractures; j++)
			{
				for (int k = 0; k < list.Count; k++)
				{
					Bounds bounds = list[k].Bounds;
					bounds.Expand(0.15f);
					Plane plane = new Plane(Random.onUnitSphere, new Vector3(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), Random.Range(bounds.min.z, bounds.max.z)));
					list2.Add(GenerateMesh(list[k], plane, left: true));
					list2.Add(GenerateMesh(list[k], plane, left: false));
				}
				list = new List<PartMesh>(list2);
				list2.Clear();
			}
			for (int l = 0; l < list.Count; l++)
			{
				list[l].MakeGameobject(this);
			}
			DestroySmallFractures();
		}

		private PartMesh GenerateMesh(PartMesh original, Plane plane, bool left)
		{
			PartMesh partMesh = new PartMesh();
			Ray ray = default(Ray);
			Ray ray2 = default(Ray);
			for (int i = 0; i < original.Triangles.Length; i++)
			{
				int[] array = original.Triangles[i];
				edgeSet = false;
				for (int j = 0; j < array.Length; j += 3)
				{
					bool flag = plane.GetSide(original.Vertices[array[j]]) == left;
					bool flag2 = plane.GetSide(original.Vertices[array[j + 1]]) == left;
					bool flag3 = plane.GetSide(original.Vertices[array[j + 2]]) == left;
					int num = (flag ? 1 : 0) + (flag2 ? 1 : 0) + (flag3 ? 1 : 0);
					switch (num)
					{
					case 3:
						partMesh.AddTriangle(i, original.Vertices[array[j]], original.Vertices[array[j + 1]], original.Vertices[array[j + 2]], original.Normals[array[j]], original.Normals[array[j + 1]], original.Normals[array[j + 2]], original.UV[array[j]], original.UV[array[j + 1]], original.UV[array[j + 2]]);
						continue;
					case 0:
						continue;
					}
					int num2 = ((flag2 != flag3) ? ((flag == flag3) ? 1 : 2) : 0);
					ray.origin = original.Vertices[array[j + num2]];
					Vector3 vector = (ray.direction = original.Vertices[array[j + (num2 + 1) % 3]] - original.Vertices[array[j + num2]]);
					plane.Raycast(ray, out var enter);
					float t = enter / vector.magnitude;
					ray2.origin = original.Vertices[array[j + num2]];
					Vector3 vector3 = (ray2.direction = original.Vertices[array[j + (num2 + 2) % 3]] - original.Vertices[array[j + num2]]);
					plane.Raycast(ray2, out var enter2);
					float t2 = enter2 / vector3.magnitude;
					AddEdge(i, partMesh, left ? (plane.normal * -1f) : plane.normal, ray.origin + ray.direction.normalized * enter, ray2.origin + ray2.direction.normalized * enter2, Vector2.Lerp(original.UV[array[j + num2]], original.UV[array[j + (num2 + 1) % 3]], t), Vector2.Lerp(original.UV[array[j + num2]], original.UV[array[j + (num2 + 2) % 3]], t2));
					switch (num)
					{
					case 1:
						partMesh.AddTriangle(i, original.Vertices[array[j + num2]], ray.origin + ray.direction.normalized * enter, ray2.origin + ray2.direction.normalized * enter2, original.Normals[array[j + num2]], Vector3.Lerp(original.Normals[array[j + num2]], original.Normals[array[j + (num2 + 1) % 3]], t), Vector3.Lerp(original.Normals[array[j + num2]], original.Normals[array[j + (num2 + 2) % 3]], t2), original.UV[array[j + num2]], Vector2.Lerp(original.UV[array[j + num2]], original.UV[array[j + (num2 + 1) % 3]], t), Vector2.Lerp(original.UV[array[j + num2]], original.UV[array[j + (num2 + 2) % 3]], t2));
						break;
					case 2:
						partMesh.AddTriangle(i, ray.origin + ray.direction.normalized * enter, original.Vertices[array[j + (num2 + 1) % 3]], original.Vertices[array[j + (num2 + 2) % 3]], Vector3.Lerp(original.Normals[array[j + num2]], original.Normals[array[j + (num2 + 1) % 3]], t), original.Normals[array[j + (num2 + 1) % 3]], original.Normals[array[j + (num2 + 2) % 3]], Vector2.Lerp(original.UV[array[j + num2]], original.UV[array[j + (num2 + 1) % 3]], t), original.UV[array[j + (num2 + 1) % 3]], original.UV[array[j + (num2 + 2) % 3]]);
						partMesh.AddTriangle(i, ray.origin + ray.direction.normalized * enter, original.Vertices[array[j + (num2 + 2) % 3]], ray2.origin + ray2.direction.normalized * enter2, Vector3.Lerp(original.Normals[array[j + num2]], original.Normals[array[j + (num2 + 1) % 3]], t), original.Normals[array[j + (num2 + 2) % 3]], Vector3.Lerp(original.Normals[array[j + num2]], original.Normals[array[j + (num2 + 2) % 3]], t2), Vector2.Lerp(original.UV[array[j + num2]], original.UV[array[j + (num2 + 1) % 3]], t), original.UV[array[j + (num2 + 2) % 3]], Vector2.Lerp(original.UV[array[j + num2]], original.UV[array[j + (num2 + 2) % 3]], t2));
						break;
					}
				}
			}
			partMesh.FillArrays();
			return partMesh;
		}

		private void AddEdge(int subMesh, PartMesh partMesh, Vector3 normal, Vector3 vertex1, Vector3 vertex2, Vector2 uv1, Vector2 uv2)
		{
			if (!edgeSet)
			{
				edgeSet = true;
				edgeVertex = vertex1;
				edgeUV = uv1;
			}
			else
			{
				edgePlane.Set3Points(edgeVertex, vertex1, vertex2);
				partMesh.AddTriangle(subMesh, edgeVertex, edgePlane.GetSide(edgeVertex + normal) ? vertex1 : vertex2, edgePlane.GetSide(edgeVertex + normal) ? vertex2 : vertex1, normal, normal, normal, edgeUV, uv1, uv2);
			}
		}

		public void DestroySmallFractures()
		{
			for (int num = NewFracturedObject.transform.childCount - 1; num >= 0; num--)
			{
				GameObject gameObject = NewFracturedObject.transform.GetChild(num).gameObject;
				gameObject.GetComponent<MeshFilter>().sharedMesh.RecalculateBounds();
				if (gameObject.GetComponent<MeshFilter>().sharedMesh.bounds.size.x < MinFracturedSize && gameObject.GetComponent<MeshFilter>().sharedMesh.bounds.size.y < MinFracturedSize && gameObject.GetComponent<MeshFilter>().sharedMesh.bounds.size.z < MinFracturedSize)
				{
					Object.DestroyImmediate(gameObject);
					MonoBehaviour.print("Destroyed a small fracture for optimization");
				}
			}
		}
	}
}
