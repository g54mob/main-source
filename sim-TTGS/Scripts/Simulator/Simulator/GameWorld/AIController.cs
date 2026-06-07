using UnityEngine;

namespace Simulator.GameWorld
{
	public class AIController : Controller
	{
		[SerializeField]
		private AIBehaviour m_behaviour;

		public override bool IsPlayer => false;

		public IAIInputReceiver InputReceiver { get; private set; }

		protected override void GetInputReceiver(IControllable controllable)
		{
			if (controllable is IAIInputReceiver inputReceiver)
			{
				InputReceiver = inputReceiver;
			}
			else
			{
				LoseInputReceiver();
			}
		}

		protected override void LoseInputReceiver()
		{
			InputReceiver = null;
		}
	}
}
