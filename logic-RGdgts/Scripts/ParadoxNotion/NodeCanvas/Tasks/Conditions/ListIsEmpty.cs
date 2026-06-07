using System.Collections;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Conditions
{
	public class ListIsEmpty : ConditionTask
	{
		[RequiredField]
		[BlackboardOnly]
		public BBParameter<IList> targetList;

		protected override string info => null;

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
