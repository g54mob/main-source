using System;
using UnityEngine;
using UnityEngine.Localization;

public class Obelisk : MapObject
{
	[SerializeField]
	private LocalizedString obeliskName;

	[SerializeField]
	private LocalizedString description;

	[SerializeField]
	private GameplayEffectData[] gameplayEffectsToApply;

	public string ObeliskName => obeliskName.GetLocalizedString();

	public string Description => description.GetLocalizedString();

	public GameplayEffectData[] GameplayEffectsToApply => gameplayEffectsToApply;

	protected override void Start()
	{
		foreach (GridCell adjacentGridCell in LTFunctionLibrary.GetGrid().GetAdjacentGridCells(base.transform.position))
		{
			adjacentGridCell.onBuiltObjectChanged = (Action<PlacementComponent>)Delegate.Combine(adjacentGridCell.onBuiltObjectChanged, new Action<PlacementComponent>(OnAdjacentBuiltObjectChanged));
		}
	}

	private void OnAdjacentBuiltObjectChanged(PlacementComponent placementComponent)
	{
		if ((bool)placementComponent && placementComponent.MainObject.TryGetComponent<Tower>(out var component))
		{
			for (int i = 0; i < GameplayEffectsToApply.Length; i++)
			{
				component.GetComponent<GameplayEffectsComponent>().ApplyEffect(GameplayEffectsToApply[i], 1);
			}
		}
	}
}
