using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

namespace DV.Highlighting
{
	[ExecuteInEditMode]
	[AddComponentMenu("Rendering/Highlight")]
	public class Highlight : MonoBehaviour
	{
		private readonly int highlightTextureId = Shader.PropertyToID("_HighlightTexture");

		private readonly int currentHighlightColorId = Shader.PropertyToID("_CurrentHighlightColor");

		private readonly int paletteTextureId = Shader.PropertyToID("_HighlightPaletteTexture");

		private const int MAX_COLORS = 60;

		private readonly Dictionary<Color, int> palette = new Dictionary<Color, int>();

		private readonly Dictionary<Renderer, int> renderers = new Dictionary<Renderer, int>();

		private Texture2D paletteTexture;

		public Camera targetCamera;

		public Material imageEffectMaterial;

		public Material meshRenderMaterial;

		private CommandBuffer commandBuffer;

		private void Awake()
		{
			HighlightEffectRenderer.RenderEffects += Render;
			paletteTexture = new Texture2D(64, 1, TextureFormat.RGBA32, mipChain: false, linear: true)
			{
				filterMode = FilterMode.Point,
				wrapMode = TextureWrapMode.Clamp
			};
		}

		private void OnDestroy()
		{
			HighlightEffectRenderer.RenderEffects -= Render;
		}

		private int GetPaletteIndexFor(Color c)
		{
			if (!palette.TryGetValue(c, out var value))
			{
				if (palette.Count >= 60)
				{
					Debug.LogWarning("Palette is full, can't add more colors! Defaulting to first one.");
					return 0;
				}
				value = palette.Count + 1;
				palette.Add(c, value);
				paletteTexture.SetPixel(value, 0, c);
				paletteTexture.Apply();
			}
			return value;
		}

		public void AddRenderer(Renderer r, Color c, bool showObstructed)
		{
			int num = GetPaletteIndexFor(c);
			if (!showObstructed)
			{
				num += 64;
			}
			renderers[r] = num;
		}

		public void RemoveRenderer(Renderer r)
		{
			renderers.Remove(r);
		}

		private void Render(PostProcessRenderContext context)
		{
			if (meshRenderMaterial == null || imageEffectMaterial == null || targetCamera == null || renderers.Count == 0)
			{
				return;
			}
			commandBuffer = context.command;
			commandBuffer.GetTemporaryRT(highlightTextureId, targetCamera.pixelWidth, targetCamera.pixelHeight, 16, FilterMode.Point, RenderTextureFormat.R8, RenderTextureReadWrite.Default, 1);
			commandBuffer.SetRenderTarget(highlightTextureId);
			commandBuffer.ClearRenderTarget(clearDepth: true, clearColor: true, Color.clear);
			commandBuffer.SetGlobalTexture(paletteTextureId, paletteTexture);
			foreach (KeyValuePair<Renderer, int> renderer in renderers)
			{
				if ((bool)renderer.Key)
				{
					commandBuffer.SetGlobalInt(currentHighlightColorId, renderer.Value);
					commandBuffer.DrawRenderer(renderer.Key, meshRenderMaterial);
				}
			}
			commandBuffer.Blit(highlightTextureId, context.destination, imageEffectMaterial);
			commandBuffer.ReleaseTemporaryRT(highlightTextureId);
		}
	}
}
