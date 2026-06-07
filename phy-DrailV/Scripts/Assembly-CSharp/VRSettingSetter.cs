using Bolt;
using Ludiq;
using UnityEngine;

[UnitTitle("VR Setting setter")]
[UnitSubtitle("Set some VR settings")]
[UnitCategory("Input")]
[TypeIcon(typeof(CharacterController))]
public class VRSettingSetter : Unit
{
	public enum VRSettingType
	{
		CenterOverride = 0,
		SmoothTurning = 1,
		ItemHoldType = 2,
		ContinuousMovement = 3
	}

	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput doneTrigger;

	[DoNotSerialize]
	public ValueInput settingType;

	[DoNotSerialize]
	public ValueInput settingValue;

	protected override void Definition()
	{
		doneTrigger = ControlOutput("Done");
		settingType = ValueInput("Type", VRSettingType.CenterOverride);
		settingValue = ValueInput("Value", @default: false);
		inputTrigger = ControlInput("Input", Routine);
	}

	private ControlOutput Routine(Flow flow)
	{
		bool value = flow.GetValue<bool>(settingValue);
		VRSettingType value2 = flow.GetValue<VRSettingType>(settingType);
		switch (value2)
		{
		case VRSettingType.CenterOverride:
			GamePreferences.Set(Preferences.SeatedPlayAreaType, value);
			break;
		case VRSettingType.SmoothTurning:
			GamePreferences.Set(Preferences.RotationMode, (!value) ? 1 : 2);
			break;
		case VRSettingType.ItemHoldType:
			GamePreferences.Set(Preferences.ItemHoldType, value ? 1 : 0);
			break;
		case VRSettingType.ContinuousMovement:
			GamePreferences.Set(Preferences.SmoothLocomotion, value);
			break;
		default:
			Debug.LogError(string.Format("[{0}] Unimplemented setting type '{1}', not changing anything.", "VRSettingSetter", value2));
			break;
		}
		return doneTrigger;
	}
}
