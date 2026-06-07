using System.Collections.Generic;
using UnityEngine;

public class BuildingRecorderData : ScriptableObject
{
	[SerializeField]
	private List<BuildingRecorderObjectData> buildings;

	public List<BuildingRecorderObjectData> Buildings
	{
		get
		{
			return buildings;
		}
		set
		{
			buildings = value;
		}
	}
}
