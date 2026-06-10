using NSEipix;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	[Category("✫ Going Medieval/Pick Random Unit")]
	[Description("Pick random unit and get it as CommanderAIUnit")]
	public class PickRandomUnit : UnitsBTActionBase
	{
		public BBParameter<CommanderAIUnit> saveAs;

		protected override string info => $"Pick random unit from {sourceUnits} and save it to {saveAs}";

		protected override void OnStart()
		{
			base.OnStart();
			saveAs.SetValue(sourceUnits.value.PickRandom());
			EndAction(success: true);
		}
	}
}
