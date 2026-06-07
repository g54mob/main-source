namespace Coherence.Entities
{
	public ref struct EntityUpdateChange
	{
		public Entity ID;

		public ComponentUpdates Data;

		public long Priority;
	}
}
