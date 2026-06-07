using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Page : UserControl
	{
		public string Title
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal new static Page CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Page(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Page obj)
		{
			return default(HandleRef);
		}

		public Page()
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
