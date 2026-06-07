using Assets.Scripts.Levels.Requirements;
using ModApi.Levels;
using ModApi.Math;
using ModApi.Scenes.Parameters;

namespace Assets.Scripts.Levels.LevelScripts
{
	public class ParachuteLanding : Level
	{
		public override string GetPersistentMessage()
		{
			if (!base.IsComplete)
			{
				return "Land on Droo (" + Units.GetStopwatchTimeString(base.Timer.ElapsedSeconds) + ")";
			}
			return "Landed on Droo! (" + Units.GetStopwatchTimeString(base.Timer.ElapsedSeconds) + ")";
		}

		public override void InitializeRequirements()
		{
			AddLevelRequirement(new TerrainContactRequirement(this, TerrainContactRequirement.ContactType.CraftLanded, "Droo"));
			FailLevelIfFuelEmpty = false;
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

		protected override void OnFlightSceneReady()
		{
			base.OnFlightSceneReady();
			base.Timer.Start();
		}

		protected override void OverrideFlightSceneLoadParameters(FlightSceneLoadParameters loadParameters)
		{
			base.OverrideFlightSceneLoadParameters(loadParameters);
			loadParameters.HeatDamage = true;
		}
	}
}
