using FMODUnity;
using UnityEngine;

public class DeconstructionActionMode : PlayerActionMode
{
	private BuildingDeconstructable Deconstructable;

	[SerializeField]
	public EventReference _deconstructSound;

	[SerializeField]
	private DefaultCustomCursor _baseCursor;

	[SerializeField]
	private BuildingEditOptionsUI _editOptionsUI;

	public bool Moving;

	public override bool PlayerCanMove => false;

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

	public void OnHoverOverDeconstructable(BuildingDeconstructable deconstructable)
	{
	}

	public void OnHoverOverDeconstructableEnd(BuildingDeconstructable deconstructable)
	{
	}

	public void OnHoverDuringMode()
	{
	}

	public void OnPress()
	{
	}

	public void TryDestroy()
	{
	}

	public void TryMove()
	{
	}

	public void EndMove()
	{
	}

	public void ShowSelectorSymbols()
	{
	}
}
