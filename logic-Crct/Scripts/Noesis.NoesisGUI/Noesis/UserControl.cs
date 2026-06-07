using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class UserControl : ContentControl
	{
		internal new static UserControl CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal UserControl(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(UserControl obj)
		{
			return default(HandleRef);
		}

		public UserControl()
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
