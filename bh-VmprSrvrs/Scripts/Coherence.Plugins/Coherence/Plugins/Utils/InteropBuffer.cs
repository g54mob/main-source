using System;
using System.Runtime.InteropServices;

namespace Coherence.Plugins.Utils
{
	internal class InteropBuffer : IDisposable
	{
		private GCHandle handle;

		public byte[] Buffer { get; }

		public IntPtr PinnedPtr => (IntPtr)0;

		public InteropBuffer(int size)
		{
		}

		public InteropBuffer(byte[] buffer)
		{
		}

		public void Dispose()
		{
		}
	}
}
