using System;
using System.Collections.Generic;
using BCnEncoder.Shared;
using BCnEncoder.Shared.ImageFiles;

namespace BCnEncoder.Encoder.Bptc
{
	internal class Bc6Encoder : BaseBcBlockEncoder<Bc6Block, RawBlock4X4RgbFloat>
	{
		internal static class Bc6EncoderFast
		{
			internal static Bc6Block EncodeBlock(RawBlock4X4RgbFloat block, bool signed)
			{
				RgbBoundingBox.CreateFloat(block.AsSpan, out var min, out var max);
				LeastSquares.OptimizeEndpoints1Sub(block, ref min, ref max);
				bool badTransform;
				return Bc6ModeEncoder.EncodeBlock1Sub(Bc6BlockType.Type3, block, min, max, signed, out badTransform);
			}
		}

		internal static class Bc6EncoderBalanced
		{
			private const float TargetError = 0.001f;

			private const int MaxTries = 10;

			private static IEnumerable<Bc6Block> GenerateCandidates(RawBlock4X4RgbFloat block, bool signed)
			{
				int candidates = 0;
				Bc6EncodingHelpers.GetInitialUnscaledEndpoints(block, out var ep0Sub1, out var ep1Sub1);
				if (!signed)
				{
					LeastSquares.OptimizeEndpoints1Sub(block, ref ep0Sub1, ref ep1Sub1);
				}
				ep0Sub1.ClampToHalf();
				ep1Sub1.ClampToHalf();
				if (!signed)
				{
					ep0Sub1.ClampToPositive();
					ep1Sub1.ClampToPositive();
				}
				bool badTransform;
				yield return Bc6ModeEncoder.EncodeBlock1Sub(Bc6BlockType.Type3, block, ep0Sub1, ep1Sub1, signed, out badTransform);
				candidates++;
				bool badTransform2;
				Bc6Block bc6Block = Bc6ModeEncoder.EncodeBlock1Sub(Bc6BlockType.Type15, block, ep0Sub1, ep1Sub1, signed, out badTransform2);
				candidates++;
				if (!badTransform2)
				{
					yield return bc6Block;
					yield break;
				}
				int outputNumClusters;
				int[] array = BptcEncodingHelpers.Rank2SubsetPartitions(CreateClusterIndexBlock(block, out outputNumClusters), outputNumClusters, smallIndex: true);
				int[] array2 = array;
				foreach (int subsetPartition in array2)
				{
					Bc6EncodingHelpers.GetInitialUnscaledEndpointsForSubset(block, out var ep0, out var ep1, subsetPartition, 0);
					Bc6EncodingHelpers.GetInitialUnscaledEndpointsForSubset(block, out var ep2, out var ep3, subsetPartition, 1);
					if (!signed)
					{
						LeastSquares.OptimizeEndpoints2Sub(block, ref ep0, ref ep1, subsetPartition, 0);
						LeastSquares.OptimizeEndpoints2Sub(block, ref ep2, ref ep3, subsetPartition, 1);
					}
					ep0.ClampToHalf();
					ep1.ClampToHalf();
					ep2.ClampToHalf();
					ep3.ClampToHalf();
					if (!signed)
					{
						ep0.ClampToPositive();
						ep1.ClampToPositive();
						ep2.ClampToPositive();
						ep3.ClampToPositive();
					}
					bool badTransform3;
					Bc6Block bc6Block2 = Bc6ModeEncoder.EncodeBlock2Sub(Bc6BlockType.Type1, block, ep0, ep1, ep2, ep3, subsetPartition, signed, out badTransform3);
					candidates++;
					if (!badTransform3)
					{
						yield return bc6Block2;
					}
					if (candidates >= 10)
					{
						break;
					}
					bool badTransform4;
					Bc6Block bc6Block3 = Bc6ModeEncoder.EncodeBlock2Sub(Bc6BlockType.Type14, block, ep0, ep1, ep2, ep3, subsetPartition, signed, out badTransform4);
					candidates++;
					if (!badTransform4)
					{
						yield return bc6Block3;
					}
					if (candidates >= 10)
					{
						break;
					}
				}
			}

			internal static Bc6Block EncodeBlock(RawBlock4X4RgbFloat block, bool signed)
			{
				Bc6Block result = default(Bc6Block);
				float num = 9999999f;
				foreach (Bc6Block item in GenerateCandidates(block, signed))
				{
					float num2 = block.CalculateError(item.Decode(signed));
					if (num2 < num)
					{
						result = item;
						num = num2;
					}
					if (num2 <= 0.001f)
					{
						break;
					}
				}
				return result;
			}
		}

		internal static class Bc6EncoderBestQuality
		{
			private const float TargetError = 0.0005f;

			private const int MaxTries = 500;

			private static IEnumerable<Bc6Block> GenerateCandidates(RawBlock4X4RgbFloat block, bool signed)
			{
				int candidates = 0;
				Bc6EncodingHelpers.GetInitialUnscaledEndpoints(block, out var ep0Sub1, out var ep1Sub1);
				if (!signed)
				{
					LeastSquares.OptimizeEndpoints1Sub(block, ref ep0Sub1, ref ep1Sub1);
				}
				ep0Sub1.ClampToHalf();
				ep1Sub1.ClampToHalf();
				if (!signed)
				{
					ep0Sub1.ClampToPositive();
					ep1Sub1.ClampToPositive();
				}
				bool badTransform;
				yield return Bc6ModeEncoder.EncodeBlock1Sub(Bc6BlockType.Type3, block, ep0Sub1, ep1Sub1, signed, out badTransform);
				candidates++;
				bool badTransform2;
				Bc6Block bc6Block = Bc6ModeEncoder.EncodeBlock1Sub(Bc6BlockType.Type7, block, ep0Sub1, ep1Sub1, signed, out badTransform2);
				candidates++;
				if (!badTransform2)
				{
					yield return bc6Block;
				}
				bool badTransform3;
				Bc6Block bc6Block2 = Bc6ModeEncoder.EncodeBlock1Sub(Bc6BlockType.Type11, block, ep0Sub1, ep1Sub1, signed, out badTransform3);
				candidates++;
				if (!badTransform3)
				{
					yield return bc6Block2;
				}
				bool badTransform4;
				Bc6Block bc6Block3 = Bc6ModeEncoder.EncodeBlock1Sub(Bc6BlockType.Type15, block, ep0Sub1, ep1Sub1, signed, out badTransform4);
				candidates++;
				if (!badTransform4)
				{
					yield return bc6Block3;
				}
				int outputNumClusters;
				int[] array = BptcEncodingHelpers.Rank2SubsetPartitions(CreateClusterIndexBlock(block, out outputNumClusters), outputNumClusters, smallIndex: true);
				int[] array2 = array;
				foreach (int subsetPartition in array2)
				{
					Bc6EncodingHelpers.GetInitialUnscaledEndpointsForSubset(block, out var ep0, out var ep1, subsetPartition, 0);
					Bc6EncodingHelpers.GetInitialUnscaledEndpointsForSubset(block, out var ep2, out var ep3, subsetPartition, 1);
					if (!signed)
					{
						LeastSquares.OptimizeEndpoints2Sub(block, ref ep0, ref ep1, subsetPartition, 0);
						LeastSquares.OptimizeEndpoints2Sub(block, ref ep2, ref ep3, subsetPartition, 1);
					}
					ep0.ClampToHalf();
					ep1.ClampToHalf();
					ep2.ClampToHalf();
					ep3.ClampToHalf();
					if (!signed)
					{
						ep0.ClampToPositive();
						ep1.ClampToPositive();
						ep2.ClampToPositive();
						ep3.ClampToPositive();
					}
					Bc6BlockType[] subsets2Types = Bc6Block.Subsets2Types;
					for (int j = 0; j < subsets2Types.Length; j++)
					{
						bool badTransform5;
						Bc6Block bc6Block4 = Bc6ModeEncoder.EncodeBlock2Sub(subsets2Types[j], block, ep0, ep1, ep2, ep3, subsetPartition, signed, out badTransform5);
						candidates++;
						if (!badTransform5)
						{
							yield return bc6Block4;
						}
						if (candidates >= 500)
						{
							yield break;
						}
					}
				}
			}

			internal static Bc6Block EncodeBlock(RawBlock4X4RgbFloat block, bool signed)
			{
				Bc6Block result = default(Bc6Block);
				float num = 9999999f;
				foreach (Bc6Block item in GenerateCandidates(block, signed))
				{
					float num2 = block.CalculateError(item.Decode(signed));
					if (num2 < num)
					{
						result = item;
						num = num2;
					}
					if (num2 <= 0.0005f)
					{
						break;
					}
				}
				return result;
			}
		}

		private readonly bool signed;

		public Bc6Encoder(bool signed)
		{
			this.signed = signed;
		}

		public override GlInternalFormat GetInternalFormat()
		{
			if (!signed)
			{
				return GlInternalFormat.GlCompressedRgbBptcUnsignedFloatArb;
			}
			return GlInternalFormat.GlCompressedRgbBptcSignedFloatArb;
		}

		public override GlFormat GetBaseInternalFormat()
		{
			return GlFormat.GlRgb;
		}

		public override DxgiFormat GetDxgiFormat()
		{
			if (!signed)
			{
				return DxgiFormat.DxgiFormatBc6HUf16;
			}
			return DxgiFormat.DxgiFormatBc6HSf16;
		}

		public override Bc6Block EncodeBlock(RawBlock4X4RgbFloat block, CompressionQuality quality)
		{
			return quality switch
			{
				CompressionQuality.Fast => Bc6EncoderFast.EncodeBlock(block, signed), 
				CompressionQuality.Balanced => Bc6EncoderBalanced.EncodeBlock(block, signed), 
				CompressionQuality.BestQuality => Bc6EncoderBestQuality.EncodeBlock(block, signed), 
				_ => throw new ArgumentOutOfRangeException("quality", quality, null), 
			};
		}

		internal static ClusterIndices4X4 CreateClusterIndexBlock(RawBlock4X4RgbFloat raw, out int outputNumClusters, int numClusters = 2)
		{
			ClusterIndices4X4 result = default(ClusterIndices4X4);
			int[] array = LinearClustering.ClusterPixels(raw.AsSpan, 4, 4, numClusters, 1f, 10, enforceConnectivity: false);
			Span<int> asSpan = result.AsSpan;
			for (int i = 0; i < asSpan.Length; i++)
			{
				asSpan[i] = array[i];
			}
			int numClusters2 = result.NumClusters;
			if (numClusters2 < numClusters)
			{
				result = result.Reduce(out numClusters2);
			}
			outputNumClusters = numClusters2;
			return result;
		}
	}
}
