using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Utility")]
	[Description("Sends an event to all GraphOwners within range of the agent and over time like a shockwave.")]
	public class ShoutEvent : ActionTask<Transform>
	{
		[RequiredField]
		public BBParameter<string> eventName;

		public BBParameter<float> shoutRange;

		public BBParameter<float> completionTime;

		private GraphOwner[] owners;

		private bool[] receivedOwners;

		private float traveledDistance;

		protected override string info => null;

		protected override void OnExecute()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void OnDrawGizmosSelected()
		{
		}
	}
}
