using Bolt;
using Ludiq;
using UnityEngine;

[TypeIcon(typeof(CharacterController))]
[UnitCategory("Input")]
[UnitSubtitle("Get some VR settings")]
[UnitTitle("VR Setting getter")]
public class VRSettingGetter : Unit
{
	[DoNotSerialize]
	public ValueInput settingType;

	[DoNotSerialize]
	public ValueOutput settingValue;

	protected override void Definition()
	{
		settingType = ValueInput("Type", VRSettingSetter.VRSettingType.CenterOverride);
		settingValue = ValueOutput("Value", delegate(Flow flow)
		{
			VRSettingSetter.VRSettingType value = flow.GetValue<VRSettingSetter.VRSettingType>(settingType);
			switch (value)
			{
			case VRSettingSetter.VRSettingType.CenterOverride:
				return GamePreferences.Get<bool>(Preferences.SeatedPlayAreaType);
			case VRSettingSetter.VRSettingType.SmoothTurning:
				return GamePreferences.Get<int>(Preferences.RotationMode) == 2;
			case VRSettingSetter.VRSettingType.ItemHoldType:
				return GamePreferences.Get<int>(Preferences.ItemHoldType) == 1;
			case VRSettingSetter.VRSettingType.ContinuousMovement:
				return GamePreferences.Get<bool>(Preferences.SmoothLocomotion);
			default:
				Debug.LogError(string.Format("[{0}] Unimplemented setting type '{1}', returning false.", "VRSettingGetter", value));
				return false;
			}
		});
	}
}
