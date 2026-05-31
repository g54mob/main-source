using NodeCanvas.Framework;
using UnityEngine;

namespace __Project__.Scripts.BT.CustomerHelperTasks.Actions
{
	public class GetHelperControllableStandingTransform : ActionTask
	{
		public BBParameter<ICustomerHelperControllable> From;

		public BBParameter<Vector3> Position;

		public BBParameter<Quaternion> Rotation;

		protected override void OnExecute()
		{
		}
	}
}
