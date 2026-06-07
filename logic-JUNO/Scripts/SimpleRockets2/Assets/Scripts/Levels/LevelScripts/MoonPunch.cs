using Assets.Scripts.Levels.Requirements;
using ModApi.Levels;
using ModApi.Levels.Requirements;
using ModApi.Math;

namespace Assets.Scripts.Levels.LevelScripts
{
	public class MoonPunch : Level
	{
		public override string GetPersistentMessage()
		{
			return "Time: " + Units.GetStopwatchTimeString(base.Timer.ElapsedSeconds);
		}

		public override void InitializeRequirements()
		{
			ParentRequirement parentRequirement = new ParentRequirement(this, "Luna");
			parentRequirement.VisibilityType = LevelRequirementVisibilityType.Hidden;
			AddLevelRequirement(parentRequirement);
			AddLevelRequirement(new TerrainContactRequirement(this, TerrainContactRequirement.ContactType.CraftImpact, "Luna")).AddDependency(parentRequirement);
			FailLevelIfCraftDestroyed = false;
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
			if (base.Timer.ElapsedSeconds > 36000.0)
			{
				base.Timer.Stop();
				CompleteLevel(success: false, 0f);
			}
			else if (base.AllRequirementsPassed)
			{
				base.Timer.Stop();
				CompleteLevel(success: true, Score);
			}
			else if (base.AnyRequirementFailed)
			{
				base.Timer.Stop();
				CompleteLevel(success: false, 0f);
			}
		}
	}
}
