using Assets.Scripts.Levels.Requirements;
using ModApi.Levels;
using ModApi.Levels.Requirements;
using ModApi.Math;

namespace Assets.Scripts.Levels.LevelScripts
{
	public class MoonLanding : Level
	{
		public override string GetPersistentMessage()
		{
			return "Fuel Used: " + Units.GetVolumeString(Score * 1000f);
		}

		public override void InitializeRequirements()
		{
			ParentRequirement parentRequirement = new ParentRequirement(this, "Luna");
			parentRequirement.VisibilityType = LevelRequirementVisibilityType.Hidden;
			AddLevelRequirement(parentRequirement);
			AddLevelRequirement(new TerrainContactRequirement(this, TerrainContactRequirement.ContactType.CraftLanded, "Luna", includeWaterAsContact: false)).AddDependency(parentRequirement);
			AddLevelRequirement(new FuelRequirement(this, 50000f));
			AddLevelRequirement(new UprightRequirement(this));
		}

		protected override void OnFirstStageActivated()
		{
			base.OnFirstStageActivated();
			base.Timer.Start();
		}

		protected override void OnFlightLateUpdate()
		{
			base.OnFlightLateUpdate();
			Score = FuelUsed / 1000f;
			if (base.AllRequirementsPassed)
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

		protected override void OnInitialized()
		{
			base.OnInitialized();
			base.DisplayCraftFuelInDesigner = true;
		}
	}
}
