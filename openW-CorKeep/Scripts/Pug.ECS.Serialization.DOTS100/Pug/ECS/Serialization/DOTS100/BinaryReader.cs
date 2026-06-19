using System;

namespace Pug.ECS.Serialization.DOTS100
{
	public interface BinaryReader : IDisposable
	{
		long Position { get; set; }

		unsafe void ReadBytes(void* data, int bytes);
	}
}
