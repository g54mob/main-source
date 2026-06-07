using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	public class UMAGeneratorPro
	{
		private struct PackSize
		{
			public int Width;

			public int Height;

			public bool success;

			public int xMax;

			public int yMax;
		}

		private struct SizeInt
		{
			public int Width;

			public int Height;
		}

		private class GeneratedMaterialLookupKey : IEquatable<GeneratedMaterialLookupKey>
		{
			public List<OverlayData> overlayList;

			public UMARendererAsset rendererAsset;

			public override int GetHashCode()
			{
				return 0;
			}

			public bool Equals(GeneratedMaterialLookupKey other)
			{
				return false;
			}
		}

		public class MaterialDefinitionComparer : IComparer<UMAData.MaterialFragment>
		{
			public int Compare(UMAData.MaterialFragment x, UMAData.MaterialFragment y)
			{
				return 0;
			}
		}

		private TextureProcessPRO textureProcesser;

		private MaxRectsBinPack packTexture;

		private UMAGeneratorBase umaGenerator;

		private UMAData umaData;

		private Texture[] backUpTexture;

		private bool updateMaterialList;

		private int scaleFactor;

		private MaterialDefinitionComparer comparer;

		private List<UMAData.GeneratedMaterial> generatedMaterials;

		private List<UMARendererAsset> uniqueRenderers;

		private List<UMAData.GeneratedMaterial> atlassedMaterials;

		private Dictionary<GeneratedMaterialLookupKey, UMAData.GeneratedMaterial> generatedMaterialLookup;

		private UMAData.GeneratedMaterial FindOrCreateGeneratedMaterial(UMAMaterial umaMaterial, UMARendererAsset renderer = null)
		{
			return null;
		}

		protected bool IsUVCoordinates(Rect r)
		{
			return false;
		}

		protected Rect ScaleToBase(Rect r, Texture BaseTexture)
		{
			return default(Rect);
		}

		protected void Start()
		{
		}

		public static void ApplyMaterialParameters(UMAData.GeneratedMaterial ugm, UMAData umaData, Material material)
		{
		}

		public void ProcessTexture(UMAGeneratorBase _umaGenerator, UMAData _umaData, bool updateMaterialList, int InitialScaleFactor)
		{
		}

		private void CleanBackUpTextures()
		{
		}

		private void GenerateAtlasData()
		{
		}

		private bool CalculateBestFitSquare(SizeInt area, float atlasRes, ref Vector2 Scale, UMAData.GeneratedMaterial generatedMaterial)
		{
			return false;
		}

		private void UpdateAtlasRects(UMAData.GeneratedMaterial generatedMaterial, Vector2 Scale)
		{
		}

		private void UpdateSharedRect(UMAData.GeneratedMaterial generatedMaterial)
		{
		}

		private PackSize CalculateRects(UMAData.GeneratedMaterial material, SizeInt area)
		{
			return default(PackSize);
		}

		private bool OldCalculateRects(UMAData.GeneratedMaterial material)
		{
			return false;
		}

		private void OptimizeAtlas()
		{
		}

		private void UpdateUV()
		{
		}
	}
}
