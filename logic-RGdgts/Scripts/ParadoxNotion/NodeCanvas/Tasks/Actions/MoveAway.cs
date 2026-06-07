using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class MoveAway : ActionTask<Transform>
	{
		[RequiredField]
		public BBParameter<GameObject> target;

		public BBParameter<float> speed;

		public BBParameter<float> stopDistance;

		public bool waitActionFinish;

		protected override void OnUpdate()
		{
		}
	}
}
