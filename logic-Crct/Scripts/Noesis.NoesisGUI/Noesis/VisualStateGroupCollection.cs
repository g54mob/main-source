using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class VisualStateGroupCollection : UICollection<VisualStateGroup>
	{
		internal new static VisualStateGroupCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal VisualStateGroupCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(VisualStateGroupCollection obj)
		{
			return default(HandleRef);
		}

		public VisualStateGroupCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
