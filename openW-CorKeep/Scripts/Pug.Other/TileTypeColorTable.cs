using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Pug/PugMap/TileTypeColorTable", order = 4)]
public class TileTypeColorTable : ScriptableObject
{
	[Serializable]
	public class TileColor
	{
		public TileType tileType;

		public Color32 color;
	}

	[Serializable]
	public class TileSetColors
	{
		public Tileset pugMapTileset;

		[ArrayElementTitle("tileType")]
		public List<TileColor> tileColors;
	}

	[ArrayElementTitle("pugMapTileset")]
	public List<TileSetColors> tileSetColors;

	public NativeArray<Color> CreateIndexToColorMapping(Allocator allocator)
	{
		byte length = 0;
		Dictionary<Color, byte> dictionary = new Dictionary<Color, byte>(256);
		dictionary.Add(Color.clear, length++);
		foreach (TileSetColors tileSetColor in tileSetColors)
		{
			foreach (TileColor tileColor in tileSetColor.tileColors)
			{
				if (!dictionary.ContainsKey(tileColor.color))
				{
					dictionary.Add(tileColor.color, length++);
				}
			}
		}
		NativeArray<Color> result = new NativeArray<Color>(length, allocator);
		foreach (KeyValuePair<Color, byte> item in dictionary)
		{
			result[item.Value] = item.Key;
		}
		Debug.Log($"Indexed map colors initialized with {result.Length} entries");
		return result;
	}
}
