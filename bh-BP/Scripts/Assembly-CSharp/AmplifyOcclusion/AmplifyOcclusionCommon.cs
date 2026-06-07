using UnityEngine;
using UnityEngine.Rendering;

namespace AmplifyOcclusion
{
	public static class AmplifyOcclusionCommon
	{
		public static readonly int PerPixelNormalSourceCount;

		public static readonly float[] m_temporalRotations;

		public static readonly float[] m_spatialOffsets;

		public static void CommandBuffer_TemporalFilterDirectionsOffsets(CommandBuffer cb, uint aSampleStep)
		{
		}

		public static Material CreateMaterialWithShaderName(string aShaderName, bool aThroughErrorMsg)
		{
			return null;
		}

		public static int SafeAllocateTemporaryRT(CommandBuffer cb, string propertyName, int width, int height, RenderTextureFormat format = RenderTextureFormat.Default, RenderTextureReadWrite readWrite = RenderTextureReadWrite.Default, FilterMode filterMode = FilterMode.Point)
		{
			return 0;
		}

		public static void SafeReleaseTemporaryRT(CommandBuffer cb, int id)
		{
		}

		public static RenderTexture SafeAllocateRT(string name, int width, int height, RenderTextureFormat format, RenderTextureReadWrite readWrite, FilterMode filterMode = FilterMode.Point, int antiAliasing = 1, bool aUseMipMap = false)
		{
			return null;
		}

		public static void SafeReleaseRT(ref RenderTexture rt)
		{
		}

		public static bool IsStereoSinglePassEnabled(Camera aCamera)
		{
			return false;
		}

		public static bool IsStereoMultiPassEnabled(Camera aCamera)
		{
			return false;
		}

		public static void UpdateGlobalShaderConstants(CommandBuffer cb, ref TargetDesc aTarget, Camera aCamera, bool isDownsample, bool isFilterDownsample)
		{
		}
	}
}
