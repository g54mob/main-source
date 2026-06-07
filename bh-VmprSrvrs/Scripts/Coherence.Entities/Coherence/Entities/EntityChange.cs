namespace Coherence.Entities
{
	public struct EntityChange
	{
		public Entity ID;

		public OutgoingEntityUpdate Update;

		public SerializedMeta Meta;
	}
}
