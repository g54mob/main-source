using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace VolFx
{
	public static class Utils
	{
		public static int s_MainTexId = Shader.PropertyToID("_MainTex");

		private static Mesh s_FullscreenQuad;

		private static Mesh s_FullscreenTriangle;

		public static Matrix4x4 s_IndentityInvert = new Matrix4x4(new Vector4(1f, 0f, 0f, 0f), new Vector4(0f, -1f, 0f, 0f), new Vector4(0f, 0f, 1f, 0f), new Vector4(0f, 0f, 0f, 1f));

		public static Mesh FullscreenMesh
		{
			get
			{
				_initFullScreenMeshes();
				return s_FullscreenTriangle;
			}
		}

		private static void _initFullScreenMeshes()
		{
			if (s_FullscreenQuad == null)
			{
				s_FullscreenQuad = new Mesh
				{
					name = "Fullscreen Quad"
				};
				s_FullscreenQuad.SetVertices(new List<Vector3>
				{
					new Vector3(-1f, -1f, 0f),
					new Vector3(-1f, 1f, 0f),
					new Vector3(1f, -1f, 0f),
					new Vector3(1f, 1f, 0f)
				});
				s_FullscreenQuad.SetUVs(0, new List<Vector2>
				{
					new Vector2(0f, 1f),
					new Vector2(0f, 0f),
					new Vector2(1f, 1f),
					new Vector2(1f, 0f)
				});
				s_FullscreenQuad.SetIndices(new int[6] { 0, 1, 2, 2, 1, 3 }, MeshTopology.Triangles, 0, calculateBounds: false);
				s_FullscreenQuad.UploadMeshData(markNoLongerReadable: true);
			}
			if (s_FullscreenTriangle == null)
			{
				s_FullscreenTriangle = new Mesh
				{
					name = "Fullscreen Triangle"
				};
				s_FullscreenTriangle.vertices = _verts(0f);
				s_FullscreenTriangle.uv = _texCoords();
				s_FullscreenTriangle.triangles = new int[3] { 0, 1, 2 };
				s_FullscreenTriangle.UploadMeshData(markNoLongerReadable: true);
			}
			static Vector2[] _texCoords()
			{
				Vector2[] array = new Vector2[3];
				for (int i = 0; i < 3; i++)
				{
					if (SystemInfo.graphicsUVStartsAtTop)
					{
						array[i] = new Vector2((i << 1) & 2, 1f - (float)(i & 2));
					}
					else
					{
						array[i] = new Vector2((i << 1) & 2, i & 2);
					}
				}
				return array;
			}
			static Vector3[] _verts(float z)
			{
				Vector3[] array = new Vector3[3];
				for (int i = 0; i < 3; i++)
				{
					Vector2 vector = new Vector2((i << 1) & 2, i & 2);
					array[i] = new Vector3(vector.x * 2f - 1f, vector.y * 2f - 1f, z);
				}
				return array;
			}
		}

		public static void Blit(CommandBuffer cmd, RTHandle source, RTHandle destination, Material material, int pass = 0, bool invert = false)
		{
			cmd.SetGlobalTexture(s_MainTexId, source);
			cmd.SetRenderTarget(destination, 0);
			cmd.DrawMesh(FullscreenMesh, invert ? s_IndentityInvert : Matrix4x4.identity, material, 0, pass);
		}

		public static Vector2 ToNormal(this float rad)
		{
			return new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
		}

		public static float Round(this float f)
		{
			return Mathf.Round(f);
		}

		public static float Clamp01(this float f)
		{
			return Mathf.Clamp01(f);
		}

		public static float OneMinus(this float f)
		{
			return 1f - f;
		}

		public static float Remap(this float f, float min, float max)
		{
			return min + (max - min) * f;
		}

		public static Color Color()
		{
			return new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), 1f);
		}

		public static Vector3 WithZ(this Vector3 vector, float z)
		{
			return new Vector3(vector.x, vector.y, z);
		}

		public static Vector2 To2DXY(this Vector3 vector)
		{
			return new Vector2(vector.x, vector.y);
		}

		public static Vector3 To3DXZ(this Vector2 vector)
		{
			return vector.To3DXZ(0f);
		}

		public static Vector3 To3DXZ(this Vector2 vector, float y)
		{
			return new Vector3(vector.x, y, vector.y);
		}

		public static Vector3 To3DXY(this Vector2 vector, float z)
		{
			return new Vector3(vector.x, vector.y, z);
		}

		public static Vector2 ToVector2XY(this float value)
		{
			return new Vector2(value, value);
		}

		public static Color MulA(this Color color, float a)
		{
			return new Color(color.r, color.g, color.b, color.a * a);
		}

		public static Rect GetRect(this Texture2D texture)
		{
			return new Rect(0f, 0f, texture.width, texture.height);
		}

		public static int RoundToInt(this float f)
		{
			return Mathf.RoundToInt(f);
		}

		public static TKey MaxOrDefault<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, TSource noOptionsValue = default(TSource))
		{
			TSource val = source.MaxOrDefault(selector, Comparer<TKey>.Default, noOptionsValue);
			if (object.Equals(val, null))
			{
				return default(TKey);
			}
			return selector(val);
		}

		public static TSource MaxOrDefault<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer, TSource fallback = default(TSource))
		{
			using IEnumerator<TSource> enumerator = source.GetEnumerator();
			if (!enumerator.MoveNext())
			{
				return fallback;
			}
			TSource val = enumerator.Current;
			TKey y = selector(val);
			while (enumerator.MoveNext())
			{
				TSource current = enumerator.Current;
				TKey val2 = selector(current);
				if (comparer.Compare(val2, y) > 0)
				{
					val = current;
					y = val2;
				}
			}
			return val;
		}
	}
}
