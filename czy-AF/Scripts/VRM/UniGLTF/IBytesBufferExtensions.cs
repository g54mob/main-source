using System;

namespace UniGLTF
{
	public static class IBytesBufferExtensions
	{
		public static glTFBufferView Extend<T>(this IBytesBuffer buffer, T[] array, glBufferTarget target) where T : struct
		{
			return buffer.Extend(new ArraySegment<T>(array), target);
		}
	}
}
