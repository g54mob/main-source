using System.ComponentModel;
using NSMedieval.BuildingComponents;
using NSMedieval.CommanderAI;
using NSMedieval.Goap;
using NSMedieval.State;
using NodeCanvas.Framework;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Going Medieval")]
	[Description("Returns true if the given target is of the selected type")]
	public class TargetTypeBTCondition : ConditionTask<CommanderAgentProxy>
	{
		public enum TargetType
		{
			Worker = 0,
			Humanoid = 1,
			Creature = 2,
			Door = 3,
			Building = 4
		}

		public BBParameter<IDamageTakingAgent> target;

		public TargetType targetType;

		protected override string info => $"{target} is {targetType}";

		protected override bool OnCheck()
		{
			if (target?.value == null || target.value.HasDisposed)
			{
				return false;
			}
			return targetType switch
			{
				TargetType.Worker => target.value is HumanoidInstance humanoidInstance && humanoidInstance.IsWorker(), 
				TargetType.Humanoid => target.value is HumanoidInstance, 
				TargetType.Creature => target.value is CreatureBase, 
				TargetType.Door => target.value is BaseBuildingInstance baseBuildingInstance && baseBuildingInstance.GetComponentInstance<DoorComponentInstance>() != null, 
				TargetType.Building => target.value is BaseBuildingInstance, 
				_ => false, 
			};
		}
	}
}
