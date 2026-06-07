using Assets.Scripts.Levels.Requirements;
using ModApi.Levels;
using ModApi.Math;

namespace Assets.Scripts.Levels.LevelScripts
{
	public class MaximumSpeed : Level
	{
		private OrbitVelocityRequirement _velocityRequirement;

		public override string GetPersistentMessage()
		{
			return "Time: " + Units.GetStopwatchTimeString(base.Timer.ElapsedSeconds);
		}

		public override void InitializeRequirements()
		{
			_velocityRequirement = new OrbitVelocityRequirement(this, 30000f);
			AddLevelRequirement(_velocityRequirement);
		}

		protected override void OnFirstStageActivated()
		{
			base.OnFirstStageActivated();
			base.Timer.Start();
		}

		protected override void OnFlightLateUpdate()
		{
			base.OnFlightLateUpdate();
			Score = _velocityRequirement.MaximumPlayerVelocity;
			if (base.Timer.ElapsedSeconds >= 1728000.0)
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
		}
	}
}
