using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class TreeView : ItemsControl
	{
		public static DependencyProperty SelectedItemProperty => null;

		public static RoutedEvent SelectedItemChangedEvent => null;

		public object SelectedItem => null;

		public event RoutedPropertyChangedEventHandler<object> SelectedItemChanged
		{
			add
			{
			}
			remove
			{
			}
		}

		internal new static TreeView CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal TreeView(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(TreeView obj)
		{
			return default(HandleRef);
		}

		public TreeView()
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
