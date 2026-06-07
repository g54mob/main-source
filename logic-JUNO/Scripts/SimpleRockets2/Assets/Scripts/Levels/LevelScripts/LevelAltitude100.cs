using Assets.Scripts.Levels.Requirements;
using ModApi.Levels;
using ModApi.Math;

namespace Assets.Scripts.Levels.LevelScripts
{
	public class LevelAltitude100 : Level
	{
		public override string GetPersistentMessage()
		{
			return "Time: " + Units.GetStopwatchTimeString(base.Timer.ElapsedSeconds);
		}

		public override void InitializeRequirements()
		{
			AddLevelRequirement(new AltitudeRequirement(this, 100000f));
		}

		protected override void OnFirstStageActivated()
		{
			base.OnFirstStageActivated();
			base.Timer.Start();
		}

		protected override void OnFlightLateUpdate()
		{
			base.OnFlightLateUpdate();
			Score = (float)base.Timer.ElapsedSeconds;
			if (base.AllRequirementsPassed)
			{
				base.Timer.Stop();
				CompleteLevel(success: true, Score);
			}
		}
	}
}
