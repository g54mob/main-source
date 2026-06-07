using System.Collections.Generic;
using AwesomeTechnologies.Billboards;
using AwesomeTechnologies.VegetationSystem;
using UnityEngine;

namespace AwesomeTechnologies
{
	public class BillboardAtlasRenderer : MonoBehaviour
	{
		public const int BillboardVersion = 2;

		public List<BillboardObject> BillboardObjectList = new List<BillboardObject>();

		public static Texture2D GenerateBillboardTexture(GameObject prefab, BillboardQuality billboardQuality, LODLevel billboardSourceLODLevel, VegetationShaderType vegetationShaderType, Quaternion rotationOffset, Color backgroundColor, string overrideBillboardAtlasShader, bool recalculateNormals, float normalBlendFactor, bool generateAlpha)
		{
			Shader replacementShader = BillboardShaderDetector.GetDiffuceBillboardAtlasShader(prefab);
			if (overrideBillboardAtlasShader != "")
			{
				replacementShader = Shader.Find(overrideBillboardAtlasShader);
			}
			Material minPostfilter = (Material)Resources.Load("MinPostFilter/MinPostFilter", typeof(Material));
			return GenerateBillboardNew(prefab, GetBillboardQualityTileWidth(billboardQuality), GetBillboardQualityTileWidth(billboardQuality), GetBillboardQualityColumnCount(billboardQuality), GetBillboardQualityRowCount(billboardQuality), replacementShader, backgroundColor, minPostfilter, billboardSourceLODLevel, rotationOffset, generateAlpha, recalculateNormals, normalBlendFactor);
		}

		public static Texture2D GenerateBillboardNormalTexture(GameObject prefab, BillboardQuality billboardQuality, LODLevel billboardSourceLODLevel, Quaternion rotationOffset, string overrideBillboardAtlasNormalShader, bool recalculateNormals, float normalBlendFactor, bool flipBackNormals)
		{
			Shader replacementShader = BillboardShaderDetector.GetNormalBillboardAtlasShader(prefab);
			if (overrideBillboardAtlasNormalShader != "")
			{
				replacementShader = Shader.Find(overrideBillboardAtlasNormalShader);
			}
			if (flipBackNormals)
			{
				Shader.SetGlobalInt("_FlipBackNormals", 1);
			}
			else
			{
				Shader.SetGlobalInt("_FlipBackNormals", 0);
			}
			Material minPostfilter = (Material)Resources.Load("MinPostFilter/MinPostFilter", typeof(Material));
			Texture2D result = GenerateBillboardNew(prefab, GetBillboardQualityTileWidth(billboardQuality), GetBillboardQualityTileWidth(billboardQuality), GetBillboardQualityColumnCount(billboardQuality), GetBillboardQualityRowCount(billboardQuality), replacementShader, new Color(0.5f, 0.5f, 1f, 0.5f), minPostfilter, billboardSourceLODLevel, rotationOffset, generateAlpha: false, recalculateNormals, normalBlendFactor);
			Shader.SetGlobalInt("_FlipBackNormals", 0);
			return result;
		}

		public static int GetBillboardQualityTileWidth(BillboardQuality billboardQuality)
		{
			switch (billboardQuality)
			{
			case BillboardQuality.Normal:
			case BillboardQuality.Normal3D:
			case BillboardQuality.NormalSingle:
			case BillboardQuality.NormalQuad:
				return 128;
			case BillboardQuality.High:
			case BillboardQuality.High3D:
			case BillboardQuality.HighSingle:
			case BillboardQuality.HighQuad:
				return 256;
			case BillboardQuality.Max:
			case BillboardQuality.Max3D:
			case BillboardQuality.MaxSingle:
			case BillboardQuality.MaxQuad:
				return 512;
			case BillboardQuality.HighSample3D:
			case BillboardQuality.HighSample2D:
				return 256;
			default:
				return 128;
			}
		}

		public static int GetBillboardQualityRowCount(BillboardQuality billboardQuality)
		{
			switch (billboardQuality)
			{
			case BillboardQuality.Normal:
			case BillboardQuality.High:
			case BillboardQuality.Max:
			case BillboardQuality.HighSample2D:
			case BillboardQuality.NormalSingle:
			case BillboardQuality.HighSingle:
			case BillboardQuality.MaxSingle:
				return 1;
			case BillboardQuality.NormalQuad:
			case BillboardQuality.HighQuad:
			case BillboardQuality.MaxQuad:
				return 1;
			case BillboardQuality.Normal3D:
			case BillboardQuality.High3D:
			case BillboardQuality.Max3D:
				return 8;
			case BillboardQuality.HighSample3D:
				return 16;
			default:
				return 1;
			}
		}

		public static int GetBillboardQualityColumnCount(BillboardQuality billboardQuality)
		{
			switch (billboardQuality)
			{
			case BillboardQuality.HighSample3D:
			case BillboardQuality.HighSample2D:
				return 16;
			case BillboardQuality.NormalSingle:
			case BillboardQuality.HighSingle:
			case BillboardQuality.MaxSingle:
				return 1;
			case BillboardQuality.NormalQuad:
			case BillboardQuality.HighQuad:
			case BillboardQuality.MaxQuad:
				return 4;
			default:
				return 8;
			}
		}

		public static Texture2D GenerateBillboardNew(GameObject prefab, int width, int height, int gridSizeX, int gridSizeY, Shader replacementShader, Color backgroundColor, Material minPostfilter, LODLevel billboardSourceLODLevel, Quaternion rotationOffset, bool generateAlpha, bool recalculateNormals, float normalBlendFactor)
		{
			Vector3 vector = new Vector3(0f, 0f, 0f);
			int width2 = width * gridSizeX;
			int height2 = height * gridSizeY;
			Texture2D texture2D;
			RenderTexture renderTexture;
			RenderTexture active;
			if (generateAlpha)
			{
				texture2D = new Texture2D(width2, height2, TextureFormat.RGBA32, 0, linear: true);
				renderTexture = new RenderTexture(width, height, 24, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
				active = new RenderTexture(width, height, 24, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
			}
			else
			{
				texture2D = new Texture2D(width2, height2);
				renderTexture = new RenderTexture(width, height, 24);
				active = new RenderTexture(width, height, 24);
			}
			GameObject gameObject = new GameObject("TempCamera");
			Camera camera = gameObject.AddComponent<Camera>();
			camera.clearFlags = CameraClearFlags.Color;
			backgroundColor.a = 0f;
			camera.backgroundColor = backgroundColor;
			if (generateAlpha)
			{
				camera.backgroundColor = new Color(0f, 0f, 0f, 1f);
			}
			camera.renderingPath = RenderingPath.Forward;
			GameObject gameObject2 = Object.Instantiate(prefab, vector, rotationOffset);
			SetReplacementShader(gameObject2, replacementShader, generateAlpha);
			if (recalculateNormals)
			{
				RecalculateMeshNormals(gameObject2, normalBlendFactor);
			}
			gameObject2.hideFlags = HideFlags.DontSave;
			Bounds bounds = CalculateBounds(gameObject2);
			float num = FindLowestMeshYposition(gameObject2);
			camera.orthographic = true;
			float num2 = (camera.orthographicSize = Mathf.Max(bounds.extents.x, bounds.extents.y, bounds.extents.z));
			camera.nearClipPlane = (0f - num2) * 2f;
			camera.farClipPlane = num2 * 2f;
			SetMaterialFloat(gameObject2, "_DepthBoundsSize", num2 * 2f);
			camera.targetTexture = renderTexture;
			camera.transform.position = vector + new Vector3(0f, bounds.extents.y - num / 2f, 0f);
			float num4 = 360f / (float)gridSizeY / 4f;
			float num5 = 360f / (float)gridSizeX;
			minPostfilter.SetInt("_UseGammaCorrection", 0);
			for (int i = 0; i < gridSizeX; i++)
			{
				for (int j = 0; j < gridSizeY; j++)
				{
					camera.transform.rotation = Quaternion.AngleAxis(num5 * (float)i, Vector3.up) * Quaternion.AngleAxis(num4 * (float)j, Vector3.right);
					Graphics.SetRenderTarget(renderTexture);
					GL.Viewport(new Rect(0f, 0f, renderTexture.width, renderTexture.height));
					GL.Clear(clearDepth: true, clearColor: true, camera.backgroundColor, 1f);
					GL.PushMatrix();
					GL.LoadProjectionMatrix(camera.projectionMatrix);
					GL.modelview = camera.worldToCameraMatrix;
					GL.PushMatrix();
					RenderGameObjectNow(gameObject2, (int)billboardSourceLODLevel);
					GL.PopMatrix();
					GL.PopMatrix();
					Graphics.ClearRandomWriteTargets();
					if (!generateAlpha)
					{
						RenderTexture.active = active;
						Graphics.Blit(renderTexture, minPostfilter);
					}
					texture2D.ReadPixels(new Rect(0f, 0f, renderTexture.width, renderTexture.height), i * width, j * height);
					RenderTexture.active = null;
				}
			}
			Object.DestroyImmediate(gameObject2);
			Object.DestroyImmediate(gameObject);
			texture2D.Apply();
			return texture2D;
		}

		public static void RenderGameObjectNow(GameObject go, int sourceLODLevel)
		{
			GameObject gameObject = go;
			LODGroup component = go.GetComponent<LODGroup>();
			if ((bool)component && component.lodCount > 0)
			{
				gameObject = ((component.fadeMode != LODFadeMode.SpeedTree) ? component.GetLODs()[0].renderers[0].gameObject : component.GetLODs()[sourceLODLevel].renderers[0].gameObject);
			}
			MeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<MeshRenderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				MeshFilter component2 = componentsInChildren[i].gameObject.GetComponent<MeshFilter>();
				if ((bool)component2)
				{
					Matrix4x4 matrix = Matrix4x4.TRS(componentsInChildren[i].transform.position, componentsInChildren[i].transform.rotation, componentsInChildren[i].transform.lossyScale);
					Mesh sharedMesh = component2.sharedMesh;
					for (int j = 0; j < componentsInChildren[i].sharedMaterials.Length; j++)
					{
						componentsInChildren[i].sharedMaterials[j].SetPass(0);
						Graphics.DrawMeshNow(sharedMesh, matrix, j);
					}
				}
			}
		}

		public static Texture GetDiffuseTexture(Material material)
		{
			if (material.HasProperty("_MainTex"))
			{
				return material.GetTexture("_MainTex");
			}
			if (material.HasProperty("_BaseColorMap"))
			{
				return material.GetTexture("_BaseColorMap");
			}
			if (material.HasProperty("_TrunkBaseColorMap"))
			{
				return material.GetTexture("_TrunkBaseColorMap");
			}
			if (material.HasProperty("_MainAlbedoTex"))
			{
				return material.GetTexture("_MainAlbedoTex");
			}
			if (material.HasProperty("_BaseMap"))
			{
				return material.GetTexture("_BaseMap");
			}
			return null;
		}

		public static Color GetTintColor(Material material)
		{
			if (material.HasProperty("_Color"))
			{
				return material.GetColor("_Color");
			}
			if (material.HasProperty("_BaseColor"))
			{
				return material.GetColor("_BaseColor");
			}
			if (material.HasProperty("_ColorTint"))
			{
				return material.GetColor("_ColorTint");
			}
			if (material.HasProperty("_TintColor"))
			{
				return material.GetColor("_TintColor");
			}
			if (material.HasProperty("_HueVariation"))
			{
				return material.GetColor("_HueVariation");
			}
			return Color.white;
		}

		public static void RecalculateMeshNormals(GameObject go, float normalBlendfactor)
		{
			MeshFilter[] componentsInChildren = go.GetComponentsInChildren<MeshFilter>();
			for (int i = 0; i <= componentsInChildren.Length - 1; i++)
			{
				Mesh mesh = Object.Instantiate(componentsInChildren[i].sharedMesh);
				mesh.RecalculateNormals();
				Vector3[] normals = componentsInChildren[i].sharedMesh.normals;
				Vector3[] normals2 = mesh.normals;
				for (int j = 0; j <= normals2.Length - 1; j++)
				{
					normals2[j] = Vector3.Slerp(normals[j], normals2[j], normalBlendfactor);
				}
				mesh.normals = normals2;
				mesh.UploadMeshData(markNoLongerReadable: false);
				componentsInChildren[i].mesh = mesh;
			}
		}

		public static void RecalculateMeshNormals(Mesh mesh, int subMeshIndex)
		{
			Vector3[] normals = mesh.normals;
			Vector3[] vertices = mesh.vertices;
			int[] indices = mesh.GetIndices(subMeshIndex);
			Vector3 vector = vertices[indices[0]];
			for (int i = 1; i <= indices.Length - 1; i++)
			{
				vector += vertices[indices[i]];
			}
			vector /= (float)indices.Length;
			for (int j = 0; j <= normals.Length - 1; j++)
			{
				normals[j] = (vertices[j] - vector).normalized;
			}
			mesh.normals = normals;
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

		public static float FindLowestMeshYposition(GameObject go)
		{
			float num = float.PositiveInfinity;
			MeshRenderer[] componentsInChildren = go.GetComponentsInChildren<MeshRenderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				MeshFilter component = componentsInChildren[i].gameObject.GetComponent<MeshFilter>();
				if (!component || !component.sharedMesh)
				{
					continue;
				}
				Vector3[] vertices = component.sharedMesh.vertices;
				for (int j = 0; j <= vertices.Length - 1; j++)
				{
					if (vertices[j].y < num)
					{
						num = vertices[j].y;
					}
				}
			}
			return num;
		}

		public static void SetMaterialFloat(GameObject go, string propertyName, float value)
		{
			MeshRenderer[] componentsInChildren = go.GetComponentsInChildren<MeshRenderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				for (int j = 0; j < componentsInChildren[i].sharedMaterials.Length; j++)
				{
					if (componentsInChildren[i].sharedMaterials[j].HasProperty(propertyName))
					{
						componentsInChildren[i].sharedMaterials[j].SetFloat(propertyName, value);
					}
				}
			}
		}

		public static void SetReplacementShader(GameObject go, Shader replacementShader, bool generateAlpha)
		{
			MeshRenderer[] componentsInChildren = go.GetComponentsInChildren<MeshRenderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Material[] array = new Material[componentsInChildren[i].sharedMaterials.Length];
				for (int j = 0; j < array.Length; j++)
				{
					if (componentsInChildren[i].sharedMaterials[j] != null)
					{
						Texture diffuseTexture = GetDiffuseTexture(componentsInChildren[i].sharedMaterials[j]);
						Color tintColor = GetTintColor(componentsInChildren[i].sharedMaterials[j]);
						array[j] = new Material(componentsInChildren[i].sharedMaterials[j]);
						array[j].shader = replacementShader;
						if (generateAlpha && array[j].HasProperty("_ShowAlpha"))
						{
							array[j].SetInt("_ShowAlpha", 1);
						}
						if ((bool)diffuseTexture)
						{
							array[j].SetTexture("_MainTex", diffuseTexture);
						}
						if (array[j].HasProperty("_Color"))
						{
							array[j].SetColor("_Color", tintColor);
						}
					}
				}
				componentsInChildren[i].sharedMaterials = array;
			}
		}

		public static void SaveTexture(Texture2D tex, string name)
		{
		}

		public static void SetTextureImportSettings(Texture2D texture, bool normalMap)
		{
		}
	}
}
