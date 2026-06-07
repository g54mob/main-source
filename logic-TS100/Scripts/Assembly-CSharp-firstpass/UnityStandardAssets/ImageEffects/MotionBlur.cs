using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	[AddComponentMenu("Image Effects/Blur/Motion Blur (Color Accumulation)")]
	[RequireComponent(typeof(Camera))]
	[ExecuteInEditMode]
	public class MotionBlur : ImageEffectBase
	{
		private RenderTexture accumTextureInput;

		private RenderTexture accumTextureOutput;

		protected override void Start()
		{
			if (!SystemInfo.supportsRenderTextures)
			{
				base.enabled = false;
			}
			else
			{
				base.Start();
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			Object.DestroyImmediate(accumTextureInput);
			Object.DestroyImmediate(accumTextureOutput);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			if (accumTextureInput == null || accumTextureInput.width != source.width || accumTextureInput.height != source.height)
			{
				Object.DestroyImmediate(accumTextureInput);
				accumTextureInput = new RenderTexture(source.width, source.height, 0);
				accumTextureInput.hideFlags = HideFlags.HideAndDontSave;
				accumTextureOutput = new RenderTexture(source.width, source.height, 0);
				accumTextureOutput.hideFlags = HideFlags.HideAndDontSave;
				Graphics.Blit(source, accumTextureInput);
				Graphics.Blit(source, accumTextureOutput);
			}
			base.material.SetTexture("_AccumTex", accumTextureInput);
			accumTextureInput.MarkRestoreExpected();
			accumTextureOutput.MarkRestoreExpected();
			Graphics.Blit(source, accumTextureOutput, base.material);
			Graphics.Blit(accumTextureOutput, destination);
			Graphics.Blit(accumTextureOutput, accumTextureInput);
		}
	}
}
