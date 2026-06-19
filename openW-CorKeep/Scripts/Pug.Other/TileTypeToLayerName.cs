using System;
using System.Collections.Generic;
using PugTilemap;

public static class TileTypeToLayerName
{
	private static Dictionary<TileType, LayerName> tileTypeToLayerName;

	static TileTypeToLayerName()
	{
		InitializeTileTypeToLayerName();
	}

	[ExecuteOnReload]
	private static void InitializeTileTypeToLayerName()
	{
		tileTypeToLayerName = new Dictionary<TileType, LayerName>();
		string[] names = Enum.GetNames(typeof(TileType));
		string[] names2 = Enum.GetNames(typeof(LayerName));
		string[] array = names;
		foreach (string tileTypeName in array)
		{
			if (Array.Exists(names2, (string x) => x.Equals(tileTypeName)))
			{
				tileTypeToLayerName.Add((TileType)Enum.Parse(typeof(TileType), tileTypeName), (LayerName)Enum.Parse(typeof(LayerName), tileTypeName));
			}
		}
	}

	public static LayerName GetLayerName(TileType tileType)
	{
		if (!tileTypeToLayerName.ContainsKey(tileType))
		{
			return LayerName.none;
		}
		return tileTypeToLayerName[tileType];
	}
}
