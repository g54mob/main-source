using System;

public class RegisterAssetMethodDefinitions
{
	public delegate int AudioSample_SamplesCount_get_Type(IntPtr assetPtr);

	public delegate void AudioSample_SamplesCount_set_Type(IntPtr assetPtr, int value);

	public delegate int AudioSample_Channels_get_Type(IntPtr assetPtr);

	public delegate void AudioSample_Channels_set_Type(IntPtr assetPtr, int value);

	public delegate int AudioSample_Frequency_get_Type(IntPtr assetPtr);

	public delegate void AudioSample_Frequency_set_Type(IntPtr assetPtr, int value);

	public delegate float AudioSample_Length_get_Type(IntPtr assetPtr);

	public delegate void AudioSample_Length_set_Type(IntPtr assetPtr, float value);

	public delegate LuaNativeTable AudioSample_Metadata_get_Type(IntPtr assetPtr);

	public delegate void AudioSample_Metadata_set_Type(IntPtr assetPtr, LuaNativeTable value);

	public delegate ToLuaPixelData RenderBuffer_GetPixelDataType(IntPtr assetPtr);

	public delegate int RenderBuffer_Width_get_Type(IntPtr assetPtr);

	public delegate void RenderBuffer_Width_set_Type(IntPtr assetPtr, int value);

	public delegate int RenderBuffer_Height_get_Type(IntPtr assetPtr);

	public delegate void RenderBuffer_Height_set_Type(IntPtr assetPtr, int value);

	public delegate ToLuaPixelData SpriteSheet_GetSpritePixelDataType(IntPtr assetPtr, int spriteX, int spriteY);

	public delegate ToLuaPixelData SpriteSheet_GetPixelDataType(IntPtr assetPtr);

	public delegate LuaAssetReference SpriteSheet_Palette_get_Type(IntPtr assetPtr);

	public delegate void SpriteSheet_Palette_set_Type(IntPtr assetPtr, LuaAssetReference value);

	public static void Register()
	{
	}

	public static int AudioSample_SamplesCount_get(IntPtr assetPtr)
	{
		return 0;
	}

	public static void AudioSample_SamplesCount_set(IntPtr assetPtr, int value)
	{
	}

	public static int AudioSample_Channels_get(IntPtr assetPtr)
	{
		return 0;
	}

	public static void AudioSample_Channels_set(IntPtr assetPtr, int value)
	{
	}

	public static int AudioSample_Frequency_get(IntPtr assetPtr)
	{
		return 0;
	}

	public static void AudioSample_Frequency_set(IntPtr assetPtr, int value)
	{
	}

	public static float AudioSample_Length_get(IntPtr assetPtr)
	{
		return 0f;
	}

	public static void AudioSample_Length_set(IntPtr assetPtr, float value)
	{
	}

	public static LuaNativeTable AudioSample_Metadata_get(IntPtr assetPtr)
	{
		return default(LuaNativeTable);
	}

	public static void AudioSample_Metadata_set(IntPtr assetPtr, LuaNativeTable value)
	{
	}

	public static ToLuaPixelData RenderBuffer_GetPixelData(IntPtr assetPtr)
	{
		return default(ToLuaPixelData);
	}

	public static int RenderBuffer_Width_get(IntPtr assetPtr)
	{
		return 0;
	}

	public static void RenderBuffer_Width_set(IntPtr assetPtr, int value)
	{
	}

	public static int RenderBuffer_Height_get(IntPtr assetPtr)
	{
		return 0;
	}

	public static void RenderBuffer_Height_set(IntPtr assetPtr, int value)
	{
	}

	public static ToLuaPixelData SpriteSheet_GetSpritePixelData(IntPtr assetPtr, int spriteX, int spriteY)
	{
		return default(ToLuaPixelData);
	}

	public static ToLuaPixelData SpriteSheet_GetPixelData(IntPtr assetPtr)
	{
		return default(ToLuaPixelData);
	}

	public static LuaAssetReference SpriteSheet_Palette_get(IntPtr assetPtr)
	{
		return null;
	}

	public static void SpriteSheet_Palette_set(IntPtr assetPtr, LuaAssetReference value)
	{
	}
}
