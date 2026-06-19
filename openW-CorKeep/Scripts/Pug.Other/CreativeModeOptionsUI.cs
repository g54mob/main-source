using Unity.Mathematics;
using UnityEngine;

public class CreativeModeOptionsUI : UIelement
{
	private const string SHOW_CREATIVE_UI = "showCreativeUI";

	private const string HIDE_CREATIVE_UI = "hideCreativeUI";

	private const string ENABLE_GOD_MODE = "enableGodMode";

	private const string DISABLE_GOD_MODE = "disableGodMode";

	private const string ENABLE_WORLD_SIMULATION = "enableWorldSimulation";

	private const string DISABLE_WORLD_SIMULATION = "disableWorldSimulation";

	public PugText title;

	public SpriteRenderer background;

	public BoxCollider backgroundColl;

	public ToggleUIElement toggleCreativeModeWindowButton;

	public ToggleUIElement toggleGodModeButton;

	public ToggleUIElement toggleWorldSimulationButton;

	private bool _currentGodModeSetting;

	private bool _currentSimulationDisabledSetting;

	private void Awake()
	{
		base.gameObject.SetActive(value: false);
	}

	protected override void LateUpdate()
	{
		base.LateUpdate();
		base.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		_currentGodModeSetting = Manager.main.player != null && Manager.main.player.GetLastLocalGodModeState();
		_currentSimulationDisabledSetting = base.world != null && base.world.GetExistingSystemManaged<WorldInfoSystem>().WorldInfo.simulationDisabled;
		UpdateUITexts();
		UpdateToggles();
		UpdatePositioningOfUIElements();
	}

	private void UpdateToggles()
	{
		toggleCreativeModeWindowButton.isOn = Manager.ui.creativeModeUI.isShowing;
		toggleGodModeButton.isOn = _currentGodModeSetting;
		toggleWorldSimulationButton.isOn = _currentSimulationDisabledSetting;
		toggleWorldSimulationButton.canBeClicked = Manager.main.player != null && Manager.main.player.adminPrivileges != 0;
	}

	private void UpdateUITexts()
	{
		toggleCreativeModeWindowButton.SetText(Manager.ui.creativeModeUI.isShowing ? "hideCreativeUI" : "showCreativeUI");
		toggleGodModeButton.SetText(_currentGodModeSetting ? "disableGodMode" : "enableGodMode");
		toggleWorldSimulationButton.SetText(_currentSimulationDisabledSetting ? "enableWorldSimulation" : "disableWorldSimulation");
	}

	private void UpdatePositioningOfUIElements()
	{
		float previousBottom = 0f;
		previousBottom = UIManager.PositionElementBeneath(title.transform, previousBottom, title.dimensions.height, 0f);
		previousBottom = UIManager.PositionElementBeneath(toggleCreativeModeWindowButton.transform, previousBottom, toggleCreativeModeWindowButton.text.dimensions.height, 0.625f);
		previousBottom = UIManager.PositionElementBeneath(toggleGodModeButton.transform, previousBottom, toggleGodModeButton.text.dimensions.height, 0.4375f);
		previousBottom = UIManager.PositionElementBeneath(toggleWorldSimulationButton.transform, previousBottom, toggleWorldSimulationButton.text.dimensions.height, 0.4375f);
		float num = math.abs(previousBottom) + 0.5f;
		background.size = new Vector2(5.25f, num);
		backgroundColl.size = new Vector3(5.25f, num, 0.1f);
		float num2 = num / 2f;
		num2 += num2 % 0.0625f;
		Transform obj = background.transform;
		Vector3 localPosition = obj.localPosition;
		localPosition = new Vector3(localPosition.x, 0f - num2, localPosition.z);
		obj.localPosition = localPosition;
	}

	public void Show()
	{
		base.gameObject.SetActive(value: true);
	}

	public void Hide()
	{
		if (base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	public void ToggleCreativeModeUI()
	{
		if (Manager.ui.creativeModeUI.isShowing)
		{
			Manager.ui.OnCreativeModeUIClose();
		}
		else
		{
			Manager.ui.OnCreativeModeUIOpen();
		}
	}

	public void ToggleGodMode()
	{
		if (Manager.main.player != null)
		{
			Manager.main.player.SetGodModeCreative(!_currentGodModeSetting);
			if (!_currentGodModeSetting)
			{
				AudioManager.Sfx(SfxTableID.inventorySFXGodmodeOn, Manager.main.player.transform.position);
			}
			else
			{
				AudioManager.Sfx(SfxTableID.inventorySFXGodmodeOff, Manager.main.player.transform.position);
			}
		}
	}

	public void ToggleWorldSimulation()
	{
		if (base.world != null)
		{
			Manager.networking.SetDisableSimulation(!_currentSimulationDisabledSetting, base.world);
			if (!_currentSimulationDisabledSetting)
			{
				AudioManager.Sfx(SfxTableID.inventorySFXWorldPauseOn, Manager.main.player.transform.position);
			}
			else
			{
				AudioManager.Sfx(SfxTableID.inventorySFXWorldPauseOff, Manager.main.player.transform.position);
			}
		}
	}
}
