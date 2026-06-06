using System;
using UnityEngine;

public readonly struct BoxArtTexture : IDisposable
{
	public readonly BoxArt BoxArt;

	public readonly Texture2D Texture;

	public Sprite Sprite => Texture.ToSprite();

	public BoxArtTexture(BoxArt boxArt, Texture texture)
		: this(boxArt, (Texture2D)texture)
	{
	}

	public BoxArtTexture(BoxArt boxArt, Texture2D texture)
	{
		BoxArt = boxArt;
		Texture = texture;
	}

	public void Dispose()
	{
		if (BoxArt == BoxArt.Custom)
		{
			UnityEngine.Object.Destroy(Texture);
		}
	}

	public static implicit operator Texture(BoxArtTexture texture)
	{
		return texture.Texture;
	}
}
