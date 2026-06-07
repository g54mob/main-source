using System.Collections.Generic;

namespace NGenerics.Patterns.Visitor
{
	public sealed class TrackingVisitor<T> : IVisitor<T>
	{
		private readonly List<T> tracks;

		public bool HasCompleted
		{
			get
			{
				return false;
			}
		}

		public IList<T> TrackingList
		{
			get
			{
				return tracks;
			}
		}

		public TrackingVisitor()
		{
			tracks = new List<T>();
		}

		public void Visit(T obj)
		{
			tracks.Add(obj);
		}
	}
}
