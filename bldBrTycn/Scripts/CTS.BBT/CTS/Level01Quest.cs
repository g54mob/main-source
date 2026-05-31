using CTS.BBT.AI;
using CTS.Core;

namespace CTS
{
	public abstract class Level01Quest : Quest
	{
		[field: Inject(false)]
		[field: InjectScope(EGetScope.Parent)]
		protected Level01QuestChain QuestChain { get; private set; }

		protected Worker FirstWorker => QuestChain.FirstWorker;

		protected Customer PreviousInhabitant => QuestChain.PreviousInhabitant;

		protected void BarkFirstWorker(string text, float duration = 3f)
		{
			QuestChain.BarkFirstWorker(text, duration);
		}

		protected void BarkPreviousInhabitant(string text, float duration = 3f)
		{
			QuestChain.BarkPreviousInhabitant(text, duration);
		}
	}
}
