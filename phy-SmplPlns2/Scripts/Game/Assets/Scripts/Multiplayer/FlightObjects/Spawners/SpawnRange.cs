using System;
using FishNet.Serializing;

namespace Assets.Scripts.Multiplayer.FlightObjects.Spawners
{
	[Serializable]
	public struct SpawnRange
	{
		public uint SpawnDistance;

		public uint DespawnDistance;

		public static SpawnRange Read(PooledReader reader)
		{
			SpawnRange result = default(SpawnRange);
			result.SpawnDistance = reader.ReadUInt32();
			result.DespawnDistance = reader.ReadUInt32();
			return result;
		}

		public void Write(PooledWriter writer)
		{
			writer.WriteUInt32(SpawnDistance);
			writer.WriteUInt32(DespawnDistance);
		}
	}
}
