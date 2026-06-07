using System;
using Coherence.Core;
using Coherence.Entities;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public class DataInteropHandler : IDataInteropHandler
	{
		public unsafe ICoherenceComponentData GetComponent(uint type, IntPtr data, int dataSize, InteropAbsoluteSimulationFrame* simFrames, int simFramesCount)
		{
			return null;
		}

		public void UpdateComponent(INativeCoreComponentUpdater updater, InteropEntity entity, ICoherenceComponentData component)
		{
		}

		public IEntityCommand GetCommand(uint type, IntPtr data, int dataSize)
		{
			return null;
		}

		public IEntityInput GetInput(uint type, IntPtr data, int dataSize)
		{
			return null;
		}

		public bool SendCommand(INativeCoreCommandSender sender, InteropEntity entity, MessageTarget target, IEntityCommand command)
		{
			return false;
		}

		public void SendInput(INativeCoreInputSender sender, InteropEntity entity, long frame, IEntityInput input)
		{
		}
	}
}
