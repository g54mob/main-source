using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace TriLib
{
	public class GCFileLoadData : FileLoadData
	{
		private readonly List<GCHandle> _lockedBuffers = new List<GCHandle>();

		public override void Dispose()
		{
			foreach (GCHandle lockedBuffer in _lockedBuffers)
			{
				lockedBuffer.Free();
			}
		}

		public override void AddBuffer(GCHandle bufferHandle)
		{
			_lockedBuffers.Add(bufferHandle);
		}
	}
}
