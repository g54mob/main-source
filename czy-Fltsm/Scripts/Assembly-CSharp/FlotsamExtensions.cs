using System;
using PajamaLlama.Flotsam.World;
using UnityEngine;

public static class FlotsamExtensions
{
	public static WorldRegionTypeFlags ToWorldRegionTypeFlags(this WorldRegionType worldRegionType)
	{
		WorldRegionTypeFlags worldRegionTypeFlags = GetWorldRegionTypeFlags(worldRegionType);
		if (worldRegionTypeFlags == WorldRegionTypeFlags.None && worldRegionType != WorldRegionType.None)
		{
			Debug.LogException(new Exception(string.Format("{0} has not yet been updated to handle WorldRegionType.{1}.", "ToWorldRegionTypeFlags", worldRegionType)));
		}
		return worldRegionTypeFlags;
	}

	private static WorldRegionTypeFlags GetWorldRegionTypeFlags(WorldRegionType worldRegionType)
	{
		return worldRegionType switch
		{
			WorldRegionType.Forest => WorldRegionTypeFlags.Forest, 
			WorldRegionType.Rural => WorldRegionTypeFlags.Rural, 
			WorldRegionType.City => WorldRegionTypeFlags.City, 
			WorldRegionType.PollutedWoods => WorldRegionTypeFlags.PollutedWoods, 
			WorldRegionType.Farmland => WorldRegionTypeFlags.Farmland, 
			WorldRegionType.Shallow => WorldRegionTypeFlags.Shallow, 
			WorldRegionType.Industry => WorldRegionTypeFlags.Industry, 
			WorldRegionType.Utopia => WorldRegionTypeFlags.Utopia, 
			WorldRegionType.PollutionBelt => WorldRegionTypeFlags.PollutionBelt, 
			_ => WorldRegionTypeFlags.None, 
		};
	}
}
