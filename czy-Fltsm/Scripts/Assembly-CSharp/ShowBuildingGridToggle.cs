using UnityEngine;

[RequireComponent(typeof(Tooltip))]
public class ShowBuildingGridToggle : UIInteractableTooltippedToggle
{
	protected override void Start()
	{
		base.Start();
		Toggle(Settings.Instance.GameplayPlayerData.ShowBuildingGrid);
	}

	public override void Toggle(bool toggled, bool sendEvent = false)
	{
		base.Toggle(toggled, sendEvent);
		Settings instance = Settings.Instance;
		instance.GameplayPlayerData.ShowBuildingGrid = toggled;
		instance.Save();
		new GameEvent(GameEventType.ShowBuildGridSettingUpdated).Dispatch();
	}
}
