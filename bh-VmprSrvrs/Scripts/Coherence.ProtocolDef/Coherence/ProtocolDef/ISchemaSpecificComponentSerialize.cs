using Coherence.Entities;
using Coherence.Log;
using Coherence.SimulationFrame;

namespace Coherence.ProtocolDef
{
	public interface ISchemaSpecificComponentSerialize
	{
		uint WriteComponentUpdate(ICoherenceComponentData data, uint serializeAs, bool isRefSimFrameValid, AbsoluteSimulationFrame referenceSimulationFrame, IOutProtocolBitStream protocolStream, Logger logger);

		void WriteCommand(IEntityCommand data, uint commandType, IOutProtocolBitStream bitStream, Logger logger);

		void WriteInput(IEntityInput data, uint inputType, IOutProtocolBitStream bitStream, Logger logger);
	}
}
