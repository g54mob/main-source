using NodeCanvas.Framework;
using UnityEngine;

namespace __Project__.Scripts.BT.CustomerHelperTasks.Actions
{
	public class RotateToQuaternion : ActionTask
	{
		public BBParameter<Transform> selfTransform;

		public BBParameter<Quaternion> targetRotation;

		public BBParameter<float> rotationTime;

		protected override void OnExecute()
		{
		}
	}
}
