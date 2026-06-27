using System;
using System.Collections.Generic;
using UnityEngine;

namespace Restory.Gameplay.TextureMasks
{
	public class MeshUVProcessor
	{
		[Serializable]
		public struct ProcessingSettings
		{
			public bool enableWireframe;

			public float wireThickness;

			public bool wrapUV;

			public bool enableDebugOutput;
		}

		public Texture2D CreateMeshUVCoverageMask(Mesh mesh, Vector2Int textureSize, ProcessingSettings settings)
		{
			if (settings.enableDebugOutput)
			{
				Debug.Log("\ud83d\udd0d Mesh UV Processing Debug:");
				Debug.Log("   Mesh: " + (mesh?.name ?? "null"));
				Debug.Log($"   Texture Size: {textureSize}");
				Debug.Log($"   Wireframe: {settings.enableWireframe}");
				Debug.Log($"   Wire Thickness: {settings.wireThickness}");
			}
			if (mesh == null)
			{
				Debug.LogError("MeshUVProcessor: Mesh is null");
				return CreateEmptyMask(textureSize);
			}
			Vector2[] uv = mesh.uv;
			int[] triangles = mesh.triangles;
			if (uv == null || uv.Length == 0)
			{
				Debug.LogError("MeshUVProcessor: Mesh has no UV coordinates");
				return CreateEmptyMask(textureSize);
			}
			if (triangles == null || triangles.Length == 0)
			{
				Debug.LogError("MeshUVProcessor: Mesh has no triangles");
				return CreateEmptyMask(textureSize);
			}
			float[,] mask = RasterizeMeshTriangles(uv, triangles, textureSize, settings);
			Texture2D result = ConvertMaskToTexture(mask, textureSize);
			if (settings.enableDebugOutput)
			{
				Debug.Log($"✅ Mesh UV Coverage Mask created: {triangles.Length / 3} triangles processed");
			}
			return result;
		}

		public Texture2D CreateTriangleUVCoverageMask(List<Vector2[]> uvTriangles, Vector2Int textureSize, ProcessingSettings settings)
		{
			if (settings.enableDebugOutput)
			{
				Debug.Log("\ud83d\udd0d Triangle UV Processing Debug:");
				Debug.Log($"   Triangles: {uvTriangles?.Count ?? 0}");
				Debug.Log($"   Texture Size: {textureSize}");
			}
			if (uvTriangles == null || uvTriangles.Count == 0)
			{
				return CreateEmptyMask(textureSize);
			}
			float[,] mask = RasterizeCustomTriangles(uvTriangles, textureSize, settings);
			Texture2D result = ConvertMaskToTexture(mask, textureSize);
			if (settings.enableDebugOutput)
			{
				Debug.Log($"✅ Triangle UV Coverage Mask created: {uvTriangles.Count} triangles processed");
			}
			return result;
		}

		private float[,] RasterizeMeshTriangles(Vector2[] uvs, int[] triangles, Vector2Int textureSize, ProcessingSettings settings)
		{
			int x = textureSize.x;
			int y = textureSize.y;
			float[,] array = new float[x, y];
			for (int i = 0; i < triangles.Length; i += 3)
			{
				Vector2 uv = uvs[triangles[i]];
				Vector2 uv2 = uvs[triangles[i + 1]];
				Vector2 uv3 = uvs[triangles[i + 2]];
				RasterizeTriangle(array, uv, uv2, uv3, textureSize, settings);
			}
			return array;
		}

		private float[,] RasterizeCustomTriangles(List<Vector2[]> uvTriangles, Vector2Int textureSize, ProcessingSettings settings)
		{
			int x = textureSize.x;
			int y = textureSize.y;
			float[,] array = new float[x, y];
			foreach (Vector2[] uvTriangle in uvTriangles)
			{
				if (uvTriangle.Length >= 3)
				{
					RasterizeTriangle(array, uvTriangle[0], uvTriangle[1], uvTriangle[2], textureSize, settings);
				}
			}
			return array;
		}

		private void RasterizeTriangle(float[,] mask, Vector2 uv0, Vector2 uv1, Vector2 uv2, Vector2Int textureSize, ProcessingSettings settings)
		{
			int x = textureSize.x;
			int y = textureSize.y;
			if (!settings.wrapUV && ((uv0.x < 0f && uv1.x < 0f && uv2.x < 0f) || (uv0.x > 1f && uv1.x > 1f && uv2.x > 1f) || (uv0.y < 0f && uv1.y < 0f && uv2.y < 0f) || (uv0.y > 1f && uv1.y > 1f && uv2.y > 1f)))
			{
				return;
			}
			Vector2 vector = UVToPixel(uv0, textureSize, settings.wrapUV);
			Vector2 vector2 = UVToPixel(uv1, textureSize, settings.wrapUV);
			Vector2 vector3 = UVToPixel(uv2, textureSize, settings.wrapUV);
			int num = Mathf.Clamp(Mathf.FloorToInt(Mathf.Min(vector.x, Mathf.Min(vector2.x, vector3.x))), 0, x - 1);
			int num2 = Mathf.Clamp(Mathf.CeilToInt(Mathf.Max(vector.x, Mathf.Max(vector2.x, vector3.x))), 0, x - 1);
			int num3 = Mathf.Clamp(Mathf.FloorToInt(Mathf.Min(vector.y, Mathf.Min(vector2.y, vector3.y))), 0, y - 1);
			int num4 = Mathf.Clamp(Mathf.CeilToInt(Mathf.Max(vector.y, Mathf.Max(vector2.y, vector3.y))), 0, y - 1);
			float num5 = EdgeFunction(vector, vector2, vector3);
			if (Mathf.Approximately(num5, 0f))
			{
				return;
			}
			for (int i = num3; i <= num4; i++)
			{
				for (int j = num; j <= num2; j++)
				{
					Vector2 c = new Vector2((float)j + 0.5f, (float)i + 0.5f);
					float num6 = EdgeFunction(vector2, vector3, c);
					float num7 = EdgeFunction(vector3, vector, c);
					float num8 = EdgeFunction(vector, vector2, c);
					bool flag = num6 >= 0f && num7 >= 0f && num8 >= 0f;
					if (num5 < 0f)
					{
						flag = num6 <= 0f && num7 <= 0f && num8 <= 0f;
					}
					if (flag)
					{
						mask[j, i] = 1f;
					}
					else if (settings.enableWireframe && Mathf.Min(Mathf.Abs(num6), Mathf.Abs(num7), Mathf.Abs(num8)) / Mathf.Abs(num5) * (float)Mathf.Max(x, y) <= settings.wireThickness)
					{
						mask[j, i] = 1f;
					}
				}
			}
		}

		private Vector2 UVToPixel(Vector2 uv, Vector2Int textureSize, bool wrapUV)
		{
			Vector2 vector = uv;
			if (wrapUV)
			{
				vector = new Vector2(vector.x - Mathf.Floor(vector.x), vector.y - Mathf.Floor(vector.y));
			}
			vector.x = Mathf.Clamp01(vector.x);
			vector.y = Mathf.Clamp01(vector.y);
			return new Vector2(vector.x * (float)(textureSize.x - 1), vector.y * (float)(textureSize.y - 1));
		}

		private static float EdgeFunction(Vector2 a, Vector2 b, Vector2 c)
		{
			return (c.x - a.x) * (b.y - a.y) - (c.y - a.y) * (b.x - a.x);
		}

		private Texture2D CreateEmptyMask(Vector2Int textureSize)
		{
			Texture2D texture2D = new Texture2D(textureSize.x, textureSize.y, TextureFormat.R8, mipChain: false, linear: true);
			Color[] array = new Color[textureSize.x * textureSize.y];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Color.black;
			}
			texture2D.SetPixels(array);
			texture2D.Apply();
			return texture2D;
		}

		private Texture2D ConvertMaskToTexture(float[,] mask, Vector2Int textureSize)
		{
			Texture2D texture2D = new Texture2D(textureSize.x, textureSize.y, TextureFormat.R8, mipChain: false, linear: true);
			Color[] array = new Color[textureSize.x * textureSize.y];
			for (int i = 0; i < textureSize.y; i++)
			{
				for (int j = 0; j < textureSize.x; j++)
				{
					int num = i * textureSize.x + j;
					float num2 = mask[j, i];
					array[num] = new Color(num2, num2, num2, 1f);
				}
			}
			texture2D.SetPixels(array);
			texture2D.Apply();
			return texture2D;
		}
	}
}
