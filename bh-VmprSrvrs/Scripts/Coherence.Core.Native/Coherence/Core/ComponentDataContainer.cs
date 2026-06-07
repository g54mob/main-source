using System;

namespace Coherence.Core
{
	public struct ComponentDataContainer
	{
		public uint ComponentID;

		public uint FieldMask;

		public uint StoppedMask;

		public IntPtr Data;

		public int DataSize;

		public unsafe InteropAbsoluteSimulationFrame* SimFrames;

		public int SimFrameCount;
	}
}
