using TMPEffects.TMPEvents;
using TMPEffects.Tags;

namespace TMPEffects.Components.Writer
{
	internal class CachedEvent : ITagWrapper, ICachedInvokable
	{
		private TMPEvent tmpEvent;

		public TMPEffectTag Tag => args.Tag;

		public TMPEffectTagIndices Indices => args.Indices;

		public TMPEventArgs args { get; private set; }

		public bool Triggered { get; private set; }

		public bool ExecuteInstantly => false;

		public bool ExecuteOnSkip => true;

		public bool ExecuteRepeatable => true;

		public bool ExecuteInPreview => true;

		public void Trigger()
		{
			if (!Triggered)
			{
				Triggered = true;
				tmpEvent.Invoke(args);
			}
		}

		public void Reset()
		{
			Triggered = false;
		}

		public CachedEvent(TMPEventArgs args, TMPEvent tmpEvent)
		{
			Reset(args, tmpEvent);
		}

		public void Reset(TMPEventArgs args, TMPEvent tmpEvent)
		{
			this.tmpEvent = tmpEvent;
			this.args = args;
			Triggered = false;
		}
	}
}
