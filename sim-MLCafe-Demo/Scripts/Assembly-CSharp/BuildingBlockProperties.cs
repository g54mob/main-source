using System;
using UnityEngine;

[Serializable]
public class BuildingBlockProperties : LibraryProperty
{
	public string name;

	public GameObject blockPrefab;

	public Sprite blockIcon;

	public Vector3 dimensions = Vector3.one;

	public override string GetName()
	{
		return name;
	}

	public override string GetDescription()
	{
		return "No Description";
	}

	public override Sprite GetIcon()
	{
		return blockIcon;
	}
}
