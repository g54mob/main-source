using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class InputGestureCollection : UICollection<InputGesture>
	{
		internal new static InputGestureCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal InputGestureCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(InputGestureCollection obj)
		{
			return default(HandleRef);
		}

		public InputGestureCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
