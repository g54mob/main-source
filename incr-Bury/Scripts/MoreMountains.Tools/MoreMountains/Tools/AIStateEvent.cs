namespace MoreMountains.Tools
{
	public struct AIStateEvent
	{
		public AIBrain Brain;

		public AIState ExitState;

		public AIState EnterState;

		private static AIStateEvent e;

		public AIStateEvent(AIBrain brain, AIState exitState, AIState enterState)
		{
			Brain = brain;
			ExitState = exitState;
			EnterState = enterState;
		}

		public static void Trigger(AIBrain brain, AIState exitState, AIState enterState)
		{
			e.Brain = brain;
			e.ExitState = exitState;
			e.EnterState = enterState;
			MMEventManager.TriggerEvent(e);
		}
	}
}
