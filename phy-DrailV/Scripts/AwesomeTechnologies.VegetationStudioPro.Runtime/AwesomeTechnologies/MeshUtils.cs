using System;
using System.Collections.Generic;
using AwesomeTechnologies.External;
using AwesomeTechnologies.Shaders;
using AwesomeTechnologies.VegetationSystem;
using UnityEngine;

namespace AwesomeTechnologies
{
	public class MeshUtils
	{
		public static GameObject SelectMeshObject(GameObject go, LODLevel lodLevel)
		{
			return SelectNormalMesh(go, lodLevel);
		}

		public static Quaternion GetMeshRotation(GameObject go, LODLevel lodLevel)
		{
			GameObject gameObject = SelectMeshObject(go, lodLevel);
			if ((bool)gameObject)
			{
				return Quaternion.Inverse(Quaternion.identity) * gameObject.transform.rotation;
			}
			return Quaternion.identity;
		}

		public static int GetLODCount(GameObject go, IShaderController shaderController)
		{
			LODGroup componentInChildren = go.GetComponentInChildren<LODGroup>();
			if ((bool)componentInChildren)
			{
				LOD[] lODs = componentInChildren.GetLODs();
				int num = lODs.Length;
				Renderer[] renderers = lODs[lODs.Length - 1].renderers;
				foreach (Renderer renderer in renderers)
				{
					if (renderer is BillboardRenderer)
					{
						num--;
						break;
					}
					if (renderer is MeshRenderer && shaderController != null)
					{
						MeshRenderer meshRenderer = renderer as MeshRenderer;
						if (shaderController.MatchBillboardShader(meshRenderer.sharedMaterials))
						{
							num--;
							break;
						}
					}
				}
				return num;
			}
			return 1;
		}

		private static GameObject SelectNormalMesh(GameObject go, LODLevel lodLevel)
		{
			LODGroup componentInChildren = go.GetComponentInChildren<LODGroup>();
			if ((bool)componentInChildren)
			{
				LOD[] lODs = componentInChildren.GetLODs();
				int value = (int)lodLevel;
				value = Mathf.Clamp(value, 0, lODs.Length - 1);
				LOD lOD = lODs[value];
				if (lOD.renderers.Length != 0 && (bool)lOD.renderers[0].gameObject.GetComponent<BillboardRenderer>())
				{
					if (value <= 0)
					{
						return null;
					}
					lOD = lODs[value - 1];
				}
				if (lOD.renderers.Length == 0)
				{
					return null;
				}
				return lOD.renderers[0].gameObject;
			}
			MeshRenderer component = go.GetComponent<MeshRenderer>();
			if ((bool)component)
			{
				return component.gameObject;
			}
			component = go.GetComponentInChildren<MeshRenderer>();
			if ((bool)component)
			{
				return component.gameObject;
			}
			return null;
		}

		public static Bounds CalculateBoundsInstantiate(GameObject go)
		{
			if (!go)
			{
				return new Bounds(Vector3.zero, Vector3.one);
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(go);
			gameObject.transform.localScale = Vector3.one;
			gameObject.hideFlags = HideFlags.DontSave;
			Bounds result = CalculateBounds(gameObject);
			if (Application.isPlaying)
			{
				UnityEngine.Object.Destroy(gameObject);
				return result;
			}
			UnityEngine.Object.DestroyImmediate(gameObject);
			return result;
		}

		public static Bounds CalculateBounds(GameObject go)
		{
			Bounds result = new Bounds(go.transform.position, Vector3.zero);
			Renderer[] componentsInChildren = go.GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in componentsInChildren)
			{
				if (renderer is SkinnedMeshRenderer)
				{
					SkinnedMeshRenderer skinnedMeshRenderer = renderer as SkinnedMeshRenderer;
					Mesh mesh = new Mesh();
					skinnedMeshRenderer.BakeMesh(mesh);
					Vector3[] vertices = mesh.vertices;
					for (int j = 0; j <= vertices.Length - 1; j++)
					{
						vertices[j] = skinnedMeshRenderer.transform.TransformPoint(vertices[j]);
					}
					mesh.vertices = vertices;
					mesh.RecalculateBounds();
					Bounds bounds = mesh.bounds;
					result.Encapsulate(bounds);
				}
				else
				{
					result.Encapsulate(renderer.bounds);
				}
			}
			return result;
		}

		public static Mesh CreateBoxMesh(float length = 1f, float width = 1f, float height = 1f)
		{
			Mesh mesh = new Mesh();
			mesh.Clear();
			Vector3 vector = new Vector3((0f - length) * 0.5f, (0f - width) * 0.5f, height * 0.5f);
			Vector3 vector2 = new Vector3(length * 0.5f, (0f - width) * 0.5f, height * 0.5f);
			Vector3 vector3 = new Vector3(length * 0.5f, (0f - width) * 0.5f, (0f - height) * 0.5f);
			Vector3 vector4 = new Vector3((0f - length) * 0.5f, (0f - width) * 0.5f, (0f - height) * 0.5f);
			Vector3 vector5 = new Vector3((0f - length) * 0.5f, width * 0.5f, height * 0.5f);
			Vector3 vector6 = new Vector3(length * 0.5f, width * 0.5f, height * 0.5f);
			Vector3 vector7 = new Vector3(length * 0.5f, width * 0.5f, (0f - height) * 0.5f);
			Vector3 vector8 = new Vector3((0f - length) * 0.5f, width * 0.5f, (0f - height) * 0.5f);
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
			mesh.uv = uv;
			mesh.triangles = triangles;
			mesh.RecalculateBounds();
			return mesh;
		}

		public static Mesh CreateCapsuleMesh(float radius, float height)
		{
			int num = 24;
			if (num % 2 != 0)
			{
				num++;
			}
			int num2 = num + 1;
			float[] array = new float[num2];
			float[] array2 = new float[num2];
			float[] array3 = new float[num2];
			float[] array4 = new float[num2];
			float num3 = 0f;
			float num4 = 0f;
			for (int i = 0; i < num2; i++)
			{
				array[i] = Mathf.Sin(num3 * ((float)Math.PI / 180f));
				array2[i] = Mathf.Cos(num3 * ((float)Math.PI / 180f));
				array3[i] = Mathf.Cos(num4 * ((float)Math.PI / 180f));
				array4[i] = Mathf.Sin(num4 * ((float)Math.PI / 180f));
				num3 += 360f / (float)num;
				num4 += 180f / (float)num;
			}
			Vector3[] array5 = new Vector3[num2 * (num2 + 1)];
			Vector2[] array6 = new Vector2[array5.Length];
			int num5 = 0;
			float num6 = (height - radius * 2f) * 0.5f;
			if (num6 < 0f)
			{
				num6 = 0f;
			}
			float num7 = 1f / (float)(num2 - 1);
			int num8 = Mathf.CeilToInt((float)num2 * 0.5f);
			for (int j = 0; j < num8; j++)
			{
				for (int k = 0; k < num2; k++)
				{
					array5[num5] = new Vector3(array[k] * array4[j], array3[j], array2[k] * array4[j]) * radius;
					array5[num5].y = num6 + array5[num5].y;
					float x = 1f - num7 * (float)k;
					float y = (array5[num5].y + height * 0.5f) / height;
					array6[num5] = new Vector2(x, y);
					num5++;
				}
			}
			for (int l = Mathf.FloorToInt((float)num2 * 0.5f); l < num2; l++)
			{
				for (int m = 0; m < num2; m++)
				{
					array5[num5] = new Vector3(array[m] * array4[l], array3[l], array2[m] * array4[l]) * radius;
					array5[num5].y = 0f - num6 + array5[num5].y;
					float x = 1f - num7 * (float)m;
					float y = (array5[num5].y + height * 0.5f) / height;
					array6[num5] = new Vector2(x, y);
					num5++;
				}
			}
			int[] array7 = new int[num * (num + 1) * 2 * 3];
			int n = 0;
			int num9 = 0;
			for (; n < num + 1; n++)
			{
				int num10 = 0;
				while (num10 < num)
				{
					array7[num9] = n * (num + 1) + num10;
					array7[num9 + 1] = (n + 1) * (num + 1) + num10;
					array7[num9 + 2] = (n + 1) * (num + 1) + num10 + 1;
					array7[num9 + 3] = n * (num + 1) + num10 + 1;
					array7[num9 + 4] = n * (num + 1) + num10;
					array7[num9 + 5] = (n + 1) * (num + 1) + num10 + 1;
					num10++;
					num9 += 6;
				}
			}
			Mesh mesh = new Mesh();
			mesh.Clear();
			mesh.name = "ProceduralCapsule";
			mesh.vertices = array5;
			mesh.uv = array6;
			mesh.triangles = array7;
			mesh.RecalculateBounds();
			mesh.RecalculateNormals();
			return mesh;
		}

		public static Mesh CreateSphereMesh(float radius = 1f)
		{
			Mesh mesh = new Mesh();
			mesh.Clear();
			int num = 24;
			int num2 = 16;
			Vector3[] array = new Vector3[(num + 1) * num2 + 2];
			float num3 = (float)Math.PI;
			float num4 = num3 * 2f;
			array[0] = Vector3.up * radius;
			for (int i = 0; i < num2; i++)
			{
				float f = num3 * (float)(i + 1) / (float)(num2 + 1);
				float num5 = Mathf.Sin(f);
				float y = Mathf.Cos(f);
				for (int j = 0; j <= num; j++)
				{
					float f2 = num4 * (float)((j != num) ? j : 0) / (float)num;
					float num6 = Mathf.Sin(f2);
					float num7 = Mathf.Cos(f2);
					array[j + i * (num + 1) + 1] = new Vector3(num5 * num7, y, num5 * num6) * radius;
				}
			}
			array[array.Length - 1] = Vector3.up * (0f - radius);
			Vector3[] array2 = new Vector3[array.Length];
			for (int k = 0; k < array.Length; k++)
			{
				array2[k] = array[k].normalized;
			}
			Vector2[] array3 = new Vector2[array.Length];
			array3[0] = Vector2.up;
			array3[array3.Length - 1] = Vector2.zero;
			for (int l = 0; l < num2; l++)
			{
				for (int m = 0; m <= num; m++)
				{
					array3[m + l * (num + 1) + 1] = new Vector2((float)m / (float)num, 1f - (float)(l + 1) / (float)(num2 + 1));
				}
			}
			int[] array4 = new int[array.Length * 2 * 3];
			int num8 = 0;
			for (int n = 0; n < num; n++)
			{
				array4[num8++] = n + 2;
				array4[num8++] = n + 1;
				array4[num8++] = 0;
			}
			for (int num9 = 0; num9 < num2 - 1; num9++)
			{
				for (int num10 = 0; num10 < num; num10++)
				{
					int num11 = num10 + num9 * (num + 1) + 1;
					int num12 = num11 + num + 1;
					array4[num8++] = num11;
					array4[num8++] = num11 + 1;
					array4[num8++] = num12 + 1;
					array4[num8++] = num11;
					array4[num8++] = num12 + 1;
					array4[num8++] = num12;
				}
			}
			for (int num13 = 0; num13 < num; num13++)
			{
				array4[num8++] = array.Length - 1;
				array4[num8++] = array.Length - (num13 + 2) - 1;
				array4[num8++] = array.Length - (num13 + 1) - 1;
			}
			mesh.vertices = array;
			mesh.normals = array2;
			mesh.uv = array3;
			mesh.triangles = array4;
			mesh.RecalculateBounds();
			return mesh;
		}

		public static Mesh ExtrudeMeshFromPolygon(Vector3[] polygonPoints, float yExtent)
		{
			Vector2[] array = new Vector2[polygonPoints.Length];
			for (int i = 0; i < polygonPoints.Length; i++)
			{
				array[i] = new Vector2(polygonPoints[i].x, polygonPoints[i].z);
			}
			int[] array2 = new Triangulator(array).Triangulate();
			List<int> list = new List<int>();
			for (int j = 0; j < array2.Length; j += 3)
			{
				list.Add(array2[j + 2]);
				list.Add(array2[j + 1]);
				list.Add(array2[j]);
			}
			int num = polygonPoints.Length;
			for (int k = 0; k < array2.Length; k += 3)
			{
				list.Add(array2[k] + num);
				list.Add(array2[k + 1] + num);
				list.Add(array2[k + 2] + num);
			}
			for (int l = 0; l < polygonPoints.Length - 1; l++)
			{
				list.Add(l);
				list.Add(l + num);
				list.Add(l + 1);
				list.Add(l + num);
				list.Add(l + 1 + num);
				list.Add(l + 1);
			}
			list.Add(num - 1);
			list.Add(num - 1 + num);
			list.Add(0);
			list.Add(num - 1 + num);
			list.Add(num);
			list.Add(0);
			List<Vector3> list2 = new List<Vector3>();
			for (int m = 0; m < polygonPoints.Length; m++)
			{
				list2.Add(new Vector3(polygonPoints[m].x, polygonPoints[m].y - yExtent, polygonPoints[m].z));
			}
			for (int n = 0; n < polygonPoints.Length; n++)
			{
				list2.Add(new Vector3(polygonPoints[n].x, polygonPoints[n].y + yExtent, polygonPoints[n].z));
			}
			Mesh mesh = new Mesh();
			mesh.vertices = list2.ToArray();
			mesh.triangles = list.ToArray();
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
			return mesh;
		}
	}
}
