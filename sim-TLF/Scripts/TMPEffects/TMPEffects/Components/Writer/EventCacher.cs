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
			this.tmpEvent = tmpEvent;
			this.writer = writer;
		}

		public CachedEvent CacheTag(TMPEffectTag tag, TMPEffectTagIndices indices)
		{
			int endIndex = indices.StartIndex + 1;
			return new CachedEvent(new TMPEventArgs(tag, new TMPEffectTagIndices(indices.StartIndex, endIndex, indices.OrderAtIndex), writer), tmpEvent);
		}
	}
}
