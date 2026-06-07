using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class VisualCollection : UICollection<Visual>
	{
		internal new static VisualCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal VisualCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(VisualCollection obj)
		{
			return default(HandleRef);
		}

		protected VisualCollection()
		{
		}

		public VisualCollection(Visual parent)
		{
		}

		private static Visual CheckParent(Visual parent)
		{
			return null;
		}

		private static IntPtr Create(Visual parent)
		{
			return (IntPtr)0;
		}
	}
}
