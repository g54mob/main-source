using System;

namespace Coherence.Plugins.Utils
{
	internal class CStringArray : IDisposable
	{
		private IntPtr array;

		private IntPtr[] items;

		public IntPtr Ptr => (IntPtr)0;

		public int Length => 0;

		public CStringArray(string[] source)
		{
		}

		public void Dispose()
		{
		}

		private void AllocGlobalHeap(string[] source)
		{
		}
	}
}
