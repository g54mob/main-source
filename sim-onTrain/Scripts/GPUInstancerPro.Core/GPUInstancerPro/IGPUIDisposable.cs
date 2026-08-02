using System;

namespace GPUInstancerPro
{
	public interface IGPUIDisposable : IDisposable
	{
		void ReleaseBuffers();
	}
}
