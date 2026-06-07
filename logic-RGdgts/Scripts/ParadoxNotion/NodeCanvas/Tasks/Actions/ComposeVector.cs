using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
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
