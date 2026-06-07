using System;

public class RegisterAsyncJobsGetters
{
	public delegate LuaAssetReference GetResult_AudioSampleAssetType(IntPtr handlePtr);

	public delegate LuaAssetReference GetResult_SpriteSheetAssetType(IntPtr handlePtr);

	public static void Register()
	{
	}

	public static LuaAssetReference GetResult_AudioSampleAsset(IntPtr handlePtr)
	{
		return null;
	}

	public static LuaAssetReference GetResult_SpriteSheetAsset(IntPtr handlePtr)
	{
		return null;
	}
}
