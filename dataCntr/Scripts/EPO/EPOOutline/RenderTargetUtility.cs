using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

namespace EPOOutline
{
	public static class RenderTargetUtility
	{
		public struct RenderTextureInfo
		{
			public readonly RenderTextureDescriptor Descriptor;

			public RenderTextureInfo(RenderTextureDescriptor descriptor)
			{
				Descriptor = default(RenderTextureDescriptor);
			}
		}

		private static RenderTextureFormat? hdrFormat;

		public static RenderTextureFormat GetRTFormat(bool useHDR)
		{
			return default(RenderTextureFormat);
		}

		public static int GetDepthSliceForEye(StereoTargetEyeMask mask)
		{
			return 0;
		}

		public static RenderTargetIdentifier ComposeTarget(OutlineParameters parameters, RenderTargetIdentifier target)
		{
			return default(RenderTargetIdentifier);
		}

		public static RenderTextureInfo GetTargetInfo(OutlineParameters parameters, int width, int height)
		{
			return default(RenderTextureInfo);
		}

		public static RTHandle GetRT(OutlineParameters parameters, int width, int height, string name)
		{
			return null;
		}

		public static RenderTextureFormat GetHDRTextureFormat()
		{
			return default(RenderTextureFormat);
		}

		public static GraphicsFormat GetHDRGraphicsFormat()
		{
			return default(GraphicsFormat);
		}
	}
}
