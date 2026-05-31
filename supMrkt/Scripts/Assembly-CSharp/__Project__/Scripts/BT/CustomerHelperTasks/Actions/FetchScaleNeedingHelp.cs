using NodeCanvas.Framework;
using UnityEngine;

namespace __Project__.Scripts.BT.CustomerHelperTasks.Actions
{
	public class FetchScaleNeedingHelp : ActionTask
	{
		public BBParameter<Scale> TargetScale;

		public BBParameter<Vector3> TargetScalePosition;

		public BBParameter<Quaternion> TargetScaleRotation;

		protected override void OnExecute()
		{
		}
	}
}
