using System.Collections.Generic;
using System.Linq;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	[Category("✫ Going Medieval")]
	[Description("Filter unit list based on parameters")]
	public class FilterUnitListBTAction : CommanderAIBTActionBase
	{
		[RequiredField]
		public BBParameter<IEnumerable<CommanderAIUnit>> sourceUnits;

		[RequiredField]
		public BBParameter<IEnumerable<CommanderAIUnit>> exceptUnits;

		public BBParameter<List<CommanderAIUnit>> saveAs;

		protected override string info => $"{saveAs} = {sourceUnits} except {exceptUnits}";

		protected override void OnStart()
		{
			List<CommanderAIUnit> value = sourceUnits.value.Where((CommanderAIUnit unit) => !exceptUnits.value.Contains(unit)).ToList();
			saveAs.SetValue(value);
			EndAction();
		}
	}
}
