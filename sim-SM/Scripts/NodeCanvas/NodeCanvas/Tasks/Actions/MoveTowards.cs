using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("Movement/Direct")]
	[Description("Moves the agent towards to target per frame without pathfinding")]
	public class MoveTowards : ActionTask<Transform>
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
