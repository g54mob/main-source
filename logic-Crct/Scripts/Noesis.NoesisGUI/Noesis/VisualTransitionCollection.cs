using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class VisualTransitionCollection : UICollection<VisualTransition>
	{
		internal new static VisualTransitionCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal VisualTransitionCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(VisualTransitionCollection obj)
		{
			return default(HandleRef);
		}

		public VisualTransitionCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
