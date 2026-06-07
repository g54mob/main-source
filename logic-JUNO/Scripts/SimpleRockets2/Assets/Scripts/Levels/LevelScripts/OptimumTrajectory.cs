using Assets.Scripts.Levels.Requirements;
using ModApi.Levels;
using ModApi.Levels.Requirements;
using ModApi.Math;

namespace Assets.Scripts.Levels.LevelScripts
{
	public class OptimumTrajectory : Level
	{
		private SurfaceDistanceTravelRequirement _distanceRequirement;

		public override string GetPersistentMessage()
		{
			return "Distance Traveled: " + Units.GetDistanceString(Score);
		}

		public override void InitializeRequirements()
		{
			_distanceRequirement = new SurfaceDistanceTravelRequirement(this, 15000.0);
			AddLevelRequirement(_distanceRequirement);
			AddLevelRequirement(new TerrainContactRequirement(this, TerrainContactRequirement.ContactType.AvoidImpact, "ground")).VisibilityType = LevelRequirementVisibilityType.Hidden;
		}

		protected override void OnFlightLateUpdate()
		{
			base.OnFlightLateUpdate();
			Score = _distanceRequirement.SurfaceDistanceTraveled;
			if (_distanceRequirement.Status == LevelRequirementStatus.Pass)
			{
				FailLevelIfCraftDestroyed = false;
				if (base.AnyRequirementFailed || base.PlayerCraft.CraftNode.IsDestroyed)
				{
					CompleteLevel(success: true, Score);
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
