using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace UMA
{
	[ExecuteInEditMode]
	[CreateAssetMenu(menuName = "UMA/Rendering/TextureMerge")]
	public class TextureMerge : ScriptableObject
	{
		[Serializable]
		public class BlendModeShaders
		{
			public BlendOp BlendMode;

			public Shader Combiner;
		}

		public struct TextureMergeRect
		{
			public Material mat;

			public Texture tex;

			public Rect rect;

			public bool transform;

			public float rotation;

			public Vector3 scale;

			public Vector2 position;

			public bool advancedBlending;

			public int textureType;

			public UMAMaterial.ChannelType channelType;
		}

		public Material material;

		public Shader normalShader;

		public Shader diffuseShader;

		public Shader dataShader;

		public Shader cutoutShader;

		public Shader detailNormalShader;

		private Vector2 pivotPoint;

		[NonSerialized]
		public Color camBackgroundColor;

		public List<UMAPostProcess> diffusePostProcesses;

		public List<UMAPostProcess> normalPostProcesses;

		public List<UMAPostProcess> dataPostProcesses;

		public List<UMAPostProcess> detailNormalPostProcesses;

		[Header("Blend Mode Shaders.", order = 1)]
		[Header("Note 'logical' blend modes are only available on DX11", order = 2)]
		public List<BlendModeShaders> DiffuseBlendModeShaders;

		public List<BlendModeShaders> DataBlendModeShaders;

		public List<BlendModeShaders> NormalBlendModeShaders;

		private int textureMergeRectCount;

		private TextureMergeRect[] textureMergeRects;

		private Rect atlasRect;

		private Vector2 resolutionScale;

		private int height;

		public void RefreshMaterials()
		{
		}

		public static Texture2D GetRTPixels(RenderTexture rt)
		{
			return null;
		}

		public static void SaveRenderTexture(RenderTexture texture, string textureName, bool isNormal = false)
		{
		}

		private static void SaveTexture2D(Texture2D texture, string textureName)
		{
		}

		public void DrawAllRects(RenderTexture target, int width, int height, Color background = default(Color), bool sharperFitTextures = true)
		{
		}

		public static void RotateAroundPivot(float angle, Vector2 pivotPoint)
		{
		}

		private void DrawRect(ref TextureMergeRect tr, bool sharperFitTextures)
		{
		}

		public void PostProcess(RenderTexture destination, UMAMaterial.ChannelType channelType)
		{
		}

		public void Reset()
		{
		}

		internal void EnsureCapacity(int moduleCount)
		{
		}

		private void SetupMaterial(ref TextureMergeRect textureMergeRect, UMAData.MaterialFragment source, int textureType)
		{
		}

		public void SetupModule(UMAData.MaterialFragment source, int textureType)
		{
		}

		public void SetupModule(UMAData.GeneratedMaterial atlas, int idx, int textureType)
		{
		}

		private void SetupOverlay(UMAData.MaterialFragment source, int OverlayIndex, int textureType)
		{
		}

		private Shader GetBlendModeDiffuseShader(OverlayData od, int TextureType, out bool isAdvanced)
		{
			isAdvanced = default(bool);
			return null;
		}

		private Shader GetBlendModeShader(List<BlendModeShaders> shaderList, OverlayData od, int TextureType, out bool isAdvanced)
		{
			isAdvanced = default(bool);
			return null;
		}

		private void SetupMaterial(ref TextureMergeRect textureMergeRect, UMAData.MaterialFragment source, int i2, ref Rect overlayRect, int textureType)
		{
		}
	}
}
