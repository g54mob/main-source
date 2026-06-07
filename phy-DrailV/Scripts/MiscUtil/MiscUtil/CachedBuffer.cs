using System;

namespace MiscUtil
{
	internal class CachedBuffer : IBuffer, IDisposable
	{
		private readonly byte[] data;

		private volatile bool available;

		private readonly bool clearOnDispose;

		internal bool Available
		{
			get
			{
				return available;
			}
			set
			{
				available = value;
			}
		}

		public byte[] Bytes => data;

		internal CachedBuffer(int size, bool clearOnDispose)
		{
			data = new byte[size];
			this.clearOnDispose = clearOnDispose;
		}

		public void Dispose()
		{
			if (clearOnDispose)
			{
				Array.Clear(data, 0, data.Length);
			}
			available = true;
		}
	}
}
