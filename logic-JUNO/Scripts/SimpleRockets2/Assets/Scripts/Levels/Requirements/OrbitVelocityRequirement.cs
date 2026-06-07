using ModApi.Levels;
using ModApi.Levels.Requirements;
using ModApi.Math;

namespace Assets.Scripts.Levels.Requirements
{
	public class OrbitVelocityRequirement : LevelRequirement
	{
		public float MaximumPlayerVelocity { get; private set; }

		public float OrbitVelocity { get; }

		public OrbitVelocityRequirement(ILevel level, float orbitVelocity)
			: base(level)
		{
			OrbitVelocity = orbitVelocity;
			UpdateName();
		}

		protected override void OnFlightUpdate()
		{
			base.OnFlightUpdate();
			if (base.Level.PlayerCraft.CraftNode.Velocity.magnitude > (double)MaximumPlayerVelocity)
			{
				MaximumPlayerVelocity = (float)base.Level.PlayerCraft.CraftNode.Velocity.magnitude;
			}
			base.DisplayValue = Units.GetVelocityString((int)MaximumPlayerVelocity);
			if (MaximumPlayerVelocity >= OrbitVelocity)
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
			base.Name = $"Max Speed > {Units.GetVelocityString((int)OrbitVelocity)}";
		}
	}
}
