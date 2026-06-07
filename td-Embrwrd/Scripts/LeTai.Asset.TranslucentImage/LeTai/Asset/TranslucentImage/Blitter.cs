using UnityEngine;
using UnityEngine.Rendering;

namespace LeTai.Asset.TranslucentImage
{
	public static class Blitter
	{
		private static Mesh fullscreenTriangle;

		private static Mesh FullscreenTriangle => null;

		public static void Blit(CommandBuffer cmd, RenderTargetIdentifier source, RenderTargetIdentifier destination, Material material, int passIndex, MaterialPropertyBlock propertyBlock = null, Rect viewport = default(Rect))
		{
		}
	}
}
