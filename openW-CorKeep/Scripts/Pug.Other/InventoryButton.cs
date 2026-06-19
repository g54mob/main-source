using UnityEngine;

public class InventoryButton : IngameButtonHint
{
	public OutlineController outlineController;

	public LightUpHintIcon lightUpHintIcon;

	public GameObject hintEffect;

	public SpriteRenderer icon;

	public GameObject textContainer;

	private bool _initialized;

	private Vector3 _currentScale;

	private bool _currentActive;

	public override bool isButtonActive => _currentActive;

	private void Awake()
	{
		HideLightUpHint();
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
		PlayerController player = Manager.main.player;
		bool flag = player != null && !player.instrumentHandler.IsPlayingInstrument && !player.guestMode;
		if (!_initialized || _currentActive != flag || force)
		{
			textContainer.SetActive(flag);
			icon.enabled = flag;
			_currentActive = flag;
		}
		_initialized = true;
		base.LateUpdate();
	}

	public void ShowLightUpHint()
	{
		lightUpHintIcon.ShowLightUpHint();
		hintEffect.SetActive(value: true);
	}

	public void HideLightUpHint()
	{
		lightUpHintIcon.HideLightUpHint();
		hintEffect.SetActive(value: false);
	}

	public override void OnDeselected(bool playEffect = true)
	{
		outlineController.showOutline = false;
	}

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
		PlayerController player = Manager.main.player;
		if (!(player == null))
		{
			if (Manager.ui.isAnyInventoryShowing)
			{
				player.CloseAnyOpenInventory();
			}
			else
			{
				player.OpenPlayerInventory();
			}
		}
	}

	public override void OnRightClicked(bool mod1, bool mod2)
	{
	}

	public override void OnSelected()
	{
		outlineController.showOutline = true;
	}
}
