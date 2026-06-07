using System;

namespace Crosstales.NAudio.Wave.Asio
{
	internal delegate void ASIOFillBufferCallback(IntPtr[] inputChannels, IntPtr[] outputChannels);
}
