using System;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace LeTai.Asset.TranslucentImage.UniversalRP
{
	internal class URPRendererInternal
	{
		private ScriptableRenderer renderer;

		private Func<RTHandle> getBackBufferDelegate;

		private Func<RTHandle> getAfterPostColorDelegate;

		public void CacheRenderer(ScriptableRenderer renderer)
		{
		}

		public RenderTargetIdentifier GetBackBuffer()
		{
			return default(RenderTargetIdentifier);
		}

		public RenderTargetIdentifier GetAfterPostColor()
		{
			return default(RenderTargetIdentifier);
		}
	}
}
