using System.Collections.Generic;

namespace NGenerics.Patterns.Visitor
{
	public sealed class KeyTrackingVisitor<TKey, TValue> : IVisitor<KeyValuePair<TKey, TValue>>
	{
		private readonly List<TKey> tracks;

		public IList<TKey> TrackingList
		{
			get
			{
				return tracks;
			}
		}

		public bool HasCompleted
		{
			get
			{
				return false;
			}
		}

		public KeyTrackingVisitor()
		{
			tracks = new List<TKey>();
		}

		public void Visit(KeyValuePair<TKey, TValue> obj)
		{
			tracks.Add(obj.Key);
		}
	}
}
