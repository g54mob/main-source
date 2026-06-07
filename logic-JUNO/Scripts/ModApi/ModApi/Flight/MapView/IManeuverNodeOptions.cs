namespace ModApi.Flight.MapView
{
	public interface IManeuverNodeOptions
	{
		bool DisplayInfoWhenAdjusting { get; set; }

		float MaxGizmoMultiplier { get; }

		double SensitivityExpo { get; }

		double SensitivityLinear { get; set; }

		bool ShowBurnAccuracyDebugGizmos { get; set; }
	}
}
