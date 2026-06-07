using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class InputMove : ActionTask<Transform>
	{
		[BlackboardOnly]
		public BBParameter<float> strafe;

		[BlackboardOnly]
		public BBParameter<float> turn;

		[BlackboardOnly]
		public BBParameter<float> forward;

		[BlackboardOnly]
		public BBParameter<float> up;

		public BBParameter<float> moveSpeed;

		public BBParameter<float> rotationSpeed;

		public bool repeat;

		protected override void OnUpdate()
		{
		}
	}
}
