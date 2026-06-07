using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace JBooth.MicroVerseCore
{
	public class JumpFloodSDF
	{
		private static Shader jumpFloodShader;

		public static RenderTexture CreateTemporaryRT(Texture source, int channel = 0, float zoom = 1f, int downscale = 1, bool r8 = false)
		{
			if (source == null)
			{
				return null;
			}
			int num = (int)((float)source.width / zoom);
			int num2 = (int)((float)source.height / zoom);
			num /= downscale;
			num2 /= downscale;
			RenderTexture output = ((!r8) ? RenderTexture.GetTemporary(num, num2, 0, RenderTextureFormat.RHalf) : RenderTexture.GetTemporary(num, num2, 0, GraphicsFormat.R8_UNorm));
			return Generate(source, output, channel, zoom, downscale);
		}

		private static RenderTexture Generate(Texture source, RenderTexture output, int channel, float zoom, int downscale)
		{
			if (jumpFloodShader == null)
			{
				jumpFloodShader = Shader.Find("Hidden/MicroVerse/JumpFloodSDF");
			}
			Material material = new Material(jumpFloodShader);
			material.SetInt("_Channel", channel);
			RenderTexture renderTexture = RenderTexture.GetTemporary(source.height, source.width, 0, RenderTextureFormat.RGHalf);
			RenderTexture renderTexture2 = RenderTexture.GetTemporary(source.height, source.width, 0, RenderTextureFormat.RGHalf);
			Graphics.Blit(source, renderTexture, material, 0);
			for (int num = 8 - 1; num >= 0; num--)
			{
				material.SetFloat("_StepWidth", Mathf.Pow(2f, num) + 0.5f);
				Graphics.Blit(renderTexture, renderTexture2, material, 1);
				RenderTexture renderTexture3 = renderTexture2;
				RenderTexture renderTexture4 = renderTexture;
				renderTexture = renderTexture3;
				renderTexture2 = renderTexture4;
			}
			material.SetFloat("_Zoom", zoom);
			Graphics.Blit(renderTexture, output, material, 2);
			RenderTexture.active = null;
			RenderTexture.ReleaseTemporary(renderTexture);
			RenderTexture.ReleaseTemporary(renderTexture2);
			return output;
		}
	}
}
