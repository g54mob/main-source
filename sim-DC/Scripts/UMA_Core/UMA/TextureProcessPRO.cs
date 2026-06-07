using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class TextureProcessPRO
	{
		private static readonly string[,] tintProperties;

		private static readonly string[,] addProperties;

		private static string[] alphaMaskProperties;

		private static Dictionary<RenderTextureFormat, TextureFormat> TextureFormats;

		private UMAData umaData;

		private RenderTexture destinationTexture;

		private Texture[] resultingTextures;

		private UMAGeneratorBase umaGenerator;

		public bool SupportsRTToTexture2D => false;

		public static RenderTexture ResizeRenderTexture(RenderTexture source, int newWidth, int newHeight, FilterMode filter)
		{
			return null;
		}

		public void Prepare(UMAData _umaData, UMAGeneratorBase _umaGenerator)
		{
		}

		public void ProcessTexture(UMAData _umaData, UMAGeneratorBase _umaGenerator)
		{
		}

		public static void SetCompositingProperties(UMAData.GeneratedMaterial generatedMaterial, Material material, UMAData.MaterialFragment fragment)
		{
		}

		private static void SetChannelTexture(UMAData umaData, int textureChannelNumber, int overlayNumber, Material mat, OverlayData overlay0)
		{
		}

		private static void SetMaterialTexture(UMAData.GeneratedMaterial generatedMaterial, SlotData slotData, int textureType, Texture tempTexture)
		{
		}

		private bool IsOpenGL()
		{
			return false;
		}
	}
}
