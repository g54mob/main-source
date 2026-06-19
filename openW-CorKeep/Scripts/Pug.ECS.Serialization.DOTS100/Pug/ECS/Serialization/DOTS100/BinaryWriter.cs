using System;

namespace Pug.ECS.Serialization.DOTS100
{
	public interface BinaryWriter : IDisposable
	{
		long Position { get; set; }

		unsafe void WriteBytes(void* data, int bytes);
	}
}
