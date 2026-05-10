using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Movement/Direct")]
	[Description("Move & turn the agent based on input values provided ranging from -1 to 1, per second (using delta time)")]
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
