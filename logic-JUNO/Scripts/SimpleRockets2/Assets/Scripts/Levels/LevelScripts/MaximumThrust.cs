using Assets.Scripts.Levels.Requirements;
using ModApi.Levels;
using ModApi.Math;

namespace Assets.Scripts.Levels.LevelScripts
{
	public class MaximumThrust : Level
	{
		private SurfaceVelocityRequirement _velocityRequirement;

		public override string GetPersistentMessage()
		{
			return "Max Velocity: " + Units.GetVelocityString((int)Score);
		}

		public override void InitializeRequirements()
		{
			_velocityRequirement = new SurfaceVelocityRequirement(this, 750f);
			AddLevelRequirement(_velocityRequirement);
			AddLevelRequirement(new LateralMovementRequirement(this, 100.0));
		}

		protected override void OnFlightLateUpdate()
		{
			base.OnFlightLateUpdate();
			Score = _velocityRequirement.MaximumPlayerVelocity;
			if (base.PlayerCraft.FlightData.AltitudeAboveGroundLevel > 2000.0)
			{
				if (base.AllRequirementsPassed)
				{
					base.Timer.Stop();
					CompleteLevel(success: true, Score);
				}
				else
				{
					base.Timer.Stop();
					CompleteLevel(success: false, 0f);
				}
			}
			else if (base.AnyRequirementFailed)
			{
				base.Timer.Stop();
				CompleteLevel(success: false, 0f);
			}
		}

		protected override void OnFlightSceneReady()
		{
			base.OnFlightSceneReady();
			base.Timer.Start();
		}
	}
}
