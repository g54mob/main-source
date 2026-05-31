using NodeCanvas.Framework;
using UnityEngine;

namespace __Project__.Scripts.BT.CustomerHelperTasks.Actions
{
	public class GetHelperControllableTransform : ActionTask
	{
		public BBParameter<ICustomerHelperControllable> From;

		public BBParameter<Transform> To;

		protected override void OnExecute()
		{
		}
	}
}
