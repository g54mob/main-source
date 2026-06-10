using System.Collections;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard/Lists")]
	public class GetListCount : ActionTask
	{
		[RequiredField]
		[BlackboardOnly]
		public BBParameter<IList> targetList;

		[BlackboardOnly]
		public BBParameter<int> saveAs;

		protected override string info => $"{saveAs} = {targetList}.Count";

		protected override void OnExecute()
		{
			saveAs.value = targetList.value.Count;
			EndAction(success: true);
		}
	}
}
