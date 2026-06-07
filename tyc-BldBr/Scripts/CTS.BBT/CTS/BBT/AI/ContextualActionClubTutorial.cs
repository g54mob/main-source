using System;

namespace CTS.BBT.AI
{
	[Serializable]
	internal sealed class ContextualActionClubTutorial : ContextualAction<Customer>
	{
		public override void Setup()
		{
		}

		public override bool CanBePerformed(Worker p_worker)
		{
			if (contextActor.IsVampire)
			{
				return false;
			}
			if (!p_worker.IsEngaged)
			{
				return false;
			}
			if (!p_worker.ContextualFSM.CurrentStateEquals<ContextualStateNormal>())
			{
				return false;
			}
			return !contextActor.ContextualFSM.CurrentStateEquals<ContextualStateUnconscious, ContextualStateDead>();
		}

		protected override void Execution(Worker p_worker)
		{
		}
	}
}
