using UnityEngine;
using UnityEngine.UI;

public class DImageDisplayHandler : MonoBehaviour
{
	public enum BoundingTarget
	{
		Size = 0,
		RectTransform = 1,
		Screen = 2
	}

	public enum BoundingType
	{
		SetNativeSize = 0,
		WidthAndHeight = 1,
		Width = 2,
		Height = 3
	}

	[Header("[ Image Display Handler ]")]
	public BoundingTarget m_BoundingTarget;

	public RectTransform m_RectTransform;

	public Vector2 m_Size = new Vector2(512f, 512f);

	[Space]
	public BoundingType m_BoundingType;

	[Space]
	public float m_ScaleFactor = 1f;

	[Space]
	[Tooltip("Auto clear the texture of the last set Image/RawImage before setting a new one.")]
	public bool m_AutoClearTexture = true;

	public void SetImage(Image displayImage, Sprite sprite)
	{
		Clear(displayImage);
		displayImage.sprite = sprite;
		_SetSize(displayImage);
	}

	public void SetImage(Image displayImage, Texture2D texture2D)
	{
		Clear(displayImage);
		displayImage.sprite = _TextureToSprite(texture2D);
		_SetSize(displayImage);
	}

	public void SetRawImage(RawImage displayImage, Sprite sprite)
	{
		Clear(displayImage);
		displayImage.texture = sprite.texture;
		_SetSize(displayImage);
	}

	public void SetRawImage(RawImage displayImage, Texture2D texture2D)
	{
		Clear(displayImage);
		displayImage.texture = texture2D;
		_SetSize(displayImage);
	}

	public void SetRawImage(RawImage displayImage, Texture texture)
	{
		Clear(displayImage);
		displayImage.texture = texture;
		_SetSize(displayImage);
	}

	public void SetImage(Image displayImage, float width, float height)
	{
		displayImage.rectTransform.sizeDelta = _CalculateSize(new Vector2(width, height));
		_ApplyScaleFactor(displayImage.transform);
	}

	public void SetRawImage(RawImage displayImage, float width, float height)
	{
		displayImage.rectTransform.sizeDelta = _CalculateSize(new Vector2(width, height));
		_ApplyScaleFactor(displayImage.transform);
	}

	private void _SetSize(Image displayImage)
	{
		if (m_BoundingType == BoundingType.SetNativeSize)
		{
			displayImage.SetNativeSize();
		}
		else
		{
			displayImage.rectTransform.sizeDelta = _CalculateSize(new Vector2(displayImage.sprite.texture.width, displayImage.sprite.texture.height));
		}
		_ApplyScaleFactor(displayImage.transform);
	}

	private void _SetSize(RawImage displayImage)
	{
		if (m_BoundingType == BoundingType.SetNativeSize)
		{
			displayImage.SetNativeSize();
		}
		else
		{
			displayImage.rectTransform.sizeDelta = _CalculateSize(new Vector2(displayImage.texture.width, displayImage.texture.height));
		}
		_ApplyScaleFactor(displayImage.transform);
	}

	private void _ApplyScaleFactor(Transform displayImageT)
	{
		displayImageT.localScale = new Vector3(m_ScaleFactor, m_ScaleFactor, 1f);
	}

	private Vector2 _CalculateSize(Vector2 textureSize)
	{
		Vector2 vector = Vector2.zero;
		switch (m_BoundingTarget)
		{
		case BoundingTarget.Size:
			vector = m_Size;
			break;
		case BoundingTarget.RectTransform:
			vector = m_RectTransform.GetComponent<RectTransform>().rect.size;
			break;
		case BoundingTarget.Screen:
			vector = new Vector2(Screen.width, Screen.height);
			break;
		}
		float x = textureSize.x;
		float y = textureSize.y;
		float num = x / y;
		switch (m_BoundingType)
		{
		case BoundingType.WidthAndHeight:
			x = vector.x;
			y = x / num;
			if (y > vector.y)
			{
				y = vector.y;
				x = y * num;
			}
			break;
		case BoundingType.Width:
			x = vector.x;
			y = x / num;
			break;
		case BoundingType.Height:
			y = vector.y;
			x = y * num;
			break;
		default:
			x = textureSize.x;
			y = textureSize.y;
			break;
		}
		return new Vector2(x, y);
	}

	private Sprite _TextureToSprite(Texture2D texture)
	{
		if (texture == null)
		{
			return null;
		}
		Vector2 pivot = new Vector2(0.5f, 0.5f);
		float pixelsPerUnit = 100f;
		return Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), pivot, pixelsPerUnit);
	}

	public void Clear(Image displayImage)
	{
		if (m_AutoClearTexture && displayImage != null && displayImage.sprite != null && displayImage.sprite.texture != null)
		{
			Object.Destroy(displayImage.sprite.texture);
			displayImage.sprite = null;
		}
	}

	public void Clear(RawImage displayImage)
	{
		if (m_AutoClearTexture && displayImage != null && displayImage.texture != null)
		{
			Object.Destroy(displayImage.texture);
			displayImage.texture = null;
		}
	}
}
