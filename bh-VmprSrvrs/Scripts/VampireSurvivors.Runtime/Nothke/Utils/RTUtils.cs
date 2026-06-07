using TMPro;
using UnityEngine;

namespace Nothke.Utils
{
	public static class RTUtils
	{
		private static Mesh quad;

		private static Shader blitShader;

		private static Material blitMaterial;

		private static RenderTexture prevRT;

		public static Mesh GetQuad()
		{
			return null;
		}

		public static Shader GetBlitShader()
		{
			return null;
		}

		public static Material GetBlitMaterial()
		{
			return null;
		}

		public static void BeginOrthoRendering(this RenderTexture rt, float zBegin = -100f, float zEnd = 100f)
		{
		}

		public static void BeginPixelRendering(this RenderTexture rt, float zBegin = -100f, float zEnd = 100f)
		{
		}

		public static void BeginPerspectiveRendering(this RenderTexture rt, float fov, in Vector3 position, in Quaternion rotation, float zNear = 0.01f, float zFar = 1000f)
		{
		}

		public static void BeginRendering(this RenderTexture rt, Matrix4x4 projectionMatrix)
		{
		}

		public static void EndRendering(this RenderTexture rt)
		{
		}

		public static void DrawMesh(this RenderTexture rt, Mesh mesh, Material material, in Matrix4x4 objectMatrix, int pass = 0)
		{
		}

		public static void DrawTMPText(this RenderTexture rt, TMP_Text text, in Vector2 position, float size)
		{
		}

		public static void DrawTMPText(this RenderTexture rt, TMP_Text text, in Matrix4x4 matrix)
		{
		}

		public static void BlitTMPText(this RenderTexture rt, TMP_Text text, in Vector2 pos, float size, bool clear = true, Color clearColor = default(Color))
		{
		}

		public static void BlitTMPText(this RenderTexture rt, TMP_Text text, Matrix4x4 objectMatrix, bool clear = true, Color clearColor = default(Color))
		{
		}

		public static void BlitMesh(this RenderTexture rt, Matrix4x4 objectMatrix, Mesh mesh, Material material, bool invertCulling = true, bool clear = true, Color clearColor = default(Color))
		{
		}

		public static void DrawQuad(this RenderTexture rt, Material material, in Rect rect)
		{
		}

		public static void DrawSprite(this RenderTexture rt, Texture texture, in Rect rect)
		{
		}

		public static float Aspect(this Texture rt)
		{
			return 0f;
		}

		public static Texture2D ConvertToTexture2D(this RenderTexture rt, TextureFormat format = TextureFormat.RGB24, FilterMode filterMode = FilterMode.Bilinear)
		{
			return null;
		}

		public static void DrawTextureGUI(Texture texture)
		{
		}
	}
}
