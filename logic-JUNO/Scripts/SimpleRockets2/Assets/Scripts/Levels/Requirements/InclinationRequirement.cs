using System;
using ModApi.Levels;
using ModApi.Levels.Requirements;

namespace Assets.Scripts.Levels.Requirements
{
	public class InclinationRequirement : LevelRequirement
	{
		public double Inclination { get; private set; }

		public double Range { get; private set; }

		public InclinationRequirement(ILevel level, double inclination, double range = 5.0)
			: base(level)
		{
			Inclination = inclination;
			Range = range;
			base.Name = $"Inclination = {Inclination} +/- {Range}";
		}

		protected override void OnFlightUpdate()
		{
			base.OnFlightUpdate();
			double num = base.Level.PlayerCraft.CraftNode.Orbit.Inclination * 57.295780181884766;
			if (Math.Abs(num - Inclination) < Range)
			{
				base.Status = LevelRequirementStatus.Pass;
			}
			else
			{
				base.Status = LevelRequirementStatus.Incomplete;
			}
			base.DisplayValue = num.ToString("0.0");
		}
	}
}
