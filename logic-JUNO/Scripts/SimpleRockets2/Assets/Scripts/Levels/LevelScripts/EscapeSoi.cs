using Assets.Scripts.Levels.Requirements;
using ModApi.Levels;
using ModApi.Math;

namespace Assets.Scripts.Levels.LevelScripts
{
	public class EscapeSoi : Level
	{
		public override string GetPersistentMessage()
		{
			return "Fuel Used: " + Units.GetVolumeString(Score * 1000f);
		}

		public override void InitializeRequirements()
		{
			AddLevelRequirement(new FuelRequirement(this, 60000f));
			AddLevelRequirement(new ParentRequirement(this, "Juno"));
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
