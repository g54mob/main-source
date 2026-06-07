using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class TransformCollection : FreezableCollection<Transform>
	{
		internal new static TransformCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal TransformCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(TransformCollection obj)
		{
			return default(HandleRef);
		}

		public TransformCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
