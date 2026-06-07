using System;
using Assets.Scripts.Settings;

namespace Assets.Scripts.Flight.Combat.Predictor
{
	public static class PredictorSettings
	{
		[Flags]
		public enum PredictorVisuals
		{
			None = 0,
			DrawLine = 1,
			DrawTargetProjection = 2,
			DrawUIReticle = 4
		}

		public static float DeltaTime { get; private set; }

		public static float MaxSimTime { get; private set; }

		public static float UpdatesPerVertex { get; private set; }

		public static PredictorVisuals Visuals { get; private set; }

		public static event Action SettingsUpdated;

		public static void ApplySettings(PhysicsQualitySettings settings, bool recalculate = true)
		{
			switch (settings.PredictorQuality.Value)
			{
			case PhysicsQualitySettings.PredictorQualityLevel.Low:
				DeltaTime = settings.FixedDeltaTime * 20f;
				MaxSimTime = 40f;
				UpdatesPerVertex = 5f;
				Visuals = PredictorVisuals.DrawLine | PredictorVisuals.DrawUIReticle;
				break;
			case PhysicsQualitySettings.PredictorQualityLevel.Medium:
				DeltaTime = settings.FixedDeltaTime * 8f;
				MaxSimTime = 80f;
				UpdatesPerVertex = 5f;
				Visuals = PredictorVisuals.DrawLine | PredictorVisuals.DrawTargetProjection;
				break;
			case PhysicsQualitySettings.PredictorQualityLevel.High:
				DeltaTime = settings.FixedDeltaTime * 2f;
				MaxSimTime = 120f;
				UpdatesPerVertex = 5f;
				Visuals = PredictorVisuals.DrawLine | PredictorVisuals.DrawTargetProjection;
				break;
			}
			if (recalculate)
			{
				PredictorSettings.SettingsUpdated?.Invoke();
			}
		}
	}
}
