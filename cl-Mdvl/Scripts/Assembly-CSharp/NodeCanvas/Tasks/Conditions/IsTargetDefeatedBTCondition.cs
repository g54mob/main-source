using FoxyVoxel.Logging;
using NSMedieval.BuildingComponents;
using NSMedieval.CommanderAI;
using NSMedieval.Enums;
using NSMedieval.Goap;
using NSMedieval.Village.Map.Pathfinding.SiegeTraversalProvider;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Going Medieval")]
	[Description("Returns true if the target is defeated")]
	public class IsTargetDefeatedBTCondition : ConditionTask<CommanderAgentProxy>
	{
		public BBParameter<IDamageTakingAgent> target;

		protected override string info => $"is {target} defeated";

		protected override bool OnCheck()
		{
			IDamageTakingAgent damageTakingAgent = target?.value;
			if (damageTakingAgent == null)
			{
				return true;
			}
			bool flag;
			if (damageTakingAgent is BaseBuildingInstance baseBuildingInstance)
			{
				DoorComponentInstance componentInstance = baseBuildingInstance.GetComponentInstance<DoorComponentInstance>();
				if (componentInstance != null)
				{
					flag = componentInstance.LockState == LockState.ForcedOpen;
					Log.Debug($"Target {damageTakingAgent} is defeated? {flag}", SiegeTraversalProvider.LogPath);
					return flag;
				}
				flag = baseBuildingInstance.HasDisposed || baseBuildingInstance.HasDied;
				Log.Debug($"Target {damageTakingAgent} is defeated? {flag}", SiegeTraversalProvider.LogPath);
				return flag;
			}
			flag = damageTakingAgent.HasDisposed || damageTakingAgent.HasDiedOrFainted;
			Log.Debug($"Target {damageTakingAgent} is defeated? {flag}", SiegeTraversalProvider.LogPath);
			return flag;
		}
	}
}
