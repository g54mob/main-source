using UnityEngine;

public class GuestModeButton : RadicalMenuOption
{
	public SpriteRenderer selectedSR;

	public SpriteRenderer pressedSR;

	public SpriteRenderer unpressedSR;

	private bool currentGuestModeSetting;

	private float buttonPressTimer;

	protected override void Awake()
	{
		selectedSR.gameObject.SetActive(value: false);
		base.Awake();
	}

	protected override void LateUpdate()
	{
		base.LateUpdate();
		if (Manager.main.player != null && buttonPressTimer <= 0f)
		{
			currentGuestModeSetting = base.world.GetExistingSystemManaged<WorldInfoSystem>().WorldInfo.guestMode;
		}
		else
		{
			buttonPressTimer -= Time.deltaTime;
		}
		pressedSR.gameObject.SetActive(currentGuestModeSetting);
		unpressedSR.gameObject.SetActive(!currentGuestModeSetting);
	}

	public override OptionActiveState GetActiveStateInCurrentScene()
	{
		if (Manager.networking.OfflineSession || !Manager.platform.hasNetwork || Manager.main.player == null || Manager.main.player.adminPrivileges < 1)
		{
			return OptionActiveState.INACTIVE;
		}
		return base.GetActiveStateInCurrentScene();
	}

	public override void OnActivated()
	{
		if (Manager.ecs.ClientWorld != null)
		{
			buttonPressTimer = 1f;
			currentGuestModeSetting = !currentGuestModeSetting;
			Manager.networking.SetGuestMode(currentGuestModeSetting, Manager.ecs.ClientWorld);
		}
		base.OnActivated();
	}

	public override void OnSelected()
	{
		pressedSR.color = PugTextEffectMenuOption.SELECTED_TEXT_COLOR;
		unpressedSR.color = PugTextEffectMenuOption.SELECTED_TEXT_COLOR;
		selectedSR.gameObject.SetActive(value: true);
		base.OnSelected();
	}

	public override void OnDeselected(bool playEffect = true)
	{
		pressedSR.color = PugTextEffectMenuOption.UNSELECTED_TEXT_COLOR;
		unpressedSR.color = PugTextEffectMenuOption.UNSELECTED_TEXT_COLOR;
		selectedSR.gameObject.SetActive(value: false);
		base.OnDeselected(playEffect);
	}

	public override bool IsOn()
	{
		return currentGuestModeSetting;
	}
}
