using System.Collections;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Blackboard/Lists")]
	public class IsListCountEqualTo : ConditionTask
	{
		[RequiredField]
		[BlackboardOnly]
		public BBParameter<IList> targetList;

		[RequiredField]
		[BlackboardOnly]
		public BBParameter<int> count;

		protected override string info => $"{targetList}.Count == {count}";

		protected override bool OnCheck()
		{
			return targetList.value.Count == count.value;
		}
	}
}
