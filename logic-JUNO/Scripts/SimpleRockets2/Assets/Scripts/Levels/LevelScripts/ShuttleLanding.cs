using Assets.Scripts.Flight.UI;
using Assets.Scripts.Levels.Requirements;
using ModApi.Common.Events;
using ModApi.Levels;
using ModApi.Math;

namespace Assets.Scripts.Levels.LevelScripts
{
	public class ShuttleLanding : Level
	{
		public override string GetPersistentMessage()
		{
			if (!base.IsComplete)
			{
				return "Land the shuttle (" + Units.GetStopwatchTimeString(base.Timer.ElapsedSeconds) + ")";
			}
			return "Landed! (" + Units.GetStopwatchTimeString(base.Timer.ElapsedSeconds) + ")";
		}

		public override void InitializeRequirements()
		{
			AddLevelRequirement(new TerrainContactRequirement(this, TerrainContactRequirement.ContactType.CraftLanded, "the runway"));
			FailLevelIfFuelEmpty = false;
			UnityEventDispatcher.Instance.ExecuteCustomYield(() => base.FlightScene?.ViewManager?.GameView?.GameCamera == null, delegate
			{
			});
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
			((FlightSceneInterfaceScript)base.FlightScene.FlightSceneUI).UiController.SetDisplayAltitudeTypeAGL(aboveGroundLevel: true);
		}
	}
}
