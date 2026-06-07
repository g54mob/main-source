using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public sealed class ProGifPlayerRawImage : ProGifPlayerComponent
{
	[HideInInspector]
	public RawImage destinationRawImage;

	private List<RawImage> m_ExtraRawImages = new List<RawImage>();

	private Texture2D _displayTexture2D;

	private void Awake()
	{
		if (destinationRawImage == null)
		{
			destinationRawImage = base.gameObject.GetComponent<RawImage>();
		}
	}

	private void Update()
	{
		if (base.State != PlayerState.Playing || displayType != DisplayType.RawImage)
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
		if (m_ExtraRawImages == null || m_ExtraRawImages.Count <= 0)
		{
			return;
		}
		Texture2D texture2D = null;
		texture2D = ((!optimizeMemoryUsage) ? gifTextures[spriteIndex].GetTexture2D() : _displayTexture2D);
		for (int i = 0; i < m_ExtraRawImages.Count; i++)
		{
			if (m_ExtraRawImages[i] != null)
			{
				m_ExtraRawImages[i].texture = texture2D;
				continue;
			}
			m_ExtraRawImages.Remove(m_ExtraRawImages[i]);
			m_ExtraRawImages.TrimExcess();
		}
	}

	public override void Play(RenderTexture[] gifFrames, int fps, bool isCustomRatio, int customWidth, int customHeight, bool optimizeMemoryUsage)
	{
		base.Play(gifFrames, fps, isCustomRatio, customWidth, customHeight, optimizeMemoryUsage);
		if (destinationRawImage == null)
		{
			destinationRawImage = base.gameObject.GetComponent<RawImage>();
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
		if (destinationRawImage != null)
		{
			if (optimizeMemoryUsage)
			{
				destinationRawImage.texture = _displayTexture2D;
			}
			else
			{
				destinationRawImage.texture = gifTextures[spriteIndex].GetTexture2D();
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

	public void ChangeDestination(RawImage rawImage)
	{
		destinationRawImage = rawImage;
	}

	public void AddExtraDestination(RawImage rawImage)
	{
		if (!m_ExtraRawImages.Contains(rawImage))
		{
			m_ExtraRawImages.Add(rawImage);
		}
	}

	public void RemoveFromExtraDestination(RawImage rawImage)
	{
		if (m_ExtraRawImages.Contains(rawImage))
		{
			m_ExtraRawImages.Remove(rawImage);
			m_ExtraRawImages.TrimExcess();
		}
	}
}
