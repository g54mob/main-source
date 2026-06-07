using UnityEngine;
using UnityEngine.Rendering;

namespace EPOOutline
{
	public static class RenderTargetUtility
	{
		public struct RenderTextureInfo
		{
			public readonly RenderTextureDescriptor Descriptor;

			public readonly FilterMode FilterMode;

			public RenderTextureInfo(RenderTextureDescriptor descriptor, FilterMode filterMode)
			{
				Descriptor = default(RenderTextureDescriptor);
				FilterMode = default(FilterMode);
			}
		}

		private static RenderTextureFormat? hdrFormat;

		public static int GetDepthSliceForEye(StereoTargetEyeMask mask)
		{
			return 0;
		}

		public static RenderTargetIdentifier ComposeTarget(OutlineParameters parameters, RenderTargetIdentifier target)
		{
			return default(RenderTargetIdentifier);
		}

		public static bool IsUsingVR(OutlineParameters parameters)
		{
			return false;
		}

		public static RenderTextureInfo GetTargetInfo(OutlineParameters parameters, int width, int height, int depthBuffer, bool forceNoAA, bool noFiltering)
		{
			return default(RenderTextureInfo);
		}

		public static void GetTemporaryRT(OutlineParameters parameters, int id, int width, int height, int depthBuffer, bool clear, bool forceNoAA, bool noFiltering)
		{
		}

		private static RenderTextureFormat GetHDRFormat()
		{
			return default(RenderTextureFormat);
		}
	}
}
