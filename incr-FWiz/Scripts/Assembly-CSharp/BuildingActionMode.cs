using System;
using System.Runtime.CompilerServices;
using FMODUnity;
using UnityEngine;

public class BuildingActionMode : PlayerActionMode
{
	[SerializeField]
	private EventReference _cancelSound;

	[SerializeField]
	private EventReference _changeBlueprintSelectionSound;

	public bool _lastBlueprintValid;

	public override bool PlayerCanMove => false;

	public int SelectedBlueprintIndex { get; private set; }

	public Blueprint UnplacedBlueprint { get; private set; }

	public bool HasUnplacedBlueprint => false;

	public event Action<int> AnnounceIndexSelection
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

	public event Action AnnouncePaused
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

	public event Action AnnounceUnpaused
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

	public override void OnInitiate()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnUnlockBuilding(BuildingAsset buildingAsset)
	{
	}

	protected override void OnActivate()
	{
	}

	protected override void OnDeactivate()
	{
	}

	public void OnCancel()
	{
	}

	public void ApplyScroll(int scroll)
	{
	}

	public void ChangeSelectionTo(int index)
	{
	}
}
