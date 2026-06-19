using System;
using UnityEngine;

[Serializable]
public class SerializableTexture2D
{
	public byte[] bytes;

	private bool compressed;

	public int width;

	public int height;

	public TextureFormat textureFormat = TextureFormat.ARGB32;

	public SerializableTexture2D(Texture2D tex)
	{
		Save(tex);
	}

	public SerializableTexture2D()
	{
		bytes = new byte[0];
		width = 0;
		height = 0;
	}

	public SerializableTexture2D GetCopy()
	{
		if (!compressed)
		{
			compressed = true;
			if (bytes.Length != 0)
			{
				bytes = CLZF2.Compress(bytes);
			}
		}
		SerializableTexture2D serializableTexture2D = new SerializableTexture2D();
		serializableTexture2D.bytes = new byte[bytes.Length];
		for (int i = 0; i < bytes.Length; i++)
		{
			serializableTexture2D.bytes[i] = bytes[i];
		}
		serializableTexture2D.width = width;
		serializableTexture2D.height = height;
		serializableTexture2D.compressed = compressed;
		serializableTexture2D.textureFormat = textureFormat;
		return serializableTexture2D;
	}

	private void Save(Texture2D tex)
	{
		bytes = tex.GetRawTextureData();
		bytes = CLZF2.Compress(bytes);
		compressed = true;
		width = tex.width;
		height = tex.height;
		textureFormat = tex.format;
	}

	public Texture2D Load()
	{
		if (IsEmpty())
		{
			return null;
		}
		Texture2D texture2D = new Texture2D(width, height, textureFormat, mipChain: false);
		try
		{
			if (compressed)
			{
				texture2D.LoadRawTextureData(CLZF2.Decompress(bytes));
			}
			else
			{
				texture2D.LoadRawTextureData(bytes);
			}
			texture2D.Apply();
		}
		catch (Exception message)
		{
			Debug.LogError(message);
		}
		return texture2D;
	}

	public bool IsEmpty()
	{
		if (bytes == null || bytes.Length == 0)
		{
			return true;
		}
		return false;
	}
}
