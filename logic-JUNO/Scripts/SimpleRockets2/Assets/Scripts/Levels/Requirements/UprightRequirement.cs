using ModApi.Levels;
using ModApi.Levels.Requirements;
using UnityEngine;

namespace Assets.Scripts.Levels.Requirements
{
	public class UprightRequirement : LevelRequirement
	{
		public double Leeway { get; set; }

		public UprightRequirement(ILevel level, float leeway = 0.7f)
			: base(level)
		{
			Leeway = leeway;
			UpdateName();
		}

		protected override void OnFlightUpdate()
		{
			base.OnFlightUpdate();
			if ((double)Vector3.Dot(-base.Level.PlayerCraft.GravityNormal, base.Level.PlayerCraft.CenterOfMass.forward) > Leeway)
			{
				base.Status = LevelRequirementStatus.Pass;
			}
			else
			{
				base.Status = LevelRequirementStatus.Incomplete;
			}
		}

		private void UpdateName()
		{
			base.Name = "Must be upright";
		}
	}
}
