using ModApi.Levels;
using ModApi.Levels.Requirements;
using ModApi.Math;

namespace Assets.Scripts.Levels.Requirements
{
	public class FuelRequirement : LevelRequirement
	{
		public float MaxFuel { get; }

		public FuelRequirement(ILevel level, float maxFuel)
			: base(level)
		{
			MaxFuel = maxFuel;
			UpdateName();
		}

		protected override void OnFlightUpdate()
		{
			base.OnFlightUpdate();
			base.DisplayValue = Units.GetVolumeString(base.Level.FuelUsed);
			if (base.Level.FuelUsed <= MaxFuel)
			{
				base.Status = LevelRequirementStatus.Pass;
			}
			else
			{
				base.Status = LevelRequirementStatus.Fail;
			}
		}

		private void UpdateName()
		{
			base.Name = $"Fuel Used < {Units.GetVolumeString(MaxFuel)}";
		}
	}
}
