using System;
using Unity.Entities;

namespace PlayerEquipment
{
	[InternalBufferCapacity(10)]
	public struct PlayerPreviouslyHitEnemiesBuffer : IBufferElementData, IEquatable<Entity>
	{
		public Entity Entity;

		public static implicit operator PlayerPreviouslyHitEnemiesBuffer(Entity a)
		{
			return new PlayerPreviouslyHitEnemiesBuffer
			{
				Entity = a
			};
		}

		public static implicit operator Entity(PlayerPreviouslyHitEnemiesBuffer a)
		{
			return a.Entity;
		}

		public bool Equals(PlayerPreviouslyHitEnemiesBuffer other)
		{
			return Entity.Equals(other.Entity);
		}

		public bool Equals(Entity other)
		{
			return Entity == other;
		}

		public override bool Equals(object obj)
		{
			if (obj is PlayerPreviouslyHitEnemiesBuffer other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Entity.GetHashCode();
		}
	}
}
