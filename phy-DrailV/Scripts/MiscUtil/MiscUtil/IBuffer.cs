using System;

namespace MiscUtil
{
	public interface IBuffer : IDisposable
	{
		byte[] Bytes { get; }
	}
}
