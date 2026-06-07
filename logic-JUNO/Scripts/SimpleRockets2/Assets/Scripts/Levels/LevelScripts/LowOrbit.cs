using Assets.Scripts.Levels.Requirements;
using ModApi.Levels;
using ModApi.Levels.Requirements;
using ModApi.Math;

namespace Assets.Scripts.Levels.LevelScripts
{
	public class LowOrbit : Level
	{
		public override string GetPersistentMessage()
		{
			return "Fuel Used: " + Units.GetVolumeString(Score * 1000f);
		}

		public override void InitializeRequirements()
		{
			AddLevelRequirement(new FuelRequirement(this, 10000f));
			ILevelRequirement levelRequirement = AddLevelRequirement(new ParentRequirement(this, "Droo"));
			levelRequirement.VisibilityType = LevelRequirementVisibilityType.HiddenWhenPassed;
			AddLevelRequirement(new ApsisRequirement(this, ApsisRequirement.ApsisType.Apoapsis, 100000.0)).AddDependency(levelRequirement);
			AddLevelRequirement(new ApsisRequirement(this, ApsisRequirement.ApsisType.Periapsis, 100000.0)).AddDependency(levelRequirement);
			FailLevelIfFuelEmpty = true;
		}

		protected override void OnFlightLateUpdate()
		{
			base.OnFlightLateUpdate();
			Score = FuelUsed / 1000f;
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

		protected override void OnInitialized()
		{
			base.OnInitialized();
			base.DisplayCraftFuelInDesigner = true;
		}
	}
}
