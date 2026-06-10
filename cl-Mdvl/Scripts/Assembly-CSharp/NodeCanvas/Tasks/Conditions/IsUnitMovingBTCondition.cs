using NSMedieval.CommanderAI;
using NSMedieval.State;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Going Medieval")]
	[Description("Returns true if the given unit has pathDriver.IsMoving == true")]
	public class IsUnitMovingBTCondition : ConditionTask
	{
		public BBParameter<CommanderAIUnit> Unit;

		protected override string info => $"{Unit} is moving";

		protected override bool OnCheck()
		{
			HumanoidInstance humanoid = Unit.value.Humanoid;
			if (humanoid.HasDiedOrFainted)
			{
				return false;
			}
			return humanoid.PathDriver.IsMoving;
		}
	}
}
