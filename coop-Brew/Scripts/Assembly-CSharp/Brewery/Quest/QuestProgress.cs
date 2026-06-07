using System;
using Unity.Collections;
using Unity.Netcode;

namespace Brewery.Quest
{
	[Serializable]
	public struct QuestProgress : INetworkSerializable, IEquatable<QuestProgress>
	{
		public FixedString64Bytes QuestId;

		public int CurrentStepIndex;

		public bool IsCompleted;

		public FixedString64Bytes GiverNpcId;

		public QuestProgress(string questId, string giverNpcId)
		{
			QuestId = default(FixedString64Bytes);
			CurrentStepIndex = 0;
			IsCompleted = false;
			GiverNpcId = default(FixedString64Bytes);
		}

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		public bool Equals(QuestProgress other)
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

		public static bool operator ==(QuestProgress left, QuestProgress right)
		{
			return false;
		}

		public static bool operator !=(QuestProgress left, QuestProgress right)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
