using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BlueprintHandler : MonoBehaviour
{
	public Blueprint CurrentBlueprint;

	public BuildingAsset BuildingAsset;

	public BuildingStructure MovingBuilding;

	[SerializeField]
	private Blueprint _blueprintPrefab;

	[SerializeField]
	private Construction _constructionPrefab;

	private int _disablePlacementStacks;

	public bool Placing => false;

	public bool BlueprintActive => false;

	public bool PlacementDisabled { get; private set; }

	public event Action AnnouncePlace
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void AddDisablePlacementStack()
	{
	}

	public void RemoveDisablePlacementStack()
	{
	}

	public void UpdateBlueprint(BuildingAsset asset, BuildingStructure movingBuilding = null)
	{
	}

	public void CancelBlueprint()
	{
	}

	public void ClearBlueprint()
	{
	}

	public void Commit()
	{
	}

	public void ShowBlueprint()
	{
	}

	public Blueprint CreateBlueprintInstance()
	{
		return null;
	}
}
