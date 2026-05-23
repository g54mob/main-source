using UnityEngine;

namespace EPOOutline
{
	public static class XRUtility
	{
		public static bool IsXRActive => false;

		public static RenderTextureDescriptor VRRenderTextureDescriptor => default(RenderTextureDescriptor);

		public static bool IsUsingVR(OutlineParameters parameters)
		{
			return false;
		}
	}
}
