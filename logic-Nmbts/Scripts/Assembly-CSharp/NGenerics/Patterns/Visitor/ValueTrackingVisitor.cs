using System.Collections.Generic;

namespace NGenerics.Patterns.Visitor
{
	public sealed class ValueTrackingVisitor<TKey, TValue> : IVisitor<KeyValuePair<TKey, TValue>>
	{
		private readonly List<TValue> tracks;

		public IList<TValue> TrackingList
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

		public ValueTrackingVisitor()
		{
			tracks = new List<TValue>();
		}

		public void Visit(KeyValuePair<TKey, TValue> obj)
		{
			tracks.Add(obj.Value);
		}
	}
}
