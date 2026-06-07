using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Expander : HeaderedContentControl
	{
		public static DependencyProperty ExpandDirectionProperty => null;

		public static DependencyProperty IsExpandedProperty => null;

		public static RoutedEvent CollapsedEvent => null;

		public static RoutedEvent ExpandedEvent => null;

		public ExpandDirection ExpandDirection
		{
			get
			{
				return default(ExpandDirection);
			}
			set
			{
			}
		}

		public bool IsExpanded
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public event RoutedEventHandler Collapsed
		{
			add
			{
			}
			remove
			{
			}
		}

		public event RoutedEventHandler Expanded
		{
			add
			{
			}
			remove
			{
			}
		}

		internal new static Expander CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Expander(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Expander obj)
		{
			return default(HandleRef);
		}

		public Expander()
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
