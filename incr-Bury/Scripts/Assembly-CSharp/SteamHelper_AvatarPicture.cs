using System;
using System.Threading.Tasks;
using Steamworks;
using Steamworks.Data;
using UnityEngine;

public static class SteamHelper_AvatarPicture
{
	public static async Task<Image?> GetAvatar(SteamId _steamId)
	{
		try
		{
			return await SteamFriends.GetLargeAvatarAsync(_steamId);
		}
		catch (Exception message)
		{
			Debug.Log(message);
			return null;
		}
	}

	public static Texture2D Covert(this Image image)
	{
		Texture2D texture2D = new Texture2D((int)image.Width, (int)image.Height, TextureFormat.ARGB32, mipChain: false);
		texture2D.filterMode = FilterMode.Trilinear;
		for (int i = 0; i < image.Width; i++)
		{
			for (int j = 0; j < image.Height; j++)
			{
				Steamworks.Data.Color pixel = image.GetPixel(i, j);
				texture2D.SetPixel(i, (int)image.Height - j, new UnityEngine.Color((float)(int)pixel.r / 255f, (float)(int)pixel.g / 255f, (float)(int)pixel.b / 255f, (float)(int)pixel.a / 255f));
			}
		}
		texture2D.Apply();
		return texture2D;
	}

	public static Sprite TextureToSprite(Texture2D _texture)
	{
		return Sprite.Create(_texture, new Rect(0f, 0f, _texture.width, _texture.height), new Vector2(0.5f, 0.5f));
	}
}
