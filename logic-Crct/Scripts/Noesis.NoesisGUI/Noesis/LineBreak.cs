using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class LineBreak : Inline
	{
		internal new static LineBreak CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal LineBreak(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(LineBreak obj)
		{
			return default(HandleRef);
		}

		public LineBreak()
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
