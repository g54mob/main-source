using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class Ellipse : Shape
	{
		internal new static Ellipse CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal Ellipse(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(Ellipse obj)
		{
			return default(HandleRef);
		}

		public Ellipse()
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
