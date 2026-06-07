using Assets.Scripts.Levels.Requirements;
using ModApi.Levels;
using ModApi.State;
using UnityEngine;

namespace Assets.Scripts.Levels.LevelScripts
{
	public class CareerContract : Level
	{
		public override LaunchLocation LaunchLocation => Game.Instance.GameState.SelectedLaunchLocation;

		public override string GetPersistentMessage()
		{
			return base.LevelData.DisplayName;
		}

		public override void InitializeRequirements()
		{
			AddLevelRequirement(new ContractRequirement(this, base.LevelData.ContractId));
			FailLevelIfCraftDestroyed = false;
		}

		protected override void OnFlightLateUpdate()
		{
			base.OnFlightLateUpdate();
			if (base.AllRequirementsPassed)
			{
				CompleteLevel(success: true, 0f);
				Debug.Log("Passed");
			}
			else if (base.AnyRequirementFailed)
			{
				CompleteLevel(success: false, 0f);
			}
		}
	}
}
