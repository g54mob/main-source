using TMPEffects.TMPEvents;
using TMPEffects.Tags;

namespace TMPEffects.Components.Writer
{
	internal class CachedEvent : ITagWrapper, ICachedInvokable
	{
		private TMPEvent tmpEvent;

		public TMPEffectTag Tag => null;

		public TMPEffectTagIndices Indices => default(TMPEffectTagIndices);

		public TMPEventArgs args { get; private set; }

		public bool Triggered { get; private set; }

		public bool ExecuteInstantly => false;

		public bool ExecuteOnSkip => false;

		public bool ExecuteRepeatable => false;

		public bool ExecuteInPreview => false;

		public void Trigger()
		{
		}

		public void Reset()
		{
		}

		public CachedEvent(TMPEventArgs args, TMPEvent tmpEvent)
		{
		}

		public void Reset(TMPEventArgs args, TMPEvent tmpEvent)
		{
		}
	}
}
