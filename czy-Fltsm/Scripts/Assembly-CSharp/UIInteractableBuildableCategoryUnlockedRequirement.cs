using UnityEngine;

public class UIInteractableBuildableCategoryUnlockedRequirement : UIInteractableRequirementBase
{
	[SerializeField]
	private BuildableCreation.PlaceableFlags _categories;

	protected override void Awake()
	{
		base.Awake();
		GameEventDispatcher.AddListener(GameEventType.UnlockableUnlocked, UpdateInteractable);
	}

	private void Start()
	{
		UpdateInteractable();
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.UnlockableUnlocked, UpdateInteractable);
	}

	private void UpdateInteractable(GameEvent gameEvent = null)
	{
		base.IsMet = ReturnIsMet();
		if (base.IsMet)
		{
			GameEventDispatcher.RemoveListener(GameEventType.UnlockableUnlocked, UpdateInteractable);
		}
	}

	public override bool ReturnIsMet()
	{
		if ((!_categories.HasFlag(BuildableCreation.PlaceableFlags.Buildables) || !(GameManager.Settings.BuildableSettings.Buildables.Find((BuildableProperties buildable) => buildable != null && buildable.IsUnlocked()) != null)) && (!_categories.HasFlag(BuildableCreation.PlaceableFlags.Decorations) || !(GameManager.Settings.BuildableSettings.Decorations.Find((DecorationProperties decoration) => decoration != null && decoration.IsUnlocked()) != null)))
		{
			if (_categories.HasFlag(BuildableCreation.PlaceableFlags.Utilities))
			{
				return GameManager.Settings.BuildableSettings.Utilties.Find((PlaceableUtilityProperties utility) => utility != null && utility.ReturnCanBePlaced(Community.PlayerCommunity)) != null;
			}
			return false;
		}
		return true;
	}
}
