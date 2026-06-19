using TMPEffects.TMPCommands;
using TMPEffects.Tags;

namespace TMPEffects.Components.Writer
{
	internal class CachedCommand : ITagWrapper, ICachedInvokable
	{
		public TMPEffectTag Tag { get; private set; }

		public TMPEffectTagIndices Indices { get; private set; }

		public ITMPCommand command { get; private set; }

		public TMPCommandArgs args { get; private set; }

		public bool Triggered { get; private set; }

		public ReadOnlyCommandContext roContext { get; private set; }

		public bool ExecuteInstantly => false;

		public bool ExecuteOnSkip => false;

		public bool ExecuteRepeatable => false;

		public void Trigger()
		{
		}

		public void Reset()
		{
		}

		public CachedCommand(TMPEffectTag tag, TMPEffectTagIndices indices, CommandContext context, ITMPCommand command)
		{
		}

		public void Reset(TMPEffectTag tag, TMPEffectTagIndices indices, CommandContext context, ITMPCommand command)
		{
		}
	}
}
