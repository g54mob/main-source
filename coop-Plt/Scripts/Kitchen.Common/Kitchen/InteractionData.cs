using Unity.Entities;

namespace Kitchen
{
	public struct InteractionData
	{
		public Entity Interactor;

		public EntityContext Context;

		public CAttemptingInteraction Attempt;

		public bool ShouldAct;

		public Entity Target => Attempt.Target;
	}
}
