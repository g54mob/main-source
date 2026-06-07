using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class RotateAway : ActionTask<Transform>
	{
		[RequiredField]
		public BBParameter<GameObject> target;

		public BBParameter<float> speed;

		public BBParameter<float> angleDifference;

		public BBParameter<Vector3> upVector;

		public bool waitActionFinish;

		protected override void OnUpdate()
		{
		}
	}
}
