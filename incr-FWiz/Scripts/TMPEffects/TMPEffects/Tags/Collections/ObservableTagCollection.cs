using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

namespace TMPEffects.Tags.Collections
{
	public class ObservableTagCollection : TagCollection, INotifyCollectionChanged
	{
		public event NotifyCollectionChangedEventHandler CollectionChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public ObservableTagCollection(IList<TMPEffectTagTuple> tags, ITMPTagValidator validator = null)
			: base(null, null)
		{
		}

		public ObservableTagCollection(ITMPTagValidator validator = null)
			: base(null, null)
		{
		}

		protected void InvokeEvent(NotifyCollectionChangedEventArgs e)
		{
		}

		public override bool TryAdd(TMPEffectTag tag, TMPEffectTagIndices indices)
		{
			return false;
		}

		public override bool TryAdd(TMPEffectTag tag, int startIndex = 0, int endIndex = -1, int? orderAtIndex = null)
		{
			return false;
		}

		public override bool Remove(TMPEffectTag tag, TMPEffectTagIndices? indices = null)
		{
			return false;
		}

		public override bool RemoveAt(int startIndex, int? order = null)
		{
			return false;
		}

		public override int RemoveAllAt(int startIndex, TMPEffectTagTuple[] buffer = null, int bufferIndex = 0)
		{
			return 0;
		}

		public override void Clear()
		{
		}
	}
}
