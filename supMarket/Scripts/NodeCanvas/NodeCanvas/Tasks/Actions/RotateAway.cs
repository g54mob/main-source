using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Movement/Direct")]
	[Description("Rotate the agent away from target per frame")]
	public class RotateAway : ActionTask<Transform>
	{
		[RequiredField]
		public BBParameter<GameObject> target;

		public BBParameter<float> speed;

		[SliderField(1, 180)]
		public BBParameter<float> angleDifference;

		public BBParameter<Vector3> upVector;

		public bool waitActionFinish;

		protected override void OnUpdate()
		{
		}
	}
}
