using System.Collections.Generic;
using System.Linq;
using NodeCanvas.Framework;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	public abstract class UnitsBTConditionBase : ConditionTask<CommanderAgentProxy>
	{
		public BBParameter<ICollection<CommanderAIUnit>> sourceUnits;

		protected ICollection<CommanderAIUnit> Units => sourceUnits?.value;

		protected CommanderAIUnit FirstUnit => Units.First();

		protected override string info => $"{sourceUnits}";
	}
}
