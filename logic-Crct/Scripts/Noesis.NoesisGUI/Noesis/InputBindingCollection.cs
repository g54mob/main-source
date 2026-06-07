using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class InputBindingCollection : UICollection<InputBinding>
	{
		internal new static InputBindingCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal InputBindingCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(InputBindingCollection obj)
		{
			return default(HandleRef);
		}

		public InputBindingCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
