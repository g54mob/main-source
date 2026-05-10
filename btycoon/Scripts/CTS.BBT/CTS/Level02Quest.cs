using CTS.Core;

namespace CTS
{
	public abstract class Level02Quest : Quest
	{
		[field: Inject(false)]
		[field: InjectScope(EGetScope.Parent)]
		protected Level02QuestChain QuestChain { get; private set; }
	}
}
