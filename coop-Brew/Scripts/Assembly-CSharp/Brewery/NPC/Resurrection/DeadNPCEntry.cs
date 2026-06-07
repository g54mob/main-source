using System;
using Unity.Collections;
using Unity.Netcode;

namespace Brewery.NPC.Resurrection
{
	[Serializable]
	public struct DeadNPCEntry : INetworkSerializable, IEquatable<DeadNPCEntry>
	{
		public FixedString64Bytes NpcId;

		public int GraveIndex;

		public FixedString64Bytes DisplayName;

		public DeadNPCEntry(string npcId, int graveIndex, string displayName)
		{
			NpcId = default(FixedString64Bytes);
			GraveIndex = 0;
			DisplayName = default(FixedString64Bytes);
		}

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		public bool Equals(DeadNPCEntry other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(DeadNPCEntry left, DeadNPCEntry right)
		{
			return false;
		}

		public static bool operator !=(DeadNPCEntry left, DeadNPCEntry right)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
