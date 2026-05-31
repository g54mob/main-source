using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard")]
	[Description("Set a blackboard Vector3 variable")]
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
