using UnityEngine;

public class SettingsEvent : GameEvent
{
	public Resolution Resolution { get; private set; }

	public float UIScale { get; private set; }

	private SettingsEvent(GameEventType eventType)
		: base(eventType)
	{
	}

	public static void DispatchUIScaleChangedEvent(float scale)
	{
		SettingsEvent settingsEvent = new SettingsEvent(GameEventType.UIScaleSettingChanged);
		settingsEvent.UIScale = scale;
		settingsEvent.Dispatch();
	}
}
