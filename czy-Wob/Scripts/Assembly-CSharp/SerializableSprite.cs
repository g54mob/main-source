using System;
using UnityEngine;

[Serializable]
public class SerializableSprite
{
	public SerializableTexture2D texture;

	public float pixelsPerUnit;

	public SerializableRect rect;

	public SerializableVector2 pivot;

	public SerializableSprite()
	{
		texture = new SerializableTexture2D();
		pixelsPerUnit = 0f;
		rect = new SerializableRect(default(Rect));
		pivot = new SerializableVector2(Vector2.zero);
	}

	public SerializableSprite(Sprite s)
	{
		Save(s);
	}

	public SerializableSprite GetCopy()
	{
		return new SerializableSprite
		{
			texture = texture.GetCopy(),
			pixelsPerUnit = pixelsPerUnit,
			rect = rect.GetCopy(),
			pivot = pivot.GetCopy()
		};
	}

	public void Save(Sprite v)
	{
		texture = new SerializableTexture2D(v.texture);
		pixelsPerUnit = v.pixelsPerUnit;
		rect = new SerializableRect(v.rect);
		pivot = new SerializableVector2(new Vector2(v.pivot.x / (float)texture.width, v.pivot.y / (float)texture.height));
	}

	public Sprite Load()
	{
		return Sprite.Create(texture.Load(), rect.Load(), pivot.Load(), pixelsPerUnit);
	}

	public bool IsEmpty()
	{
		if (texture == null || texture.IsEmpty())
		{
			return true;
		}
		return false;
	}
}
