using Coherence.Entities;

namespace Coherence.Core
{
	public struct InteropEntity
	{
		public ushort Index;

		public byte Version;

		public EntityIDType Type;

		public override string ToString()
		{
			return null;
		}

		public InteropEntity(Entity entity)
		{
			Index = 0;
			Version = 0;
			Type = default(EntityIDType);
		}

		public Entity Into()
		{
			return default(Entity);
		}
	}
}
