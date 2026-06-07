using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Expression : BaseComponent
	{
		internal new static Expression CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Expression(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Expression obj)
		{
			return default(HandleRef);
		}

		public Expression()
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
