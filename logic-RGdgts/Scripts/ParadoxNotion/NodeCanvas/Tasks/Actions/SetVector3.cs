using NodeCanvas.Framework;
using ParadoxNotion;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class SetVector3 : ActionTask
	{
		[BlackboardOnly]
		public BBParameter<Vector3> valueA;

		public OperationMethod operation;

		public BBParameter<Vector3> valueB;

		public bool perSecond;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
