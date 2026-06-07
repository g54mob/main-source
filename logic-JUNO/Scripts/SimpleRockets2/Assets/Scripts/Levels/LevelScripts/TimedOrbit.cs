using Assets.Scripts.Levels.Requirements;
using ModApi.Levels;
using ModApi.Levels.Requirements;
using ModApi.Math;

namespace Assets.Scripts.Levels.LevelScripts
{
	public class TimedOrbit : Level
	{
		public override string GetPersistentMessage()
		{
			return "Time: " + Units.GetStopwatchTimeString(base.Timer.ElapsedSeconds);
		}

		public override void InitializeRequirements()
		{
			ILevelRequirement levelRequirement = AddLevelRequirement(new ParentRequirement(this, "Droo"));
			levelRequirement.VisibilityType = LevelRequirementVisibilityType.HiddenWhenPassed;
			AddLevelRequirement(new ApsisRequirement(this, ApsisRequirement.ApsisType.Apoapsis, 100000.0)).AddDependency(levelRequirement);
			AddLevelRequirement(new ApsisRequirement(this, ApsisRequirement.ApsisType.Periapsis, 100000.0)).AddDependency(levelRequirement);
			AddLevelRequirement(new TimeRequirement(this, 300f));
			FailLevelIfFuelEmpty = true;
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
			if (base.AnyRequirementFailed)
			{
				base.Timer.Stop();
				CompleteLevel(success: false, 0f);
			}
			else if (base.AllRequirementsPassed)
			{
				base.Timer.Stop();
				CompleteLevel(success: true, Score);
			}
		}
	}
}
