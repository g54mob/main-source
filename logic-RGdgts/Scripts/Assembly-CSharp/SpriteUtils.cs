using UnityEngine;

public static class SpriteUtils
{
	private delegate Texture2D GetSecondaryTextureDelegate(Sprite sprite, int index);

	private static readonly GetSecondaryTextureDelegate GetSecondaryTextureCached;

	public static Texture GetSecondaryTexture(this Sprite sprite, int index)
	{
		return null;
	}
}
