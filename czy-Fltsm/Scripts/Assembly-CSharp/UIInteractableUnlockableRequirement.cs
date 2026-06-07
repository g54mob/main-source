using UnityEngine;
using UnityEngine.UI;

public class UIInteractableUnlockableRequirement : UIInteractableRequirementBase
{
	[SerializeField]
	private Unlockable _unlockable;

	private Selectable _selectable;

	protected override void Awake()
	{
		base.Awake();
		_selectable = GetComponent<Selectable>();
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
	}

	public override bool ReturnIsMet()
	{
		return UnlockableManager.IsUnlocked(_unlockable);
	}
}
