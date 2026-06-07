using ModApi.Levels;
using ModApi.Levels.Requirements;
using ModApi.Math;

namespace Assets.Scripts.Levels.Requirements
{
	public class SurfaceVelocityRequirement : LevelRequirement
	{
		public float SurfaceVelocity { get; }

		public float MaximumPlayerVelocity { get; private set; }

		public SurfaceVelocityRequirement(ILevel level, float surfaceVelocity)
			: base(level)
		{
			SurfaceVelocity = surfaceVelocity;
			UpdateName();
		}

		protected override void OnFlightUpdate()
		{
			base.OnFlightUpdate();
			if (base.Level.PlayerCraft.SurfaceVelocity.magnitude > MaximumPlayerVelocity)
			{
				MaximumPlayerVelocity = base.Level.PlayerCraft.SurfaceVelocity.magnitude;
			}
			base.DisplayValue = Units.GetVelocityString((int)MaximumPlayerVelocity);
			if (MaximumPlayerVelocity >= SurfaceVelocity)
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
			base.Name = $"Surface Velocity > {Units.GetVelocityString((int)SurfaceVelocity)}";
		}
	}
}
