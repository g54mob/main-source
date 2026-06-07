using System.Collections.Generic;
using Coherence.Common;
using Coherence.Entities;
using Coherence.ProtocolDef;

namespace Coherence
{
	public static class ComponentUpdatesExtensions
	{
		public static ICoherenceComponentData[] Components(this ComponentUpdates componentUpdates)
		{
			return null;
		}

		public static uint[] GetComponentTypes(this ICoherenceComponentData[] comps)
		{
			return null;
		}

		public static ICoherenceComponentData Get(this ICoherenceComponentData[] comps, uint componentType)
		{
			return null;
		}

		public static (ICoherenceComponentData, int) GetWithIndex(this ICoherenceComponentData[] comps, uint componentType)
		{
			return default((ICoherenceComponentData, int));
		}

		public static ICoherenceComponentData[] Set(this ICoherenceComponentData[] comps, ICoherenceComponentData comp)
		{
			return null;
		}

		public static ICoherenceComponentData[] Update(this ICoherenceComponentData[] comps, ICoherenceComponentData[] updatedComps)
		{
			return null;
		}

		public static ICoherenceComponentData[] Remove(this ICoherenceComponentData[] comps, IReadOnlyList<uint> compTypes)
		{
			return null;
		}

		public static ICoherenceComponentData[] CloneAll(this ICoherenceComponentData[] comps)
		{
			return null;
		}

		public static bool HasSendOrderedComponent(this ICoherenceComponentData[] comps, IComponentInfo root)
		{
			return false;
		}

		public static ICoherenceComponentData[] RemoveSceneComponents(this ICoherenceComponentData[] comps, IExtendedDefinition root)
		{
			return null;
		}

		public static void ApplyPositionToWorldPositionComponent(this ICoherenceComponentData[] comps, Vector3d newPos, IExtendedDefinition root)
		{
		}

		public static HashSet<Entity> GetEntityDataRefFields(this ICoherenceComponentData[] comps)
		{
			return null;
		}

		public static IEntityMapper.Error MapToAbsolute(this ICoherenceComponentData[] comps, IEntityMapper mapper)
		{
			return default(IEntityMapper.Error);
		}

		public static IEntityMapper.Error MapToRelative(this ICoherenceComponentData[] comps, IEntityMapper mapper)
		{
			return default(IEntityMapper.Error);
		}

		public static void UpdateData(this ref DeltaComponents d, ICoherenceComponentData[] comps, IExtendedDefinition root, EntityArchetypeLOD archetypeLOD)
		{
		}
	}
}
