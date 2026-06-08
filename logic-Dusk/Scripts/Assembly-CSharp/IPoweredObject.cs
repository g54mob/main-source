public interface IPoweredObject
{
	float CurrentPower { get; }

	float TotalPower { get; }

	bool IsCharging { get; }

	bool CanRecharge { get; }

	bool ShowPercentage { get; }

	string guiStatus { get; }

	void OverridePower(float power);
}
