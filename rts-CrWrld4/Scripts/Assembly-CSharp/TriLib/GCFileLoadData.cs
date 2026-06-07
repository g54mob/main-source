using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace TriLib
{
	public class GCFileLoadData : FileLoadData
	{
		private readonly List<GCHandle> _lockedBuffers;

		public override void Dispose()
		{
		}

		public override void AddBuffer(GCHandle bufferHandle)
		{
		}
	}
}
