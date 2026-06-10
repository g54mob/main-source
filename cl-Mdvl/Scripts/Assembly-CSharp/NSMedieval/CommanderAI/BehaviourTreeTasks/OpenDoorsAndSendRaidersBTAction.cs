using NSMedieval.BuildingComponents;
using NSMedieval.CombatAi;
using NSMedieval.Village;
using ParadoxNotion.Design;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	[Category("✫ Going Medieval")]
	[Description("Open all doors on the map and send all raiders attacking")]
	public class OpenDoorsAndSendRaidersBTAction : UnitsBTActionBase
	{
		protected override string info => $"Open all doors and send {sourceUnits} attacking";

		protected override void OnStart()
		{
			foreach (DoorComponentInstance componentInstance in VillageManager.ActiveVillage.Map.DoorComponentManager.ComponentInstances)
			{
				componentInstance.SetAlwaysOpen();
			}
			foreach (CommanderAIUnit item in sourceUnits.value)
			{
				CombatAiAgent combatAi = item.Humanoid.EnemyBehaviour.CombatAi;
				combatAi.GoalScheduler.AddToPool(new EnemyTargetWorkersAiPlanGoal(combatAi), enableGoal: true);
			}
		}
	}
}
