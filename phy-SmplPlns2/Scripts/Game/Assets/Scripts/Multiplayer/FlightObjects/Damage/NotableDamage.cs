using Assets.Scripts.Flight.Damage;
using Assets.Scripts.Multiplayer.Extensions;
using FishNet.Serializing;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.FlightObjects.Damage
{
	public struct NotableDamage
	{
		public short Damage { get; }

		public Vector3? Normal { get; }

		public float PhysicsTime { get; }

		public int? PlayerId { get; }

		public Vector3? Position { get; }

		public DamageType Type { get; }

		public NotableDamage(short damage, DamageType type, int? playerId, Vector3? position, Vector3? normal, float physicsTime)
		{
			Damage = damage;
			Type = type;
			PlayerId = playerId;
			Position = position;
			Normal = normal;
			PhysicsTime = physicsTime;
		}

		public static NotableDamage Read(PooledReader reader)
		{
			return new NotableDamage(reader.ReadInt16(), reader.ReadEnum<DamageType>(), reader.ReadNullableInt32(), reader.ReadNullableVector3(), reader.ReadNullableVector3(), reader.ReadSingle());
		}

		public void Write(PooledWriter writer)
		{
			writer.WriteInt16(Damage);
			writer.WriteEnum(Type);
			writer.WriteNullableInt32(PlayerId);
			writer.WriteNullableVector3(Position);
			writer.WriteNullableVector3(Normal);
			writer.WriteSingle(PhysicsTime);
		}
	}
}
