using System.Collections.Generic;
using Coherence.SimulationFrame;

namespace Coherence.Entities
{
	public interface ICoherenceComponentData
	{
		uint FieldsMask { get; set; }

		uint StoppedMask { get; set; }

		uint GetComponentType();

		int PriorityLevel();

		AbsoluteSimulationFrame? GetMinSimulationFrame();

		ICoherenceComponentData MergeWith(ICoherenceComponentData data);

		uint DiffWith(ICoherenceComponentData data);

		int GetComponentOrder();

		bool IsSendOrdered();

		uint InitialFieldsMask();

		bool HasFields();

		bool HasRefFields();

		HashSet<Entity> GetEntityRefs();

		IEntityMapper.Error MapToAbsolute(IEntityMapper mapper);

		IEntityMapper.Error MapToRelative(IEntityMapper mapper);

		ICoherenceComponentData Clone();

		int GetFieldCount();

		long[] GetSimulationFrames();

		void ResetFrame(AbsoluteSimulationFrame frame);

		uint ReplaceReferences(Entity fromEntity, Entity toEntity);
	}
}
