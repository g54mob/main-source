using Coherence.Brook;
using Coherence.Entities;
using Coherence.Log;
using Coherence.SimulationFrame;

namespace Coherence.ProtocolDef
{
	public interface ISchemaSpecificComponentDeserialize
	{
		ICoherenceComponentData ReadComponentUpdate(uint componentType, AbsoluteSimulationFrame referenceSimulationFrame, IInBitStream bitStreamm, Logger logger);

		IEntityCommand[] ReadCommands(IInBitStream bitStream, Logger logger);

		IEntityInput[] ReadInputs(IInBitStream bitStream, Logger logger);

		IEntityCommand ReadCommand(IInBitStream bitStream, Logger logger);
	}
}
