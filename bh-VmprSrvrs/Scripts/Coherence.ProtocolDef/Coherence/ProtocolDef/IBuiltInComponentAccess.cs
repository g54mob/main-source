using Coherence.Entities;
using Coherence.SimulationFrame;

namespace Coherence.ProtocolDef
{
	public interface IBuiltInComponentAccess
	{
		ICoherenceComponentData GenerateCoherenceUUIDData(string UUID, AbsoluteSimulationFrame simFrame);

		ICoherenceComponentData CreateGlobalComponent();

		ICoherenceComponentData GenerateGlobalQueryComponent();

		string ExtractCoherenceUUID(ICoherenceComponentData data);

		string ExtractCoherenceTag(ICoherenceComponentData data);

		bool IsConnectedEntity(ICoherenceComponentData data);

		Entity ExtractConnectedEntityID(ICoherenceComponentData data);

		bool TryGetSceneIndexChangedCommand(IEntityCommand entityCommand, out int sceneIndex);

		IEntityCommand CreateSceneIndexChangedCommand(Entity entity, int sceneIndex);
	}
}
