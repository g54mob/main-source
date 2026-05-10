using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard/Lists")]
	public class PickListElement<T> : ActionTask
	{
		[RequiredField]
		[BlackboardOnly]
		public BBParameter<List<T>> targetList;

		public BBParameter<int> index;

		[BlackboardOnly]
		public BBParameter<T> saveAs;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
