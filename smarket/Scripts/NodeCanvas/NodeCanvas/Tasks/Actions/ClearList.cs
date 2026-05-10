using System.Collections;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard/Lists")]
	public class ClearList : ActionTask
	{
		[RequiredField]
		[BlackboardOnly]
		public BBParameter<IList> targetList;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
