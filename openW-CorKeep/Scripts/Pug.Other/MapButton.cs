using UnityEngine;

public class MapButton : IngameButtonHint
{
	public OutlineController outlineController;

	public LightUpHintIcon lightUpHintIcon;

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

	public void ShowLightUpHint()
	{
		lightUpHintIcon.ShowLightUpHint();
	}

	public void HideLightUpHint()
	{
		lightUpHintIcon.HideLightUpHint();
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
		bool flag = player != null && !player.instrumentHandler.IsPlayingInstrument;
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
		Manager.ui.OnMapToggle();
	}

	public override void OnRightClicked(bool mod1, bool mod2)
	{
	}

	public override void OnSelected()
	{
		outlineController.showOutline = true;
	}
}
