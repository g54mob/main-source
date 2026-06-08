using System;
using System.Diagnostics;

namespace Castle.Components.DictionaryAdapter
{
	internal sealed class ListProjectionDebugView<T>
	{
		private readonly ListProjection<T> projection;

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public T[] Items
		{
			get
			{
				T[] array = new T[projection.Count];
				projection.CopyTo(array, 0);
				return array;
			}
		}

		public ICollectionAdapter<T> Adapter => projection.Adapter;

		public ListProjectionDebugView(ListProjection<T> projection)
		{
			if (projection == null)
			{
				throw new ArgumentNullException("projection");
			}
			this.projection = projection;
		}
	}
}
