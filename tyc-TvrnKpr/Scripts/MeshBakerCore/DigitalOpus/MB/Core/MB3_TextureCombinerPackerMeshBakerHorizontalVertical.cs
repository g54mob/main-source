using System.Collections.Generic;
using UnityEngine;

namespace DigitalOpus.MB.Core
{
	internal class MB3_TextureCombinerPackerMeshBakerHorizontalVertical : MB3_TextureCombinerPackerMeshBaker
	{
		private interface IPipeline
		{
			MB2_PackingAlgorithmEnum GetPackingAlg();

			void SortTexSetIntoBins(MB_TexSet texSet, List<MB_TexSet> horizontalVert, List<MB_TexSet> regular, int maxAtlasWidth, int maxAtlasHeight);

			MB_TextureTilingTreatment GetEdge2EdgeTreatment();

			void InitializeAtlasPadding(ref AtlasPadding padding, int paddingValue);

			void MergeAtlasPackingResultStackBonAInternal(AtlasPackingResult a, AtlasPackingResult b, out Rect AatlasToFinal, out Rect BatlasToFinal, bool stretchBToAtlasWidth, int maxWidthDim, int maxHeightDim, out int atlasX, out int atlasY);

			void GetExtraRoomForRegularAtlas(int usedHorizontalVertWidth, int usedHorizontalVertHeight, int maxAtlasWidth, int maxAtlasHeight, out int atlasRegularMaxWidth, out int atlasRegularMaxHeight);
		}

		private class VerticalPipeline : IPipeline
		{
			public MB2_PackingAlgorithmEnum GetPackingAlg()
			{
				return default(MB2_PackingAlgorithmEnum);
			}

			public void SortTexSetIntoBins(MB_TexSet texSet, List<MB_TexSet> horizontalVert, List<MB_TexSet> regular, int maxAtlasWidth, int maxAtlasHeight)
			{
			}

			public MB_TextureTilingTreatment GetEdge2EdgeTreatment()
			{
				return default(MB_TextureTilingTreatment);
			}

			public void InitializeAtlasPadding(ref AtlasPadding padding, int paddingValue)
			{
			}

			public void MergeAtlasPackingResultStackBonAInternal(AtlasPackingResult a, AtlasPackingResult b, out Rect AatlasToFinal, out Rect BatlasToFinal, bool stretchBToAtlasWidth, int maxWidthDim, int maxHeightDim, out int atlasX, out int atlasY)
			{
				AatlasToFinal = default(Rect);
				BatlasToFinal = default(Rect);
				atlasX = default(int);
				atlasY = default(int);
			}

			public void GetExtraRoomForRegularAtlas(int usedHorizontalVertWidth, int usedHorizontalVertHeight, int maxAtlasWidth, int maxAtlasHeight, out int atlasRegularMaxWidth, out int atlasRegularMaxHeight)
			{
				atlasRegularMaxWidth = default(int);
				atlasRegularMaxHeight = default(int);
			}
		}

		private class HorizontalPipeline : IPipeline
		{
			public MB2_PackingAlgorithmEnum GetPackingAlg()
			{
				return default(MB2_PackingAlgorithmEnum);
			}

			public void SortTexSetIntoBins(MB_TexSet texSet, List<MB_TexSet> horizontalVert, List<MB_TexSet> regular, int maxAtlasWidth, int maxAtlasHeight)
			{
			}

			public MB_TextureTilingTreatment GetEdge2EdgeTreatment()
			{
				return default(MB_TextureTilingTreatment);
			}

			public void InitializeAtlasPadding(ref AtlasPadding padding, int paddingValue)
			{
			}

			public void MergeAtlasPackingResultStackBonAInternal(AtlasPackingResult a, AtlasPackingResult b, out Rect AatlasToFinal, out Rect BatlasToFinal, bool stretchBToAtlasWidth, int maxWidthDim, int maxHeightDim, out int atlasX, out int atlasY)
			{
				AatlasToFinal = default(Rect);
				BatlasToFinal = default(Rect);
				atlasX = default(int);
				atlasY = default(int);
			}

			public void GetExtraRoomForRegularAtlas(int usedHorizontalVertWidth, int usedHorizontalVertHeight, int maxAtlasWidth, int maxAtlasHeight, out int atlasRegularMaxWidth, out int atlasRegularMaxHeight)
			{
				atlasRegularMaxWidth = default(int);
				atlasRegularMaxHeight = default(int);
			}
		}

		public enum AtlasDirection
		{
			horizontal = 0,
			vertical = 1
		}

		private AtlasDirection _atlasDirection;

		public MB3_TextureCombinerPackerMeshBakerHorizontalVertical(AtlasDirection ad)
		{
		}

		public override AtlasPackingResult[] CalculateAtlasRectangles(MB3_TextureCombinerPipeline.TexturePipelineData data, bool doMultiAtlas, MB2_LogLevel LOG_LEVEL)
		{
			return null;
		}

		public static AtlasPackingResult TestStackRectanglesHorizontal(AtlasPackingResult a, AtlasPackingResult b, int maxHeightDim, int maxWidthDim, bool stretchBToAtlasWidth)
		{
			return null;
		}

		public static AtlasPackingResult TestStackRectanglesVertical(AtlasPackingResult a, AtlasPackingResult b, int maxHeightDim, int maxWidthDim, bool stretchBToAtlasWidth)
		{
			return null;
		}

		private static AtlasPackingResult MergeAtlasPackingResultStackBonA(AtlasPackingResult a, AtlasPackingResult b, int maxWidthDim, int maxHeightDim, bool stretchBToAtlasWidth, IPipeline pipeline)
		{
			return null;
		}
	}
}
