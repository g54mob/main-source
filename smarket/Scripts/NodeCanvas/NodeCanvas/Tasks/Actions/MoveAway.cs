using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Movement/Direct")]
	[Description("Moves the agent away from target per frame without pathfinding")]
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
