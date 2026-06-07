using UnityEngine;

public class SerializedSticker
{
	public int border;

	public int fixedDataHeight;

	public byte[] colorData;

	public Vector2 position;

	public int rotation;

	public SerializedSticker()
	{
	}

	public SerializedSticker(Sticker sticker)
	{
	}

	public Sticker Instantiate(Motherboard motherboard)
	{
		return null;
	}
}
