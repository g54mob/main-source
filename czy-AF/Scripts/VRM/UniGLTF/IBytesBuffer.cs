using System;

namespace UniGLTF
{
	public interface IBytesBuffer
	{
		string Uri { get; }

		ArraySegment<byte> GetBytes();

		glTFBufferView Extend<T>(ArraySegment<T> array, glBufferTarget target) where T : struct;
	}
}
