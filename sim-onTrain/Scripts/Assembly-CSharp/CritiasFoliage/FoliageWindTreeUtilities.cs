using System;
using System.Collections.Generic;
using UnityEngine;

namespace CritiasFoliage
{
	public class FoliageWindTreeUtilities
	{
		public static int[] m_SystemQuadTriangles = new int[6] { 0, 1, 2, 1, 0, 3 };

		public static Vector3[] m_SystemQuadVertices = new Vector3[4]
		{
			new Vector3(-0.5f, -0.5f, 0f),
			new Vector3(0.5f, 0.5f, 0f),
			new Vector3(0.5f, -0.5f, 0f),
			new Vector3(-0.5f, 0.5f, 0f)
		};

		public static Vector3[] m_SystemQuadNormals = new Vector3[4]
		{
			new Vector3(0f, 0f, -1f),
			new Vector3(0f, 0f, -1f),
			new Vector3(0f, 0f, -1f),
			new Vector3(0f, 0f, -1f)
		};

		public static Vector4[] m_SystemQuadTangents = new Vector4[4]
		{
			new Vector4(1f, 0f, 0f, -1f),
			new Vector4(1f, 0f, 0f, -1f),
			new Vector4(1f, 0f, 0f, -1f),
			new Vector4(1f, 0f, 0f, -1f)
		};

		public static void ExtractBillboardData(BillboardRenderer billboardData, FoliageTypeSpeedTreeData data)
		{
			BillboardAsset billboard = billboardData.billboard;
			Vector4 size = new Vector4(billboard.width, billboard.height, billboard.bottom, 1f);
			Vector4[] imageTexCoords = billboard.GetImageTexCoords();
			Vector2[] array = new Vector2[imageTexCoords.Length * 4];
			Vector2[] array2 = new Vector2[4];
			int num = 0;
			int num2 = 0;
			while (num < imageTexCoords.Length)
			{
				Vector4 vector = imageTexCoords[num];
				if (num == 0)
				{
					array2[0] = new Vector2(vector.x, vector.y);
					array2[1] = new Vector2(vector.x, vector.y) + new Vector2(0f, Mathf.Abs(vector.w));
					array2[2] = new Vector2(vector.x, vector.y) + new Vector2(0f - vector.z, Mathf.Abs(vector.w));
					array2[3] = new Vector2(vector.x, vector.y) + new Vector2(0f - vector.z, 0f);
				}
				if (vector.w < 0f)
				{
					array[num2] = new Vector2(vector.x, vector.y);
					array[num2 + 1] = new Vector2(vector.x, vector.y) + new Vector2(0f, Mathf.Abs(vector.w));
					array[num2 + 2] = new Vector2(vector.x, vector.y) + new Vector2(0f - vector.z, Mathf.Abs(vector.w));
					array[num2 + 3] = new Vector2(vector.x, vector.y) + new Vector2(0f - vector.z, 0f);
				}
				else
				{
					array[num2] = new Vector2(vector.x, vector.y);
					array[num2 + 1] = new Vector2(vector.x, vector.y) + new Vector2(vector.z, 0f);
					array[num2 + 2] = new Vector2(vector.x, vector.y) + new Vector2(vector.z, vector.w);
					array[num2 + 3] = new Vector2(vector.x, vector.y) + new Vector2(0f, vector.w);
				}
				num++;
				num2 += 4;
			}
			Vector4[] array3 = new Vector4[8];
			Vector4[] array4 = new Vector4[8];
			Vector2[] array5 = array;
			for (int i = 0; i < 8; i++)
			{
				array3[i].x = array5[4 * i].x;
				array3[i].y = array5[4 * i + 1].x;
				array3[i].z = array5[4 * i + 2].x;
				array3[i].w = array5[4 * i + 3].x;
				array4[i].x = array5[4 * i].y;
				array4[i].y = array5[4 * i + 1].y;
				array4[i].z = array5[4 * i + 2].y;
				array4[i].w = array5[4 * i + 3].y;
			}
			data.m_Size = size;
			data.m_VertBillboardU = array3;
			data.m_VertBillboardV = array4;
			data.m_BillboardRenderer = billboardData;
			data.m_BillboardMaterial = GenerateBillboardMaterial(data);
		}

		public static Material GenerateBillboardMaterial(FoliageTypeSpeedTreeData speedTreeData)
		{
			Material material = speedTreeData.m_BillboardMaterial;
			if (material == null)
			{
				material = (speedTreeData.m_BillboardMaterial = new Material(Shader.Find("Critias/WindTree_Billboard")));
			}
			material.SetTexture("_MainTex", speedTreeData.m_BillboardRenderer.sharedMaterial.GetTexture("_MainTex"));
			material.SetTexture("_BumpMap", speedTreeData.m_BillboardRenderer.sharedMaterial.GetTexture("_BumpMap"));
			material.SetColor("_HueVariation", speedTreeData.m_BillboardRenderer.sharedMaterial.GetColor("_HueVariation"));
			material.SetVector("_Size", speedTreeData.m_Size);
			material.SetVectorArray("_UVVert_U", speedTreeData.m_VertBillboardU);
			material.SetVectorArray("_UVVert_V", speedTreeData.m_VertBillboardV);
			material.SetVector("_UVHorz_U", speedTreeData.m_VertBillboardU[0]);
			material.SetVector("_UVHorz_V", speedTreeData.m_VertBillboardV[0]);
			material.enableInstancing = true;
			return material;
		}

		public static void DestroyBillboards(GameObject owner, int cellHash, FoliageType type)
		{
			string n = $"MeshCell[{cellHash}_{type.m_Prefab.name}]";
			Transform transform = owner.transform.Find(n);
			if (transform != null)
			{
				UnityEngine.Object.Destroy(transform.gameObject);
				transform = null;
			}
		}

		public static void GenerateBillboards(Bounds bounds, FoliageCell cell, GameObject owner, List<FoliageInstance> trees, FoliageType type, bool addLodGroup, float screenFadeSize, bool animatedCrossFade)
		{
			int[] systemQuadTriangles = m_SystemQuadTriangles;
			GameObject gameObject = new GameObject();
			string text = $"MeshCell[{cell.GetHashCode()}_{type.m_Prefab.name}]";
			Transform transform = owner.transform.Find(text);
			if (transform != null)
			{
				UnityEngine.Object.Destroy(transform.gameObject);
				transform = null;
			}
			gameObject.transform.SetParent(owner.transform);
			gameObject.name = text;
			FoliageTypeSpeedTreeData speedTreeData = type.m_RuntimeData.m_SpeedTreeData;
			Vector3 scale = new Vector3(speedTreeData.m_Size.x, speedTreeData.m_Size.y, speedTreeData.m_Size.x);
			MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
			meshRenderer.sharedMaterial = GenerateBillboardMaterial(type.m_RuntimeData.m_SpeedTreeData);
			MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
			Mesh mesh = new Mesh();
			mesh.name = gameObject.name;
			List<Vector4> list = new List<Vector4>();
			List<Vector3> list2 = new List<Vector3>();
			List<Vector3> list3 = new List<Vector3>();
			List<Vector4> list4 = new List<Vector4>();
			List<Vector3> list5 = new List<Vector3>();
			List<int> list6 = new List<int>();
			for (int i = 0; i < trees.Count; i++)
			{
				Vector3 position = trees[i].m_Position;
				Vector3 scale2 = trees[i].m_Scale;
				float w = trees[i].m_Rotation.eulerAngles.y * (MathF.PI / 180f);
				Vector3 vector = position;
				Vector3 item = scale2;
				item.Scale(scale);
				for (int j = 0; j < 4; j++)
				{
					Vector4 item2 = vector;
					item2.w = w;
					list.Add(item2);
					list2.Add(item);
				}
				list3.AddRange(m_SystemQuadVertices);
				list4.AddRange(m_SystemQuadTangents);
				list5.AddRange(m_SystemQuadNormals);
				list6.AddRange(systemQuadTriangles);
				for (int k = 0; k < 6; k++)
				{
					list6[k + 6 * i] = systemQuadTriangles[k] + 4 * i;
				}
			}
			mesh.Clear();
			mesh.SetVertices(list3);
			mesh.SetNormals(list5);
			mesh.SetTangents(list4);
			mesh.SetUVs(1, list);
			mesh.SetUVs(2, list2);
			mesh.SetTriangles(list6, 0, calculateBounds: false);
			mesh.bounds = bounds;
			mesh.UploadMeshData(markNoLongerReadable: true);
			meshFilter.mesh = mesh;
			if (addLodGroup)
			{
				LODGroup lODGroup = gameObject.AddComponent<LODGroup>();
				lODGroup.animateCrossFading = false;
				if (animatedCrossFade)
				{
					lODGroup.fadeMode = LODFadeMode.CrossFade;
					lODGroup.animateCrossFading = true;
				}
				else
				{
					lODGroup.fadeMode = LODFadeMode.None;
					lODGroup.animateCrossFading = false;
				}
				lODGroup.SetLODs(new LOD[1]
				{
					new LOD(screenFadeSize, new Renderer[1] { meshRenderer })
				});
				lODGroup.RecalculateBounds();
			}
		}
	}
}
