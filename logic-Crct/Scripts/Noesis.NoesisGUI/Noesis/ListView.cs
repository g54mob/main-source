using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ListView : ListBox
	{
		public static DependencyProperty ViewProperty => null;

		public new ViewBase View
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static ListView CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ListView(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ListView obj)
		{
			return default(HandleRef);
		}

		public ListView()
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
