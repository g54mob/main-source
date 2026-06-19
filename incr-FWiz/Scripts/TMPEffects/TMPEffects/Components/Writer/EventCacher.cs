using TMPEffects.TMPEvents;
using TMPEffects.Tags;

namespace TMPEffects.Components.Writer
{
	internal class EventCacher : ITagCacher<CachedEvent>
	{
		private TMPEvent tmpEvent;

		private TMPWriter writer;

		public EventCacher(TMPWriter writer, TMPEvent tmpEvent)
		{
		}

		public CachedEvent CacheTag(TMPEffectTag tag, TMPEffectTagIndices indices)
		{
			return null;
		}
	}
}
