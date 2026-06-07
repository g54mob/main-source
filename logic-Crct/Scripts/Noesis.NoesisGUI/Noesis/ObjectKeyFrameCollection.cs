using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ObjectKeyFrameCollection : FreezableCollection<ObjectKeyFrame>
	{
		internal new static ObjectKeyFrameCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal ObjectKeyFrameCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(ObjectKeyFrameCollection obj)
		{
			return default(HandleRef);
		}

		public ObjectKeyFrameCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
