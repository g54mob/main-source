using System;
using LightTower;
using UnityEngine;

[Serializable]
public class GridCell
{
	public Action<PlacementComponent> onBuiltObjectChanged;

	private Tile tile;

	private PlacementComponent builtObject;

	public Tile Tile
	{
		get
		{
			return tile;
		}
		set
		{
			tile = value;
		}
	}

	public PlacementComponent BuiltObject
	{
		get
		{
			return builtObject;
		}
		set
		{
			builtObject = value;
			if (Application.isPlaying)
			{
				tile.ShowEnvironmentProps(!builtObject);
			}
			onBuiltObjectChanged?.Invoke(builtObject);
		}
	}

	public bool IsFree()
	{
		return BuiltObject == null;
	}

	public bool CanBuild()
	{
		if (IsFree())
		{
			return tile.CanBuildOn();
		}
		return false;
	}
}
