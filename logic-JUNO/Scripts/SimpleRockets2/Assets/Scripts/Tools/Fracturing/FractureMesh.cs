using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using ModApi.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Tools.Fracturing
{
	public static class FractureMesh
	{
		public class FracturePiece
		{
			public List<Vector3> Normals { get; private set; }

			public TransformInfo TransformInfo { get; private set; }

			public List<int> Triangles { get; private set; }

			public List<Vector4> Uv { get; private set; }

			public List<Vector4> Uv2 { get; private set; }

			public List<Vector3> Vertices { get; private set; }

			public FracturePiece(List<int> triangles, List<Vector3> vertices, List<Vector4> uv, List<Vector4> uv2, List<Vector3> normals, TransformInfo transformInfo)
			{
				Triangles = triangles;
				Vertices = vertices;
				Uv = uv;
				Uv2 = uv2;
				Normals = normals;
				TransformInfo = transformInfo;
			}
		}

		public class TransformInfo
		{
			public Vector3 WorldPosition { get; set; }

			public Quaternion WorldRotation { get; set; }

			public Vector3 WorldScale { get; set; }
		}

		public const int VertsPerTri = 3;

		private const int IgnoreSelfLayer = 30;

		public static GameObject ConstructFromPiece(Transform parent, FracturePiece piece, Material material, bool createCollider, float minPieceBoundsRadius, float initialMaxAngularVelocity, float initialMaxVelocity)
		{
			Vector3? colliderWorldCenter;
			return ConstructFromPiece(parent, piece, material, createCollider, minPieceBoundsRadius, initialMaxAngularVelocity, initialMaxVelocity, out colliderWorldCenter);
		}

		public static GameObject ConstructFromPiece(Transform parent, FracturePiece piece, Material material, bool createCollider, float minPieceBoundsRadius, float initialMaxAngularVelocity, float initialMaxVelocity, out Vector3? colliderWorldCenter)
		{
			colliderWorldCenter = null;
			Mesh mesh = CreateMeshFromPiece(piece);
			if (mesh.bounds.extents.magnitude * piece.TransformInfo.WorldScale.magnitude < minPieceBoundsRadius)
			{
				return null;
			}
			Rigidbody rigidbody = AddBody(piece, parent, mesh, initialMaxVelocity, initialMaxAngularVelocity);
			MeshFilter filter = AddMeshRenderer(rigidbody.transform, mesh, material);
			if (createCollider)
			{
				AddCollider(filter, rigidbody, out colliderWorldCenter);
			}
			return rigidbody.gameObject;
		}

		public static List<FracturePiece> CreateMeshFracturePieces(Mesh mesh, int trisPerPiece, bool copyUvData, bool copyUv2Data, bool copyNormalData, TransformInfo transformInfo)
		{
			List<FracturePiece> list = new List<FracturePiece>();
			List<Vector4> list2 = new List<Vector4>();
			List<Vector4> list3 = new List<Vector4>();
			mesh.GetUVs(0, list2);
			mesh.GetUVs(1, list3);
			OrderedDictionary orderedDictionary = new OrderedDictionary();
			List<Vector4> list4 = new List<Vector4>();
			List<Vector4> list5 = new List<Vector4>();
			List<Vector3> list6 = new List<Vector3>();
			List<int> list7 = new List<int>();
			for (int i = 0; i < mesh.triangles.Length; i++)
			{
				int num = mesh.triangles[i];
				int item;
				if (!orderedDictionary.Contains(num))
				{
					item = orderedDictionary.Count;
					orderedDictionary.Add(num, mesh.vertices[num]);
					if (copyUvData)
					{
						try
						{
							list4.Add(list2[num]);
						}
						catch (Exception ex)
						{
							Debug.LogWarning("Could not copy uv data for " + mesh.name + ": " + ex.Message);
							copyUvData = false;
						}
					}
					if (copyUv2Data)
					{
						try
						{
							list5.Add(list3[num]);
						}
						catch (Exception ex2)
						{
							Debug.LogWarning("Could not copy uv2 data for " + mesh.name + ": " + ex2.Message);
							copyUv2Data = false;
						}
					}
					if (copyNormalData)
					{
						try
						{
							list6.Add(mesh.normals[num]);
						}
						catch (Exception ex3)
						{
							Debug.LogWarning("Could not copy normal data for " + mesh.name + ": " + ex3.Message);
							copyNormalData = false;
						}
					}
				}
				else
				{
					item = orderedDictionary.IndexOfKey(num);
				}
				list7.Add(item);
				if (list7.Count / 3 == trisPerPiece)
				{
					ClosePolyhedron(list7, orderedDictionary);
					list.Add(CreateFracturePiece(list7, orderedDictionary, list4, list5, list6, transformInfo));
					list7 = new List<int>();
					orderedDictionary = new OrderedDictionary();
					list4 = new List<Vector4>();
					list5 = new List<Vector4>();
					list6 = new List<Vector3>();
				}
			}
			if (list7.Count != 0)
			{
				list.Add(CreateFracturePiece(list7, orderedDictionary, list4, list5, list6, transformInfo));
			}
			return list;
		}

		public static TransformInfo CreateMeshTransformInfo(MeshFilter inspectorSourceMesh)
		{
			Transform transform = inspectorSourceMesh.transform;
			return new TransformInfo
			{
				WorldPosition = transform.position,
				WorldRotation = transform.rotation,
				WorldScale = transform.lossyScale
			};
		}

		public static GameObject ProcessMeshAndCreateObject(Action<GameObject, Vector3?> onPieceCreated, Mesh mesh, Material material, bool createColliders, int trisPerPiece, float minPieceBoundsRadius, float maxAngularSpinSpeed, float maxVelocity, bool copyUvData, bool copyUv2Data, bool copyNormalData, TransformInfo transformInfo)
		{
			List<FracturePiece> list = CreateMeshFracturePieces(mesh, trisPerPiece, copyUvData, copyUv2Data, copyNormalData, transformInfo);
			GameObject gameObject = new GameObject("FracturedMesh (" + mesh.name + ")");
			foreach (FracturePiece item in list)
			{
				Vector3? colliderWorldCenter;
				GameObject gameObject2 = ConstructFromPiece(gameObject.transform, item, material, createColliders, minPieceBoundsRadius, maxAngularSpinSpeed, maxVelocity, out colliderWorldCenter);
				if (gameObject2 != null)
				{
					onPieceCreated?.Invoke(gameObject2, colliderWorldCenter);
				}
			}
			if (gameObject.transform.childCount == 0)
			{
				UnityEngine.Object.Destroy(gameObject);
				gameObject = null;
			}
			return gameObject;
		}

		private static void ClosePolyhedron(List<int> triangleIndices, OrderedDictionary vertices)
		{
		}

		private static Rigidbody AddBody(FracturePiece piece, Transform parent, Mesh mesh, float initialMaxVelocity, float initialMaxAngularVelocity)
		{
			Vector3 vector = mesh.bounds.center - parent.position;
			float magnitude = vector.magnitude;
			Quaternion quaternion = Quaternion.Euler(UnityEngine.Random.Range(0, 180), UnityEngine.Random.Range(0, 180), UnityEngine.Random.Range(0, 180));
			float num = UnityEngine.Random.Range(0f, initialMaxVelocity);
			float num2 = UnityEngine.Random.Range(MathF.PI * -2f * initialMaxAngularVelocity, MathF.PI * 2f * initialMaxAngularVelocity);
			GameObject obj = new GameObject("FracturedBodyPiece")
			{
				layer = 30
			};
			Vector3 normalized = new Vector3(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f)).normalized;
			Vector3 vector2 = ((magnitude != 0f) ? (vector / magnitude) : normalized);
			Rigidbody rigidbody = obj.AddComponent<Rigidbody>();
			vector2 = quaternion * vector2;
			rigidbody.velocity = vector2 * num;
			rigidbody.angularVelocity = normalized * num2;
			rigidbody.drag = 0.2f;
			obj.transform.position = piece.TransformInfo.WorldPosition;
			obj.transform.localScale = piece.TransformInfo.WorldScale;
			obj.transform.rotation = piece.TransformInfo.WorldRotation;
			obj.transform.parent = parent;
			return rigidbody;
		}

		private static Collider AddCollider(MeshFilter filter, Rigidbody body, out Vector3? colliderWorldCenter)
		{
			Bounds bounds = filter.mesh.bounds;
			SphereCollider sphereCollider = body.gameObject.AddComponent<SphereCollider>();
			sphereCollider.radius = bounds.extents.magnitude;
			sphereCollider.center = bounds.center;
			colliderWorldCenter = sphereCollider.bounds.center;
			return sphereCollider;
		}

		private static FracturePiece CreateFracturePiece(List<int> triangles, OrderedDictionary vertices, List<Vector4> uv, List<Vector4> uv2, List<Vector3> normals, TransformInfo transformInfo)
		{
			List<Vector3> vertices2 = vertices.Values.Cast<Vector3>().ToList();
			return new FracturePiece(triangles, vertices2, uv, uv2, normals, transformInfo);
		}

		private static Mesh CreateMeshFromPiece(FracturePiece piece)
		{
			Mesh mesh = new Mesh();
			mesh.SetVertices(piece.Vertices);
			mesh.SetUVs(0, piece.Uv);
			mesh.SetUVs(1, piece.Uv2);
			mesh.SetNormals(piece.Normals);
			mesh.triangles = piece.Triangles.ToArray();
			if (mesh.normals.Length == 0)
			{
				mesh.RecalculateNormals();
			}
			return mesh;
		}

		private static MeshFilter AddMeshRenderer(Transform parent, Mesh mesh, Material material)
		{
			MeshFilter meshFilter = null;
			GameObject gameObject = new GameObject("FracturedMeshPiece");
			gameObject.transform.parent = parent;
			gameObject.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
			gameObject.transform.localScale = Vector3.one;
			meshFilter = gameObject.gameObject.AddComponent<MeshFilter>();
			meshFilter.mesh = mesh;
			gameObject.gameObject.AddComponent<MeshRenderer>().material = ((material != null) ? material : GetDefaultMaterial());
			return meshFilter;
		}

		private static Material GetDefaultMaterial()
		{
			return new Material(Shader.Find("Particles/Alpha Blended"));
		}
	}
}
