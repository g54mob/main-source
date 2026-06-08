public class DroneUpgradeDefinition
{
	public DroneUpgradeType Type { get; private set; }

	public bool IsVisible { get; private set; }

	public string Name { get; private set; }

	public string Description { get; private set; }

	public float Power { get; private set; }

	public float Weight { get; private set; }

	public float Cost { get; private set; }

	public float ModifierValue { get; private set; }

	public float ActivationCooldown { get; private set; }

	public float ActivationDuration { get; private set; }

	public DroneUpgradeClass UpgradeClass { get; private set; }

	public int MinimumErrorMissions { get; private set; }

	public int MaximumErrorMissions { get; private set; }

	public int MinimumErrorMissionsPostRepair { get; private set; }

	public int MaximumErrorMissionsPostRepair { get; private set; }

	public float MinimumErrorTime { get; private set; }

	public float MaximumErrorTime { get; private set; }

	public float MinimumBreakTimeDelta { get; private set; }

	public float MaximumBreakTimeDelta { get; private set; }

	public DroneUpgradeDefinition(string typeString, string isVisibleString, string name, string description, string powerString, string weightString, string costString, string modifierValueString, string activationCooldownString, string activationDurationString, string upgradeClassString)
	{
		Type = DroneUpgradeType.Undefined;
		int result;
		if (int.TryParse(typeString, out result))
		{
			Type = (DroneUpgradeType)result;
		}
		bool result2;
		if (bool.TryParse(isVisibleString, out result2))
		{
			IsVisible = result2;
		}
		Name = name;
		Description = description;
		float result3;
		if (float.TryParse(powerString, out result3))
		{
			Power = result3;
		}
		float result4;
		if (float.TryParse(weightString, out result4))
		{
			Weight = result4;
		}
		float result5;
		if (float.TryParse(costString, out result5))
		{
			Cost = result5;
		}
		float result6;
		if (float.TryParse(modifierValueString, out result6))
		{
			ModifierValue = result6;
		}
		float result7;
		if (float.TryParse(activationCooldownString, out result7))
		{
			ActivationCooldown = result7;
		}
		float result8;
		if (float.TryParse(activationDurationString, out result8))
		{
			ActivationDuration = result8;
		}
		UpgradeClass = DroneUpgradeClass.None;
		int result9;
		if (int.TryParse(upgradeClassString, out result9))
		{
			UpgradeClass = (DroneUpgradeClass)result9;
		}
		MinimumErrorMissions = 0;
		MaximumErrorMissions = 0;
		MinimumErrorMissionsPostRepair = 0;
		MaximumErrorMissionsPostRepair = 0;
		MinimumErrorTime = 0f;
		MaximumErrorTime = 0f;
		MinimumBreakTimeDelta = 120f;
		MaximumBreakTimeDelta = 180f;
	}

	public override string ToString()
	{
		return string.Format("[DroneUpgradeDefinition: Type={0}, IsVisible={1}, Name={2}]", Type, IsVisible, Name);
	}
}
