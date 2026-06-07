using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Conditions
{
	public class ListContainsElement<T> : ConditionTask
	{
		[RequiredField]
		[BlackboardOnly]
		public BBParameter<List<T>> targetList;

		public BBParameter<T> checkElement;

		protected override string info => null;

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
