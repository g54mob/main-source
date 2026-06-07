using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class DecomposeVector : ActionTask
	{
		public BBParameter<Vector3> targetVector;

		[BlackboardOnly]
		public BBParameter<float> x;

		[BlackboardOnly]
		public BBParameter<float> y;

		[BlackboardOnly]
		public BBParameter<float> z;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
