using UnityEngine;

namespace TH20
{
	public static class RenderTextureFactory
	{
		public static RenderTexture Create(int width, int height, int depth, RenderTextureFormat format, Color clearColour)
		{
			RenderTexture renderTexture = new RenderTexture(width, height, depth, format);
			renderTexture.Create();
			ClearMemory(renderTexture, clearColour);
			return renderTexture;
		}

		public static RenderTexture Create(RenderTextureDescriptor descriptor, Color clearColour)
		{
			RenderTexture renderTexture = new RenderTexture(descriptor);
			renderTexture.Create();
			ClearMemory(renderTexture, clearColour);
			return renderTexture;
		}

		public static void ClearMemory(RenderTexture renderTexture, Color clearColour)
		{
			if (!(renderTexture == null))
			{
				RenderTexture active = RenderTexture.active;
				RenderTexture.active = renderTexture;
				GL.Clear(clearDepth: true, clearColor: true, clearColour);
				RenderTexture.active = active;
			}
		}
	}
}
