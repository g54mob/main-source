using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	[RequireComponent(typeof(Camera))]
	[AddComponentMenu("Image Effects/Other/Screen Overlay")]
	[ExecuteInEditMode]
	public class ScreenOverlay : PostEffectsBase
	{
		public enum OverlayBlendMode
		{
			Additive = 0,
			ScreenBlend = 1,
			Multiply = 2,
			Overlay = 3,
			AlphaBlend = 4
		}

		public OverlayBlendMode blendMode = OverlayBlendMode.Overlay;

		public float intensity = 1f;

		public Texture2D texture;

		public RenderTexture textureRT;

		public Shader overlayShader;

		private Material overlayMaterial;

		private void OnDestroy()
		{
			texture = null;
			textureRT = null;
			if (overlayMaterial != null)
			{
				overlayMaterial.SetTexture("_Overlay", null);
			}
		}

		public override bool CheckResources()
		{
			CheckSupport(false);
			overlayMaterial = CheckShaderAndCreateMaterial(overlayShader, overlayMaterial);
			if (!isSupported)
			{
				ReportAutoDisable();
			}
			return isSupported;
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			if (!CheckResources())
			{
				Graphics.Blit(source, destination);
				return;
			}
			Vector4 vector = new Vector4(1f, 0f, 0f, 1f);
			overlayMaterial.SetVector("_UV_Transform", vector);
			overlayMaterial.SetFloat("_Intensity", intensity);
			if (texture != null)
			{
				overlayMaterial.SetTexture("_Overlay", texture);
			}
			else if (textureRT != null)
			{
				overlayMaterial.SetTexture("_Overlay", textureRT);
			}
			Graphics.Blit(source, destination, overlayMaterial, (int)blendMode);
		}
	}
}
