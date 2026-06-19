using BehaviorDesigner.Runtime;

namespace TH20
{
	public abstract class MetagameCutsceneDefinition
	{
		public ExternalBehavior CutsceneBehaviour;

		public int Priority = 10;

		public abstract MetagameCutsceneInstance CreateCutsceneInstance(MetagameMap map);
	}
}
