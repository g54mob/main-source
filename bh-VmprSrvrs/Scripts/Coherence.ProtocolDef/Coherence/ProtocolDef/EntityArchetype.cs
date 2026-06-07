namespace Coherence.ProtocolDef
{
	public struct EntityArchetype
	{
		public EntityArchetypeLOD[] LODs;

		public bool LODForDistance(double distance, out EntityArchetypeLOD lod)
		{
			lod = null;
			return false;
		}
	}
}
