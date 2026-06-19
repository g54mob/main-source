using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace TH20
{
	public static class MeshUtils
	{
		private static List<Renderer> _renderersCached = new List<Renderer>(32);

		public static GameObject CreateStaticMeshObject()
		{
			GameObject gameObject = new GameObject();
			gameObject.AddComponent<MeshFilter>();
			gameObject.AddComponent<MeshRenderer>();
			return gameObject;
		}

		public static bool SetStaticMeshFromPrefab(GameObject obj, GameObject prefab)
		{
			if (obj != null && prefab != null)
			{
				MeshFilter component = obj.GetComponent<MeshFilter>();
				MeshRenderer component2 = obj.GetComponent<MeshRenderer>();
				MeshFilter componentInChildren = prefab.GetComponentInChildren<MeshFilter>();
				MeshRenderer componentInChildren2 = prefab.GetComponentInChildren<MeshRenderer>();
				if ((bool)component && (bool)component2 && (bool)componentInChildren && (bool)componentInChildren2)
				{
					MeshRandomizer componentInChildren3 = prefab.GetComponentInChildren<MeshRandomizer>();
					Mesh sharedMesh = ((componentInChildren3 != null) ? componentInChildren3.GetMesh() : componentInChildren.sharedMesh);
					component.sharedMesh = sharedMesh;
					component2.sharedMaterials = componentInChildren2.sharedMaterials;
					component2.shadowCastingMode = ShadowCastingMode.TwoSided;
					obj.layer = prefab.layer;
					return true;
				}
			}
			return false;
		}

		public static void GetGameObjectMaterials(GameObject gameObject, ref List<Material[]> materials)
		{
			Renderer[] componentsInChildren = gameObject.GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in componentsInChildren)
			{
				materials.Add(renderer.sharedMaterials);
			}
		}

		public static void SetGameObjectMaterials(GameObject gameObject, ref List<Material[]> materials)
		{
			int num = 0;
			_renderersCached.Clear();
			gameObject.GetComponentsInChildren(_renderersCached);
			foreach (Renderer item in _renderersCached)
			{
				if (num >= materials.Count)
				{
					break;
				}
				item.materials = materials[num++];
			}
			_renderersCached.Clear();
		}

		public static Mesh CreatePlaneMesh()
		{
			Mesh mesh = new Mesh();
			mesh.vertices = new Vector3[4]
			{
				new Vector3(-0.5f, 0.5f),
				new Vector3(0.5f, 0.5f),
				new Vector3(0.5f, -0.5f),
				new Vector3(-0.5f, -0.5f)
			};
			mesh.normals = new Vector3[4]
			{
				new Vector3(0f, 0f, -1f),
				new Vector3(0f, 0f, -1f),
				new Vector3(0f, 0f, -1f),
				new Vector3(0f, 0f, -1f)
			};
			mesh.triangles = new int[6] { 0, 1, 2, 0, 2, 3 };
			mesh.uv = new Vector2[4]
			{
				new Vector2(0f, 1f),
				new Vector2(1f, 1f),
				new Vector2(1f, 0f),
				new Vector2(0f, 0f)
			};
			mesh.RecalculateBounds();
			mesh.UploadMeshData(markNoLongerReadable: true);
			return mesh;
		}

		public static Mesh CreateCubeMesh(Vector3 dimensions)
		{
			Mesh mesh = new Mesh();
			float x = dimensions.x;
			float y = dimensions.y;
			float z = dimensions.z;
			Vector3 vector = new Vector3((0f - z) * 0.5f, (0f - x) * 0.5f, y * 0.5f);
			Vector3 vector2 = new Vector3(z * 0.5f, (0f - x) * 0.5f, y * 0.5f);
			Vector3 vector3 = new Vector3(z * 0.5f, (0f - x) * 0.5f, (0f - y) * 0.5f);
			Vector3 vector4 = new Vector3((0f - z) * 0.5f, (0f - x) * 0.5f, (0f - y) * 0.5f);
			Vector3 vector5 = new Vector3((0f - z) * 0.5f, x * 0.5f, y * 0.5f);
			Vector3 vector6 = new Vector3(z * 0.5f, x * 0.5f, y * 0.5f);
			Vector3 vector7 = new Vector3(z * 0.5f, x * 0.5f, (0f - y) * 0.5f);
			Vector3 vector8 = new Vector3((0f - z) * 0.5f, x * 0.5f, (0f - y) * 0.5f);
			Vector3[] vertices = new Vector3[24]
			{
				vector, vector2, vector3, vector4, vector8, vector5, vector, vector4, vector5, vector6,
				vector2, vector, vector7, vector8, vector4, vector3, vector6, vector7, vector3, vector2,
				vector8, vector7, vector6, vector5
			};
			Vector3 up = Vector3.up;
			Vector3 down = Vector3.down;
			Vector3 forward = Vector3.forward;
			Vector3 back = Vector3.back;
			Vector3 left = Vector3.left;
			Vector3 right = Vector3.right;
			Vector3[] normals = new Vector3[24]
			{
				down, down, down, down, left, left, left, left, forward, forward,
				forward, forward, back, back, back, back, right, right, right, right,
				up, up, up, up
			};
			Vector2 vector9 = new Vector2(0f, 0f);
			Vector2 vector10 = new Vector2(1f, 0f);
			Vector2 vector11 = new Vector2(0f, 1f);
			Vector2 vector12 = new Vector2(1f, 1f);
			Vector2[] uv = new Vector2[24]
			{
				vector12, vector11, vector9, vector10, vector12, vector11, vector9, vector10, vector12, vector11,
				vector9, vector10, vector12, vector11, vector9, vector10, vector12, vector11, vector9, vector10,
				vector12, vector11, vector9, vector10
			};
			int[] triangles = new int[36]
			{
				3, 1, 0, 3, 2, 1, 7, 5, 4, 7,
				6, 5, 11, 9, 8, 11, 10, 9, 15, 13,
				12, 15, 14, 13, 19, 17, 16, 19, 18, 17,
				23, 21, 20, 23, 22, 21
			};
			mesh.vertices = vertices;
			mesh.normals = normals;
			mesh.triangles = triangles;
			mesh.uv = uv;
			mesh.RecalculateBounds();
			return mesh;
		}

		public static void RecalculateTangents(this Mesh mesh)
		{
			int[] triangles = mesh.triangles;
			Vector3[] vertices = mesh.vertices;
			Vector2[] uv = mesh.uv;
			Vector3[] normals = mesh.normals;
			int num = triangles.Length;
			int num2 = vertices.Length;
			Vector3[] array = new Vector3[num2];
			Vector3[] array2 = new Vector3[num2];
			Vector4[] array3 = new Vector4[num2];
			for (long num3 = 0L; num3 < num; num3 += 3)
			{
				long num4 = triangles[num3];
				long num5 = triangles[num3 + 1];
				long num6 = triangles[num3 + 2];
				Vector3 vector = vertices[num4];
				Vector3 vector2 = vertices[num5];
				Vector3 vector3 = vertices[num6];
				Vector2 vector4 = uv[num4];
				Vector2 vector5 = uv[num5];
				Vector2 vector6 = uv[num6];
				float num7 = vector2.x - vector.x;
				float num8 = vector3.x - vector.x;
				float num9 = vector2.y - vector.y;
				float num10 = vector3.y - vector.y;
				float num11 = vector2.z - vector.z;
				float num12 = vector3.z - vector.z;
				float num13 = vector5.x - vector4.x;
				float num14 = vector6.x - vector4.x;
				float num15 = vector5.y - vector4.y;
				float num16 = vector6.y - vector4.y;
				float num17 = 1f / (num13 * num16 - num14 * num15);
				Vector3 vector7 = new Vector3((num16 * num7 - num15 * num8) * num17, (num16 * num9 - num15 * num10) * num17, (num16 * num11 - num15 * num12) * num17);
				Vector3 vector8 = new Vector3((num13 * num8 - num14 * num7) * num17, (num13 * num10 - num14 * num9) * num17, (num13 * num12 - num14 * num11) * num17);
				array[num4] += vector7;
				array[num5] += vector7;
				array[num6] += vector7;
				array2[num4] += vector8;
				array2[num5] += vector8;
				array2[num6] += vector8;
			}
			for (long num18 = 0L; num18 < num2; num18++)
			{
				Vector3 normal = normals[num18];
				Vector3 tangent = array[num18];
				Vector3.OrthoNormalize(ref normal, ref tangent);
				array3[num18].x = tangent.x;
				array3[num18].y = tangent.y;
				array3[num18].z = tangent.z;
				array3[num18].w = ((Vector3.Dot(Vector3.Cross(normal, tangent), array2[num18]) < 0f) ? (-1f) : 1f);
			}
			mesh.tangents = array3;
		}

		public static Bounds RenderBounds(this GameObject gameObject)
		{
			Renderer[] componentsInChildren = gameObject.GetComponentsInChildren<Renderer>();
			int num = componentsInChildren.Length;
			Bounds result = ((num == 0) ? default(Bounds) : componentsInChildren[0].bounds);
			for (int i = 1; i < num; i++)
			{
				result.Encapsulate(componentsInChildren[i].bounds);
			}
			return result;
		}
	}
}
