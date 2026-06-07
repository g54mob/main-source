using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
	public class SetListElement<T> : ActionTask
	{
		[RequiredField]
		[BlackboardOnly]
		public BBParameter<List<T>> targetList;

		public BBParameter<int> index;

		public BBParameter<T> newValue;

		protected override void OnExecute()
		{
		}
	}
}
