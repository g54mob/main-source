using System;

namespace CTS.BBT.AI
{
	[Serializable]
	internal class ContextualActionSuckBloodKill : ContextualActionSuckBlood
	{
		public override void Setup()
		{
			action = new AgentActionSuckBlood(contextActor);
		}
	}
}
