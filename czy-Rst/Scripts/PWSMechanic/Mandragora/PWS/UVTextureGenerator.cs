using System;
using UnityEngine;

namespace Mandragora.PWS
{
	[ExecuteAlways]
	public class UVTextureGenerator : MonoBehaviour
	{
		[SerializeField]
		private Mesh mesh;

		[SerializeField]
		private int textureSize = 2048;

		[SerializeField]
		private bool drawWireframe;

		[SerializeField]
		[Range(0f, 1f)]
		private float wireThickness = 0.5f;

		[SerializeField]
		private bool wrapUV;

		private Texture2D finalTexture;

		public void Generate()
		{
			if (finalTexture != null)
			{
				UnityEngine.Object.Destroy(finalTexture);
			}
			finalTexture = GenerateUVTexture();
		}

		private Texture2D GenerateUVTexture()
		{
			if (mesh == null)
			{
				MeshFilter component = GetComponent<MeshFilter>();
				if (component != null)
				{
					mesh = component.sharedMesh;
				}
				else
				{
					SkinnedMeshRenderer component2 = GetComponent<SkinnedMeshRenderer>();
					if (component2 != null)
					{
						mesh = component2.sharedMesh;
					}
				}
				if (mesh == null)
				{
					Debug.LogError("UVTextureGenerator: Mesh не задан и не найден на объекте.");
					return null;
				}
			}
			Vector2[] uv = mesh.uv;
			int[] triangles = mesh.triangles;
			if (uv == null || uv.Length == 0)
			{
				Debug.LogError("UVTextureGenerator: У меша нет UV.");
				return null;
			}
			int w = Mathf.Max(1, textureSize);
			int h = w;
			Color[] array = new Color[w * h];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Color.black;
			}
			Func<Vector2, Vector2> func = delegate(Vector2 vector5)
			{
				Vector2 vector4 = vector5;
				if (wrapUV)
				{
					vector4 = new Vector2(vector4.x - Mathf.Floor(vector4.x), vector4.y - Mathf.Floor(vector4.y));
				}
				vector4.x = Mathf.Clamp01(vector4.x);
				vector4.y = Mathf.Clamp01(vector4.y);
				return new Vector2(vector4.x * (float)(w - 1), vector4.y * (float)(h - 1));
			};
			for (int num = 0; num < triangles.Length; num += 3)
			{
				Vector2 arg = uv[triangles[num]];
				Vector2 arg2 = uv[triangles[num + 1]];
				Vector2 arg3 = uv[triangles[num + 2]];
				if (!wrapUV && ((arg.x < 0f && arg2.x < 0f && arg3.x < 0f) || (arg.x > 1f && arg2.x > 1f && arg3.x > 1f) || (arg.y < 0f && arg2.y < 0f && arg3.y < 0f) || (arg.y > 1f && arg2.y > 1f && arg3.y > 1f)))
				{
					continue;
				}
				Vector2 vector = func(arg);
				Vector2 vector2 = func(arg2);
				Vector2 vector3 = func(arg3);
				int num2 = Mathf.Clamp(Mathf.FloorToInt(Mathf.Min(vector.x, Mathf.Min(vector2.x, vector3.x))), 0, w - 1);
				int num3 = Mathf.Clamp(Mathf.CeilToInt(Mathf.Max(vector.x, Mathf.Max(vector2.x, vector3.x))), 0, w - 1);
				int num4 = Mathf.Clamp(Mathf.FloorToInt(Mathf.Min(vector.y, Mathf.Min(vector2.y, vector3.y))), 0, h - 1);
				int num5 = Mathf.Clamp(Mathf.CeilToInt(Mathf.Max(vector.y, Mathf.Max(vector2.y, vector3.y))), 0, h - 1);
				float num6 = EdgeFunction(vector, vector2, vector3);
				if (Mathf.Approximately(num6, 0f))
				{
					continue;
				}
				for (int num7 = num4; num7 <= num5; num7++)
				{
					for (int num8 = num2; num8 <= num3; num8++)
					{
						Vector2 c = new Vector2((float)num8 + 0.5f, (float)num7 + 0.5f);
						float num9 = EdgeFunction(vector2, vector3, c);
						float num10 = EdgeFunction(vector3, vector, c);
						float num11 = EdgeFunction(vector, vector2, c);
						bool flag = num9 >= 0f && num10 >= 0f && num11 >= 0f;
						if (num6 < 0f)
						{
							flag = num9 <= 0f && num10 <= 0f && num11 <= 0f;
						}
						if (flag)
						{
							int num12 = num7 * w + num8;
							array[num12] = Color.white;
						}
						else if (drawWireframe && Mathf.Min(Mathf.Abs(num9), Mathf.Abs(num10), Mathf.Abs(num11)) / Mathf.Abs(num6) * (float)Mathf.Max(w, h) <= wireThickness)
						{
							int num13 = num7 * w + num8;
							array[num13] = Color.white;
						}
					}
				}
			}
			Texture2D texture2D = new Texture2D(w, h, TextureFormat.RGBA32, mipChain: false, linear: true);
			texture2D.SetPixels(array);
			texture2D.wrapMode = TextureWrapMode.Clamp;
			texture2D.Apply();
			return texture2D;
		}

		private static float EdgeFunction(Vector2 a, Vector2 b, Vector2 c)
		{
			return (c.x - a.x) * (b.y - a.y) - (c.y - a.y) * (b.x - a.x);
		}
	}
}
