using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class StringKeyFrameCollection : FreezableCollection<StringKeyFrame>
	{
		internal new static StringKeyFrameCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal StringKeyFrameCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(StringKeyFrameCollection obj)
		{
			return default(HandleRef);
		}

		public StringKeyFrameCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
