using System;
using Bolt;
using DV.Common;
using Ludiq;
using UnityEngine.UI;

[UnitSubtitle("Enable, disable, or set the game feature flags")]
[UnitTitle("Update Feature Flags")]
[TypeIcon(typeof(Toggle))]
[UnitCategory("Movement")]
public class UpdateFeatureFlagsUnit : Unit
{
	public enum UpdateMode
	{
		Enable = 0,
		Disable = 1,
		Overwrite = 2
	}

	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput updatedTrigger;

	[DoNotSerialize]
	public ValueInput modeValue;

	[DoNotSerialize]
	public ValueInput[] flagValues;

	protected override void Definition()
	{
		updatedTrigger = ControlOutput("Updated");
		modeValue = ValueInput("Mode", UpdateMode.Enable);
		GameFeatureFlags.Flag[] allFlags = (GameFeatureFlags.Flag[])Enum.GetValues(typeof(GameFeatureFlags.Flag));
		flagValues = new ValueInput[allFlags.Length];
		for (int i = 0; i < allFlags.Length; i++)
		{
			flagValues[i] = ValueInput(allFlags[i].ToString(), @default: false);
		}
		inputTrigger = ControlInput("Input", delegate(Flow flow)
		{
			UpdateMode value = flow.GetValue<UpdateMode>(modeValue);
			for (int j = 0; j < allFlags.Length; j++)
			{
				GameFeatureFlags.Flag flag = allFlags[j];
				bool value2 = flow.GetValue<bool>(flagValues[j]);
				switch (value)
				{
				case UpdateMode.Enable:
					if (value2)
					{
						GameFeatureFlags.Allow(flag);
					}
					break;
				case UpdateMode.Disable:
					if (value2)
					{
						GameFeatureFlags.Deny(flag);
					}
					break;
				case UpdateMode.Overwrite:
					if (value2)
					{
						GameFeatureFlags.Allow(flag);
					}
					else
					{
						GameFeatureFlags.Deny(flag);
					}
					break;
				}
			}
			return updatedTrigger;
		});
	}
}
