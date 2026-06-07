using System.Collections.Generic;

namespace Coherence.ProtocolDef
{
	public class EntityArchetypeLOD
	{
		public uint Level;

		public float Distance;

		public Dictionary<uint, uint> ComponentReplacement;

		public uint[] ComponentsExcluded;

		public uint[] RemovedComponentsAtLevel()
		{
			return null;
		}

		public bool IsExcludedComponentType(uint comp)
		{
			return false;
		}

		public bool SpecializedComponentType(uint baseComponentType, out uint mapped)
		{
			mapped = default(uint);
			return false;
		}
	}
}
