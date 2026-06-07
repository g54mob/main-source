namespace Coherence.Entities
{
	public ref struct EntityRemoveChange
	{
		public Entity ID;

		public uint[] Remove;

		public long Priority;
	}
}
