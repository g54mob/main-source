using UnityEngine;

namespace SSAA
{
	public class TextureRenderer : MonoBehaviour
	{
		public Material SamplingMaterial;

		private Camera c;

		public bool stereoFirstPass = true;

		public RenderTexture text;

		private void Awake()
		{
			c = GetComponent<Camera>();
			if (c == null)
			{
				Debug.LogError("TextureRenderer init fail! (no Camera)");
				base.enabled = false;
			}
		}

		private void LateUpdate()
		{
			foreach (internal_SSAA instances in internal_SSAA.InstancesList)
			{
				if (instances.RenderingCamera.depth >= c.depth)
				{
					c.depth = instances.RenderingCamera.depth + 0.5f;
				}
			}
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			text = internal_SSAA.RenderTexture;
			if (SamplingMaterial != null)
			{
				SamplingMaterial.SetFloat("_textureWidth", internal_SSAA.RenderTexture.width);
				SamplingMaterial.SetFloat("_textureHeight", internal_SSAA.RenderTexture.height);
				SamplingMaterial.SetTexture("_MainTex", internal_SSAA.RenderTexture);
				Graphics.Blit(internal_SSAA.RenderTexture, destination, SamplingMaterial);
			}
			else
			{
				Graphics.Blit(internal_SSAA.RenderTexture, destination);
			}
			if (c.stereoEnabled)
			{
				if (stereoFirstPass)
				{
					stereoFirstPass = false;
					return;
				}
				internal_SSAA.RenderTexture.DiscardContents();
				stereoFirstPass = true;
			}
			else
			{
				internal_SSAA.RenderTexture.DiscardContents();
			}
		}
	}
}
