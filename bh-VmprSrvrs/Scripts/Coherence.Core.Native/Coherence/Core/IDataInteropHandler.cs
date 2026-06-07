using System;
using Coherence.Entities;
using Coherence.ProtocolDef;

namespace Coherence.Core
{
	public interface IDataInteropHandler
	{
		unsafe ICoherenceComponentData GetComponent(uint type, IntPtr data, int dataSize, InteropAbsoluteSimulationFrame* simFrames, int simFramesCount);

		void UpdateComponent(INativeCoreComponentUpdater updater, InteropEntity entity, ICoherenceComponentData component);

		IEntityCommand GetCommand(uint type, IntPtr data, int dataSize);

		bool SendCommand(INativeCoreCommandSender sender, InteropEntity entity, MessageTarget target, IEntityCommand command);

		IEntityInput GetInput(uint type, IntPtr data, int dataSize);

		void SendInput(INativeCoreInputSender sender, InteropEntity entity, long frame, IEntityInput input);
	}
}
