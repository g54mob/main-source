using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using OUSystems.Basics.UI;
using UnityEngine;

public class Building : MonoBehaviour
{
	[SerializeField]
	private bool _built;

	private bool _initiated;

	[SerializeField]
	public HoverListener HoverListener;

	[SerializeField]
	private BuildingDeconstructable _deconstructable;

	[SerializeField]
	private List<ES3AutoSave> _autoSaveObjects;

	public bool Offline;

	[field: SerializeField]
	public BuildingAsset BaseBuildingAsset { get; private set; }

	[field: SerializeField]
	public BuildingAsset DemoBuildingAsset { get; private set; }

	public BuildingAsset BuildingAsset => null;

	[field: SerializeField]
	public BuildingStructure BuildingStructure { get; private set; }

	public BuildingDeconstructable Destructable => null;

	public static List<Building> Buildings { get; private set; }

	public static event Action<Building> AnnounceStart
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

	public static event Action<Building> AnnounceDestroy
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

	public static event Action<Building> AnnounceInitialBuild
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

	public static event Action<Building> AnnounceBuilt
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

	private void Start()
	{
	}

	public void Initiate()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnCompleteAsBuilding()
	{
	}

	public void InitiateAsCompleteBuilding()
	{
	}
}
