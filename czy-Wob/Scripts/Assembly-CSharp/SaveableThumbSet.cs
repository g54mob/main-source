using System;

[Serializable]
public class SaveableThumbSet
{
	public SerializableSprite defaultPortrait;

	public SaveableThumbSet(ThumbnailSet thumb)
	{
		if (thumb.defaultThumb == null)
		{
			defaultPortrait = new SerializableSprite();
		}
		else
		{
			defaultPortrait = new SerializableSprite(thumb.defaultThumb);
		}
	}

	private SaveableThumbSet()
	{
	}

	public SaveableThumbSet GetCopy()
	{
		return new SaveableThumbSet
		{
			defaultPortrait = defaultPortrait.GetCopy()
		};
	}

	public ThumbnailSet Load()
	{
		return new ThumbnailSet
		{
			defaultThumb = defaultPortrait.Load()
		};
	}

	public bool IsEmpty()
	{
		if (defaultPortrait == null || defaultPortrait.IsEmpty())
		{
			return true;
		}
		return false;
	}
}
