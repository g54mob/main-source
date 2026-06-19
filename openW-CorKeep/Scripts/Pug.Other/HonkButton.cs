using PlayerState;
using UnityEngine;

public class HonkButton : IngameButtonHint
{
	public SpriteRenderer icon;

	public GameObject textContainer;

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
		PlayerController player = Manager.main.player;
		bool flag = player != null && EntityUtility.GetComponentData<PlayerStateCD>(player.entity, player.world).HasAnyState(PlayerStateEnum.VehicleRiding) && !Manager.ui.isAnyInventoryShowing && !Manager.ui.isShowingMap && !player.guestMode;
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
	}

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
	}

	public override void OnRightClicked(bool mod1, bool mod2)
	{
	}

	public override void OnSelected()
	{
	}
}
