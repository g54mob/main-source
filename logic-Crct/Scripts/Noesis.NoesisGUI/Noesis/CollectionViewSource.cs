using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class CollectionViewSource : DependencyObject
	{
		public static DependencyProperty CollectionViewTypeProperty => null;

		public static DependencyProperty SourceProperty => null;

		public static DependencyProperty ViewProperty => null;

		public Type CollectionViewType
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public object Source
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public CollectionView View => null;

		internal new static CollectionViewSource CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal CollectionViewSource(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(CollectionViewSource obj)
		{
			return default(HandleRef);
		}

		public CollectionViewSource()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
