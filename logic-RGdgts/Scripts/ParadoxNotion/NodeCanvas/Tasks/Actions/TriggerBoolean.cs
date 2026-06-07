using System.Collections;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
	public class TriggerBoolean : ActionTask
	{
		[RequiredField]
		[BlackboardOnly]
		public BBParameter<bool> variable;

		protected override string info => null;

		protected override void OnExecute()
		{
		}

		private IEnumerator Flip()
		{
			return null;
		}
	}
}
