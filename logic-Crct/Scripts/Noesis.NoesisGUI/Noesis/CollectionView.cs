using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class CollectionView : BaseComponent, IEnumerable
	{
		public struct Enumerator : IEnumerator
		{
			private CollectionView _collectionView;

			private int _index;

			object IEnumerator.Current => null;

			public object Current => null;

			public bool MoveNext()
			{
				return false;
			}

			public void Reset()
			{
			}

			public Enumerator(CollectionView c)
			{
				_collectionView = null;
				_index = 0;
			}
		}

		public IEnumerable SourceCollection => null;

		public int Count => 0;

		public bool CanFilter => false;

		public bool CanGroup => false;

		public bool CanSort => false;

		public object CurrentItem => null;

		public int CurrentPosition => 0;

		public bool IsCurrentAfterLast => false;

		public bool IsCurrentBeforeFirst => false;

		public bool IsEmpty => false;

		internal new static CollectionView CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal CollectionView(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(CollectionView obj)
		{
			return default(HandleRef);
		}

		protected CollectionView()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public CollectionView(IEnumerable collection)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		public object GetItemAt(int index)
		{
			return null;
		}

		public Enumerator GetEnumerator()
		{
			return default(Enumerator);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public int IndexOf(object item)
		{
			return 0;
		}

		public bool Contains(object item)
		{
			return false;
		}

		public bool MoveCurrentTo(object item)
		{
			return false;
		}

		public bool MoveCurrentToFirst()
		{
			return false;
		}

		public bool MoveCurrentToLast()
		{
			return false;
		}

		public bool MoveCurrentToNext()
		{
			return false;
		}

		public bool MoveCurrentToPosition(int position)
		{
			return false;
		}

		public bool MoveCurrentToPrevious()
		{
			return false;
		}

		public void Refresh()
		{
		}

		private IntPtr GetItemAtHelper(int index)
		{
			return (IntPtr)0;
		}

		private static IntPtr CreateCollectionView(object collection)
		{
			return (IntPtr)0;
		}

		private object GetSourceCollectionHelper()
		{
			return null;
		}
	}
}
