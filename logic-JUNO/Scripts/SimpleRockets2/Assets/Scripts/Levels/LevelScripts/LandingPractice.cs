using Assets.Scripts.Flight.UI;
using Assets.Scripts.Levels.Requirements;
using ModApi.Levels;
using ModApi.Levels.Requirements;

namespace Assets.Scripts.Levels.LevelScripts
{
	public class LandingPractice : Level
	{
		public override string GetPersistentMessage()
		{
			return "Landing Practice";
		}

		public override void InitializeRequirements()
		{
			ParentRequirement parentRequirement = new ParentRequirement(this, "Luna");
			parentRequirement.VisibilityType = LevelRequirementVisibilityType.Hidden;
			AddLevelRequirement(parentRequirement);
			AddLevelRequirement(new TerrainContactRequirement(this, TerrainContactRequirement.ContactType.CraftLanded, "Luna", includeWaterAsContact: false)).AddDependency(parentRequirement);
			AddLevelRequirement(new UprightRequirement(this));
		}

		protected override void OnFlightLateUpdate()
		{
			base.OnFlightLateUpdate();
			if (base.AllRequirementsPassed)
			{
				base.Timer.Stop();
				CompleteLevel(success: true, 1f);
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
			((FlightSceneInterfaceScript)base.FlightScene.FlightSceneUI).UiController.SetDisplayAltitudeTypeAGL(aboveGroundLevel: true);
		}
	}
}
