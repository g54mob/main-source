using System;
using System.Collections.Generic;
using BCnEncoder.Shared;
using BCnEncoder.Shared.ImageFiles;

namespace BCnEncoder.Encoder.Bptc
{
	internal class Bc7Encoder : BaseBcBlockEncoder<Bc7Block, RawBlock4X4Rgba32>
	{
		private static class Bc7EncoderFast
		{
			private const float ErrorThreshold = 0.005f;

			private const int MaxTries = 5;

			private static IEnumerable<Bc7Block> TryMethods(RawBlock4X4Rgba32 rawBlock, int[] best2SubsetPartitions, int[] best3SubsetPartitions, bool alpha)
			{
				if (alpha)
				{
					yield return Bc7Mode6Encoder.EncodeBlock(rawBlock, 5);
					yield return Bc7Mode5Encoder.EncodeBlock(rawBlock, 3);
					yield break;
				}
				yield return Bc7Mode6Encoder.EncodeBlock(rawBlock, 6);
				for (int i = 0; i < 64; i++)
				{
					if (best3SubsetPartitions[i] < 16)
					{
						yield return Bc7Mode0Encoder.EncodeBlock(rawBlock, 3, best3SubsetPartitions[i]);
					}
					yield return Bc7Mode1Encoder.EncodeBlock(rawBlock, 4, best2SubsetPartitions[i]);
				}
			}

			public static Bc7Block EncodeBlock(RawBlock4X4Rgba32 rawBlock)
			{
				bool alpha = rawBlock.HasTransparentPixels();
				int outputNumClusters;
				ClusterIndices4X4 reducedIndicesBlock = CreateClusterIndexBlock(rawBlock, out outputNumClusters, 2);
				int outputNumClusters2;
				ClusterIndices4X4 clusterIndices4X = CreateClusterIndexBlock(rawBlock, out outputNumClusters2);
				if (outputNumClusters < 2)
				{
					outputNumClusters = outputNumClusters2;
					reducedIndicesBlock = clusterIndices4X;
				}
				int[] best2SubsetPartitions = BptcEncodingHelpers.Rank2SubsetPartitions(reducedIndicesBlock, outputNumClusters);
				int[] best3SubsetPartitions = BptcEncodingHelpers.Rank3SubsetPartitions(clusterIndices4X, outputNumClusters2);
				float num = 99999f;
				Bc7Block result = default(Bc7Block);
				int num2 = 0;
				foreach (Bc7Block item in TryMethods(rawBlock, best2SubsetPartitions, best3SubsetPartitions, alpha))
				{
					RawBlock4X4Rgba32 other = item.Decode();
					float num3 = rawBlock.CalculateYCbCrAlphaError(other);
					num2++;
					if (num3 < num)
					{
						result = item;
						num = num3;
					}
					if (num3 < 0.005f || num2 > 5)
					{
						break;
					}
				}
				return result;
			}
		}

		private static class Bc7EncoderBalanced
		{
			private const float ErrorThreshold = 0.005f;

			private const int MaxTries = 25;

			private static IEnumerable<Bc7Block> TryMethods(RawBlock4X4Rgba32 rawBlock, int[] best2SubsetPartitions, int[] best3SubsetPartitions, bool alpha)
			{
				if (alpha)
				{
					yield return Bc7Mode6Encoder.EncodeBlock(rawBlock, 6);
					yield return Bc7Mode5Encoder.EncodeBlock(rawBlock, 4);
					yield return Bc7Mode4Encoder.EncodeBlock(rawBlock, 4);
					for (int i = 0; i < 64; i++)
					{
						yield return Bc7Mode7Encoder.EncodeBlock(rawBlock, 3, best2SubsetPartitions[i]);
					}
					yield break;
				}
				yield return Bc7Mode6Encoder.EncodeBlock(rawBlock, 6);
				yield return Bc7Mode5Encoder.EncodeBlock(rawBlock, 4);
				yield return Bc7Mode4Encoder.EncodeBlock(rawBlock, 4);
				for (int i = 0; i < 64; i++)
				{
					if (best3SubsetPartitions[i] < 16)
					{
						yield return Bc7Mode0Encoder.EncodeBlock(rawBlock, 3, best3SubsetPartitions[i]);
					}
					else
					{
						yield return Bc7Mode2Encoder.EncodeBlock(rawBlock, 5, best3SubsetPartitions[i]);
					}
					yield return Bc7Mode1Encoder.EncodeBlock(rawBlock, 4, best2SubsetPartitions[i]);
				}
			}

			public static Bc7Block EncodeBlock(RawBlock4X4Rgba32 rawBlock)
			{
				bool alpha = rawBlock.HasTransparentPixels();
				int outputNumClusters;
				ClusterIndices4X4 reducedIndicesBlock = CreateClusterIndexBlock(rawBlock, out outputNumClusters, 2);
				int outputNumClusters2;
				ClusterIndices4X4 clusterIndices4X = CreateClusterIndexBlock(rawBlock, out outputNumClusters2);
				if (outputNumClusters < 2)
				{
					outputNumClusters = outputNumClusters2;
					reducedIndicesBlock = clusterIndices4X;
				}
				int[] best2SubsetPartitions = BptcEncodingHelpers.Rank2SubsetPartitions(reducedIndicesBlock, outputNumClusters);
				int[] best3SubsetPartitions = BptcEncodingHelpers.Rank3SubsetPartitions(clusterIndices4X, outputNumClusters2);
				float num = 99999f;
				Bc7Block result = default(Bc7Block);
				int num2 = 0;
				foreach (Bc7Block item in TryMethods(rawBlock, best2SubsetPartitions, best3SubsetPartitions, alpha))
				{
					RawBlock4X4Rgba32 other = item.Decode();
					float num3 = rawBlock.CalculateYCbCrAlphaError(other);
					num2++;
					if (num3 < num)
					{
						result = item;
						num = num3;
					}
					if (num3 < 0.005f || num2 > 25)
					{
						break;
					}
				}
				return result;
			}
		}

		private static class Bc7EncoderBestQuality
		{
			private const float ErrorThreshold = 0.001f;

			private const int MaxTries = 40;

			private static IEnumerable<Bc7Block> TryMethods(RawBlock4X4Rgba32 rawBlock, int[] best2SubsetPartitions, int[] best3SubsetPartitions, bool alpha)
			{
				if (alpha)
				{
					yield return Bc7Mode6Encoder.EncodeBlock(rawBlock, 8);
					yield return Bc7Mode5Encoder.EncodeBlock(rawBlock, 5);
					yield return Bc7Mode4Encoder.EncodeBlock(rawBlock, 5);
					for (int i = 0; i < 64; i++)
					{
						yield return Bc7Mode7Encoder.EncodeBlock(rawBlock, 4, best2SubsetPartitions[i]);
					}
					yield break;
				}
				yield return Bc7Mode6Encoder.EncodeBlock(rawBlock, 8);
				yield return Bc7Mode5Encoder.EncodeBlock(rawBlock, 5);
				yield return Bc7Mode4Encoder.EncodeBlock(rawBlock, 5);
				for (int i = 0; i < 64; i++)
				{
					if (best3SubsetPartitions[i] < 16)
					{
						yield return Bc7Mode0Encoder.EncodeBlock(rawBlock, 4, best3SubsetPartitions[i]);
					}
					yield return Bc7Mode2Encoder.EncodeBlock(rawBlock, 5, best3SubsetPartitions[i]);
					yield return Bc7Mode1Encoder.EncodeBlock(rawBlock, 4, best2SubsetPartitions[i]);
					yield return Bc7Mode3Encoder.EncodeBlock(rawBlock, 5, best2SubsetPartitions[i]);
				}
			}

			public static Bc7Block EncodeBlock(RawBlock4X4Rgba32 rawBlock)
			{
				bool alpha = rawBlock.HasTransparentPixels();
				int outputNumClusters;
				ClusterIndices4X4 reducedIndicesBlock = CreateClusterIndexBlock(rawBlock, out outputNumClusters, 2);
				int outputNumClusters2;
				ClusterIndices4X4 clusterIndices4X = CreateClusterIndexBlock(rawBlock, out outputNumClusters2);
				if (outputNumClusters < 2)
				{
					outputNumClusters = outputNumClusters2;
					reducedIndicesBlock = clusterIndices4X;
				}
				int[] best2SubsetPartitions = BptcEncodingHelpers.Rank2SubsetPartitions(reducedIndicesBlock, outputNumClusters);
				int[] best3SubsetPartitions = BptcEncodingHelpers.Rank3SubsetPartitions(clusterIndices4X, outputNumClusters2);
				float num = 99999f;
				Bc7Block result = default(Bc7Block);
				int num2 = 0;
				foreach (Bc7Block item in TryMethods(rawBlock, best2SubsetPartitions, best3SubsetPartitions, alpha))
				{
					RawBlock4X4Rgba32 other = item.Decode();
					float num3 = rawBlock.CalculateYCbCrAlphaError(other);
					num2++;
					if (num3 < num)
					{
						result = item;
						num = num3;
					}
					if (num3 < 0.001f || num2 > 40)
					{
						break;
					}
				}
				return result;
			}
		}

		public override Bc7Block EncodeBlock(RawBlock4X4Rgba32 rawBlock, CompressionQuality quality)
		{
			return quality switch
			{
				CompressionQuality.Fast => Bc7EncoderFast.EncodeBlock(rawBlock), 
				CompressionQuality.Balanced => Bc7EncoderBalanced.EncodeBlock(rawBlock), 
				CompressionQuality.BestQuality => Bc7EncoderBestQuality.EncodeBlock(rawBlock), 
				_ => throw new ArgumentOutOfRangeException("quality", quality, null), 
			};
		}

		public override GlInternalFormat GetInternalFormat()
		{
			return GlInternalFormat.GlCompressedRgbaBptcUnormArb;
		}

		public override GlFormat GetBaseInternalFormat()
		{
			return GlFormat.GlRgba;
		}

		public override DxgiFormat GetDxgiFormat()
		{
			return DxgiFormat.DxgiFormatBc7Unorm;
		}

		private static ClusterIndices4X4 CreateClusterIndexBlock(RawBlock4X4Rgba32 raw, out int outputNumClusters, int numClusters = 3)
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
