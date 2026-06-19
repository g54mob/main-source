using UnityEngine;

public class InventoryShortCutsButton : IngameButtonHint
{
	public OutlineController outlineController;

	public SpriteRenderer icon;

	public GameObject textContainer;

	public PlatformDependentPugText platformDependentPugText;

	private bool _initialized;

	private Vector3 _currentScale;

	private bool _currentActive;

	public override bool isButtonActive => _currentActive;

	public void Awake()
	{
		UpdateVisuals(force: true);
	}

	public override void UpdateVisuals()
	{
		UpdateVisuals(force: false);
	}

	private void UpdateVisuals(bool force)
	{
		Vector3 vector = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		if (!_initialized || _currentScale != vector || force)
		{
			base.transform.localScale = vector;
			_currentScale = vector;
		}
		bool flag = ShortcutsCanBeToggled();
		if (!_initialized || _currentActive != flag || force)
		{
			textContainer.SetActive(flag);
			icon.enabled = flag;
			_currentActive = flag;
		}
		_initialized = true;
		base.LateUpdate();
	}

	public override void OnDeselected(bool playEffect = true)
	{
		outlineController.showOutline = false;
	}

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
		ToggleInventoryShortcuts();
	}

	public override void OnSelected()
	{
		outlineController.showOutline = true;
	}

	public static bool ShortcutsCanBeToggled()
	{
		PlayerController player = Manager.main.player;
		if (Manager.ui.isAnyInventoryShowing && player != null)
		{
			return !player.guestMode;
		}
		return false;
	}

	public static void ToggleInventoryShortcuts()
	{
		if (Manager.ui.isAnyInventoryShowing)
		{
			Manager.ui.ToggleInventoryShortCuts();
		}
	}
}
