using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class TabItem : HeaderedContentControl
	{
		public static DependencyProperty IsSelectedProperty => null;

		public static DependencyProperty TabStripPlacementProperty => null;

		public bool IsSelected
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Dock TabStripPlacement => default(Dock);

		internal new static TabItem CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal TabItem(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(TabItem obj)
		{
			return default(HandleRef);
		}

		public TabItem()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
