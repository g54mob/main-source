using UnityEngine;
using UnityEngine.Rendering;

namespace HighlightPlus
{
	public static class RenderingUtils
	{
		private static Mesh _fullScreenMesh;

		private static Matrix4x4 matrix4x4Identity;

		private static Mesh fullscreenMesh => null;

		public static void FullScreenBlit(CommandBuffer cmd, RenderTargetIdentifier source, RenderTargetIdentifier destination, Material material, int passIndex)
		{
		}
	}
}
