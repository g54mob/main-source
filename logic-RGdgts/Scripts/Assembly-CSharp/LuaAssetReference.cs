using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public class LuaAssetReference
{
	public AssetType type;

	public AssetSelector assetSelector;

	public IntPtr ptr;

	public static LuaAssetReference None;

	public LuaAssetReference()
	{
	}

	public LuaAssetReference(AssetType type, AssetSelector assetSelector, IntPtr ptr)
	{
	}

	public LuaAssetReference(Asset asset)
	{
	}

	public static implicit operator LuaAssetReference(AssetReference assetRef)
	{
		return null;
	}

	public static implicit operator LuaAssetReference(Asset asset)
	{
		return null;
	}
}
