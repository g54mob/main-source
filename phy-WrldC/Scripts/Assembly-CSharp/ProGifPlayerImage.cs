using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public sealed class ProGifPlayerImage : ProGifPlayerComponent
{
	[HideInInspector]
	public Image destinationImage;

	private List<Image> m_ExtraImages = new List<Image>();

	private Texture2D _displayTexture2D;

	private Sprite _displaySprite;

	private void Awake()
	{
		if (destinationImage == null)
		{
			destinationImage = base.gameObject.GetComponent<Image>();
		}
	}

	private void Update()
	{
		if (base.State != PlayerState.Playing || displayType != DisplayType.Image)
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
		if (m_ExtraImages == null || m_ExtraImages.Count <= 0)
		{
			return;
		}
		Sprite sprite = null;
		sprite = ((!optimizeMemoryUsage) ? gifTextures[spriteIndex].GetSprite() : _displaySprite);
		for (int i = 0; i < m_ExtraImages.Count; i++)
		{
			if (m_ExtraImages[i] != null)
			{
				m_ExtraImages[i].sprite = sprite;
				continue;
			}
			m_ExtraImages.Remove(m_ExtraImages[i]);
			m_ExtraImages.TrimExcess();
		}
	}

	public override void Play(RenderTexture[] gifFrames, int fps, bool isCustomRatio, int customWidth, int customHeight, bool optimizeMemoryUsage)
	{
		base.Play(gifFrames, fps, isCustomRatio, customWidth, customHeight, optimizeMemoryUsage);
		if (destinationImage == null)
		{
			destinationImage = base.gameObject.GetComponent<Image>();
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
			_displaySprite = gifTextures[spriteIndex].GetSprite_OptimizeMemoryUsage(ref _displayTexture2D);
		}
		if (destinationImage != null)
		{
			if (optimizeMemoryUsage)
			{
				destinationImage.sprite = _displaySprite;
			}
			else
			{
				destinationImage.sprite = gifTextures[spriteIndex].GetSprite();
			}
		}
	}

	public override void Clear()
	{
		if (optimizeMemoryUsage)
		{
			if (_displayTexture2D != null)
			{
				Object.Destroy(_displayTexture2D);
				_displayTexture2D = null;
			}
			_displaySprite = null;
		}
		base.Clear();
	}

	public void ChangeDestination(Image image)
	{
		destinationImage = image;
	}

	public void AddExtraDestination(Image image)
	{
		if (!m_ExtraImages.Contains(image))
		{
			m_ExtraImages.Add(image);
		}
	}

	public void RemoveFromExtraDestination(Image image)
	{
		if (m_ExtraImages.Contains(image))
		{
			m_ExtraImages.Remove(image);
			m_ExtraImages.TrimExcess();
		}
	}
}
