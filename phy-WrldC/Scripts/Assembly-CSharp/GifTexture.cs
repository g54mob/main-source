using UnityEngine;
using UnityEngine.UI;

public class GifTexture
{
	public Color32[] m_Colors;

	public int m_Width;

	public int m_Height;

	public Sprite m_Sprite;

	public Texture2D m_texture2d;

	public float m_delaySec;

	private bool _hasCreateTexture;

	private FilterMode _filterMode;

	private TextureWrapMode _wrapMode = TextureWrapMode.Clamp;

	private bool _optimizeMemoryUsage = true;

	public GifTexture(Color32[] colors, int width, int height, float delaySec, FilterMode filterMode, TextureWrapMode wrapMode)
	{
		m_Colors = colors;
		m_Width = width;
		m_Height = height;
		m_delaySec = delaySec;
		_filterMode = filterMode;
		_wrapMode = wrapMode;
	}

	public GifTexture(Texture2D texture2d, float delaySec, bool optimizeMemoryUsgae = true)
	{
		_optimizeMemoryUsage = optimizeMemoryUsgae;
		m_Width = texture2d.width;
		m_Height = texture2d.height;
		_filterMode = texture2d.filterMode;
		_wrapMode = texture2d.wrapMode;
		if (optimizeMemoryUsgae)
		{
			m_Colors = texture2d.GetPixels32();
			Object.Destroy(texture2d);
		}
		else
		{
			m_texture2d = texture2d;
		}
		m_delaySec = delaySec;
	}

	public GifTexture(Sprite sprite, float delaySec, bool optimizeMemoryUsgae = true)
	{
		_optimizeMemoryUsage = optimizeMemoryUsgae;
		if (optimizeMemoryUsgae)
		{
			m_Width = sprite.texture.width;
			m_Height = sprite.texture.height;
			_filterMode = sprite.texture.filterMode;
			_wrapMode = sprite.texture.wrapMode;
			m_Colors = sprite.texture.GetPixels32();
			Object.Destroy(sprite.texture);
		}
		else
		{
			m_Sprite = sprite;
		}
		m_delaySec = delaySec;
	}

	public Texture2D GetTexture2D()
	{
		if (m_texture2d != null)
		{
			return m_texture2d;
		}
		if (!_hasCreateTexture)
		{
			if (m_Colors != null)
			{
				m_texture2d = new Texture2D(m_Width, m_Height, TextureFormat.ARGB32, mipChain: false);
				m_texture2d.filterMode = _filterMode;
				m_texture2d.wrapMode = _wrapMode;
				m_texture2d.SetPixels32(m_Colors);
				m_texture2d.Apply();
			}
			_hasCreateTexture = true;
			if (m_texture2d != null)
			{
				return m_texture2d;
			}
		}
		return GetSprite().texture;
	}

	public Sprite GetSprite()
	{
		if (m_Sprite == null)
		{
			Texture2D texture2D = GetTexture2D();
			m_Sprite = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 100f);
		}
		return m_Sprite;
	}

	public Sprite GetSprite_OptimizeMemoryUsage(ref Texture2D refTexture2d)
	{
		if (!_optimizeMemoryUsage)
		{
			return GetSprite();
		}
		if (m_Sprite == null)
		{
			SetColorsToTexture2D(ref refTexture2d);
			m_Sprite = Sprite.Create(refTexture2d, new Rect(0f, 0f, refTexture2d.width, refTexture2d.height), new Vector2(0.5f, 0.5f), 100f);
		}
		else
		{
			SetColorsToTexture2D(ref refTexture2d);
		}
		return m_Sprite;
	}

	public void SetColorsToTexture2D(ref Texture2D refTexture2d)
	{
		if (!_optimizeMemoryUsage)
		{
			refTexture2d = GetTexture2D();
			return;
		}
		if (refTexture2d == null || refTexture2d.width != m_Width || refTexture2d.height != m_Height)
		{
			refTexture2d = new Texture2D(m_Width, m_Height, TextureFormat.ARGB32, mipChain: false);
		}
		refTexture2d.filterMode = _filterMode;
		refTexture2d.wrapMode = _wrapMode;
		refTexture2d.SetPixels32(m_Colors);
		refTexture2d.Apply();
	}

	public void SetDisplay(Image targetDisplay, ref Texture2D refTexture2d)
	{
		if (!_optimizeMemoryUsage)
		{
			refTexture2d = GetTexture2D();
			targetDisplay.sprite = GetSprite();
		}
		else
		{
			targetDisplay.sprite = GetSprite_OptimizeMemoryUsage(ref refTexture2d);
		}
	}

	public void SetDisplay(RawImage targetDisplay, ref Texture2D refTexture2d)
	{
		if (!_optimizeMemoryUsage)
		{
			refTexture2d = GetTexture2D();
			return;
		}
		SetColorsToTexture2D(ref refTexture2d);
		targetDisplay.texture = refTexture2d;
	}

	public void SetDisplay(Renderer targetDisplay, ref Texture2D refTexture2d)
	{
		if (!_optimizeMemoryUsage)
		{
			refTexture2d = GetTexture2D();
			return;
		}
		SetColorsToTexture2D(ref refTexture2d);
		targetDisplay.material.mainTexture = refTexture2d;
	}
}
