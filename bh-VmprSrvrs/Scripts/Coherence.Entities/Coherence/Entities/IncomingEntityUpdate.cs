namespace Coherence.Entities
{
	public struct IncomingEntityUpdate
	{
		public EntityWithMeta Meta;

		public DeltaComponents Components;

		public Entity Entity => default(Entity);

		public bool IsCreate => false;

		public bool IsDestroy => false;

		public static IncomingEntityUpdate New(int capacity = 0)
		{
			return default(IncomingEntityUpdate);
		}

		public void Merge(in IncomingEntityUpdate other)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
