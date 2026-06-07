using ModApi.Levels;
using ModApi.Levels.Requirements;
using ModApi.Math;

namespace Assets.Scripts.Levels.Requirements
{
	public class AltitudeRequirement : LevelRequirement
	{
		public float Altitude { get; private set; }

		public AltitudeRequirement(ILevel level, float altitude)
			: base(level)
		{
			Altitude = altitude;
			base.Name = $"Altitude > {Units.GetDistanceString(Altitude)}";
		}

		protected override void OnFlightUpdate()
		{
			base.OnFlightUpdate();
			if (base.Level.PlayerCraft.FlightData.AltitudeAboveSeaLevel >= (double)Altitude)
			{
				base.Status = LevelRequirementStatus.Pass;
			}
			else
			{
				base.Status = LevelRequirementStatus.Incomplete;
			}
			base.DisplayValue = Units.GetDistanceString((float)base.Level.PlayerCraft.FlightData.AltitudeAboveSeaLevel);
		}
	}
}
