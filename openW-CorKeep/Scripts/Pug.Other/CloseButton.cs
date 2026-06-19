using I2.Loc;
using UnityEngine;

public class CloseButton : IngameButtonHint
{
	public OutlineController outlineController;

	public SpriteRenderer icon;

	public GameObject textContainer;

	public PlatformDependentPugText platformDependentPugText;

	public LocalizedString standardCloseKey;

	public LocalizedString instrumentCloseKey;

	public LocalizedString textInputCloseKey;

	private bool _initialized;

	private Vector3 _currentScale;

	private bool _currentActive;

	private bool _prevTextInputActive;

	public override bool isButtonActive => _currentActive;

	public void Awake()
	{
		UpdateVisuals();
	}

	public override void UpdateVisuals()
	{
		Vector3 vector = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		if (!_initialized || _currentScale != vector)
		{
			base.transform.localScale = vector;
			_currentScale = vector;
		}
		PlayerController player = Manager.main.player;
		bool flag = player != null && player.instrumentHandler.IsPlayingInstrument;
		bool flag2 = flag || Manager.ui.isAnyInventoryShowing || Manager.ui.isShowingMap;
		bool textInputIsActive = Manager.input.textInputIsActive;
		bool flag3 = !_initialized || textInputIsActive != _prevTextInputActive;
		if (!_initialized || _currentActive != flag2 || flag3)
		{
			platformDependentPugText.SetControlMapperKey((!textInputIsActive) ? (flag ? instrumentCloseKey : standardCloseKey) : (Manager.input.SystemPrefersKeyboardAndMouse() ? textInputCloseKey : standardCloseKey));
			textContainer.SetActive(flag2);
			icon.enabled = flag2;
			_currentActive = flag2;
		}
		_prevTextInputActive = textInputIsActive;
		_initialized = true;
		base.LateUpdate();
	}

	public override void OnDeselected(bool playEffect = true)
	{
		outlineController.showOutline = false;
	}

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
		Manager.ui.HideAllInventoryAndCraftingUI();
		Manager.ui.HideMap();
		PlayerController player = Manager.main.player;
		if (player != null && player.instrumentHandler.IsPlayingInstrument)
		{
			player.stopPlayingInstrument = true;
		}
	}

	public override void OnSelected()
	{
		outlineController.showOutline = true;
	}
}
