using UnityEngine;

public class TogglePvPButton : RadicalMenuOption
{
	public SpriteRenderer selectedSR;

	public SpriteRenderer pressedSR;

	public SpriteRenderer unpressedSR;

	[HideInInspector]
	public bool currentPvPSetting;

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
			currentPvPSetting = base.world.GetExistingSystemManaged<WorldInfoSystem>().WorldInfo.pvpEnabled;
		}
		else
		{
			buttonPressTimer -= Time.deltaTime;
		}
		pressedSR.gameObject.SetActive(currentPvPSetting);
		unpressedSR.gameObject.SetActive(!currentPvPSetting);
	}

	public override OptionActiveState GetActiveStateInCurrentScene()
	{
		if (Manager.main.player == null || Manager.main.player.adminPrivileges < 1 || Manager.networking.OfflineSession || !Manager.platform.hasNetwork)
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
			currentPvPSetting = !currentPvPSetting;
			Manager.networking.SetPvPMode(currentPvPSetting, Manager.ecs.ClientWorld);
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
		return currentPvPSetting;
	}
}
