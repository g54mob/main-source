using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class GradientStopCollection : FreezableCollection<GradientStop>
	{
		internal new static GradientStopCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal GradientStopCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(GradientStopCollection obj)
		{
			return default(HandleRef);
		}

		public GradientStopCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
