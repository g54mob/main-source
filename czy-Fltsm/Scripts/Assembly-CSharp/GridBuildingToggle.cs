using UnityEngine;

[RequireComponent(typeof(Tooltip))]
public class GridBuildingToggle : UIInteractableTooltippedToggle
{
	protected override void Start()
	{
		base.Start();
		Toggle(Settings.Instance.GameplayPlayerData.SnapBuilding);
	}

	public override void Toggle(bool toggled, bool sendEvent = false)
	{
		base.Toggle(toggled, sendEvent);
		Settings instance = Settings.Instance;
		instance.GameplayPlayerData.SnapBuilding = toggled;
		instance.Save();
	}
}
