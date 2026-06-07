using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class MatrixKeyFrameCollection : FreezableCollection<MatrixKeyFrame>
	{
		internal new static MatrixKeyFrameCollection CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal MatrixKeyFrameCollection(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(MatrixKeyFrameCollection obj)
		{
			return default(HandleRef);
		}

		public MatrixKeyFrameCollection()
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}
	}
}
