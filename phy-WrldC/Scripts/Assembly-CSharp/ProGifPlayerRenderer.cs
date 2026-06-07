using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public sealed class ProGifPlayerRenderer : ProGifPlayerComponent
{
	[HideInInspector]
	public Renderer destinationRenderer;

	private List<Renderer> m_ExtraRenderers = new List<Renderer>();

	private Texture2D _displayTexture2D;

	private void Awake()
	{
		if (destinationRenderer == null)
		{
			destinationRenderer = base.gameObject.GetComponent<Renderer>();
		}
	}

	private void Update()
	{
		if (base.State != PlayerState.Playing || displayType != DisplayType.Renderer)
		{
			return;
		}
		if (Time.time >= nextFrameTime)
		{
			spriteIndex = ((spriteIndex < gifTextures.Count - 1) ? (spriteIndex + 1) : 0);
			nextFrameTime = Time.time + interval;
		}
		if (spriteIndex >= gifTextures.Count)
		{
			return;
		}
		if (OnPlayingCallback != null)
		{
			OnPlayingCallback(gifTextures[spriteIndex]);
		}
		_SetDisplay(spriteIndex);
		if (m_ExtraRenderers == null || m_ExtraRenderers.Count <= 0)
		{
			return;
		}
		Texture2D texture2D = null;
		texture2D = ((!optimizeMemoryUsage) ? gifTextures[spriteIndex].GetTexture2D() : _displayTexture2D);
		for (int i = 0; i < m_ExtraRenderers.Count; i++)
		{
			if (m_ExtraRenderers[i] != null)
			{
				m_ExtraRenderers[i].material.mainTexture = texture2D;
				continue;
			}
			m_ExtraRenderers.Remove(m_ExtraRenderers[i]);
			m_ExtraRenderers.TrimExcess();
		}
	}

	public override void Play(RenderTexture[] gifFrames, int fps, bool isCustomRatio, int customWidth, int customHeight, bool optimizeMemoryUsage)
	{
		base.Play(gifFrames, fps, isCustomRatio, customWidth, customHeight, optimizeMemoryUsage);
		if (destinationRenderer == null)
		{
			destinationRenderer = base.gameObject.GetComponent<Renderer>();
		}
		_SetDisplay(0);
	}

	protected override void _OnFrameReady(GifTexture gTex, bool isFirstFrame)
	{
		if (isFirstFrame)
		{
			_SetDisplay(0);
		}
	}

	private void _SetDisplay(int spriteIndex)
	{
		if (optimizeMemoryUsage)
		{
			gifTextures[spriteIndex].SetColorsToTexture2D(ref _displayTexture2D);
		}
		if (destinationRenderer != null && destinationRenderer.material != null)
		{
			if (optimizeMemoryUsage)
			{
				destinationRenderer.material.mainTexture = _displayTexture2D;
			}
			else
			{
				destinationRenderer.material.mainTexture = gifTextures[spriteIndex].GetTexture2D();
			}
		}
	}

	public override void Clear()
	{
		if (_displayTexture2D != null)
		{
			Object.Destroy(_displayTexture2D);
		}
		base.Clear();
	}

	public void ChangeDestination(Renderer renderer)
	{
		destinationRenderer = renderer;
	}

	public void AddExtraDestination(Renderer renderer)
	{
		if (!m_ExtraRenderers.Contains(renderer))
		{
			m_ExtraRenderers.Add(renderer);
		}
	}

	public void RemoveFromExtraDestination(Renderer renderer)
	{
		if (m_ExtraRenderers.Contains(renderer))
		{
			m_ExtraRenderers.Remove(renderer);
			m_ExtraRenderers.TrimExcess();
		}
	}
}
