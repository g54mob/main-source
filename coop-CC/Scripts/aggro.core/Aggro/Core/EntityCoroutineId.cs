using System;

namespace Aggro.Core
{
	public struct EntityCoroutineId : IEquatable<EntityCoroutineId>
	{
		internal readonly int managerId;

		internal readonly int coroutineId;

		public bool isValid => managerId > 0;

		public static EntityCoroutineId invalid => default(EntityCoroutineId);

		internal EntityCoroutineId(int managerId, int coroutineId)
		{
			this.managerId = managerId;
			this.coroutineId = coroutineId;
		}

		public bool Equals(EntityCoroutineId other)
		{
			if (managerId == other.managerId)
			{
				return coroutineId == other.coroutineId;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is EntityCoroutineId other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(managerId, coroutineId);
		}

		public override string ToString()
		{
			return $"ManagerId: {managerId} CoroutineId: {coroutineId}";
		}
	}
}
