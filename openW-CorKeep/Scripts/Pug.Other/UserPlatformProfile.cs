using UnityEngine;

public class UserPlatformProfile
{
	public string UserName;

	public string FirstName;

	public string LastName;

	public byte[] ImageData;

	public uint Width;

	public uint Height;

	public UserImageSize Size;

	public PlatformUserID userId { get; set; }

	public UserPlatformProfile(string userName = null, string firstName = null, string lastName = null, byte[] imageData = null, uint width = 0u, uint height = 0u, UserImageSize size = UserImageSize.None)
	{
		UserName = userName;
		FirstName = firstName;
		LastName = lastName;
		ImageData = imageData;
		Width = width;
		Height = height;
		Size = size;
	}

	public UserPlatformProfile()
	{
		Size = UserImageSize.None;
	}

	public UserPlatformProfile(string userName, string firstName, string lastName)
	{
		UserName = userName;
		FirstName = firstName;
		LastName = lastName;
		Size = UserImageSize.None;
	}

	public Texture2D ToTexture2D()
	{
		if (ImageData == null || ImageData.Length == 0)
		{
			return null;
		}
		Texture2D obj = new Texture2D((int)Width, (int)Height, TextureFormat.RGBA32, mipChain: false)
		{
			filterMode = FilterMode.Bilinear
		};
		obj.LoadImage(ImageData);
		obj.Apply();
		return obj;
	}

	public Sprite ToSprite()
	{
		if (ImageData == null || ImageData.Length == 0)
		{
			return null;
		}
		Texture2D texture2D = ToTexture2D();
		return Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), Vector2.one / 2f);
	}
}
