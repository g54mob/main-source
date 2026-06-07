using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class GroupBox : HeaderedContentControl
	{
		internal new static GroupBox CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal GroupBox(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(GroupBox obj)
		{
			return default(HandleRef);
		}

		public GroupBox()
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
