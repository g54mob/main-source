using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard")]
	[Description("Create a new Vector out of 3 floats and save it to the blackboard")]
	public class ComposeVector : ActionTask
	{
		public BBParameter<float> x;

		public BBParameter<float> y;

		public BBParameter<float> z;

		[BlackboardOnly]
		public BBParameter<Vector3> saveAs;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
