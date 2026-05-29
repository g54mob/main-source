using NodeCanvas.Framework;
using UnityEngine;

namespace __Project__.Scripts.BT.CustomerHelperTasks.Actions
{
	public class GetHelperControllableControlTransform : ActionTask
	{
		public BBParameter<ICustomerHelperControllable> From;

		public BBParameter<Vector3> Position;

		protected override void OnExecute()
		{
		}
	}
}
