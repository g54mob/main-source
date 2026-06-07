using System.Collections;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
	public class ShuffleList : ActionTask
	{
		[RequiredField]
		[BlackboardOnly]
		public BBParameter<IList> targetList;

		protected override void OnExecute()
		{
		}
	}
}
