using System.Collections.Generic;
using Coherence.Entities;
using Coherence.Serializer;

namespace Coherence.Core.Channels
{
	internal class ChannelSerializationResult
	{
		public class ReadOnlyAccess
		{
			private readonly ChannelSerializationResult channelSerializationResult;

			public IReadOnlyList<Entity> ExistenceChangesSent => null;

			public IReadOnlyList<Entity> InternalEntitiesSent => null;

			public IReadOnlyList<Entity> AuthorityChangesSent => null;

			public IReadOnlyList<Entity> UpdateChangesSent => null;

			public IReadOnlyList<SerializedEntityMessage> CommandsSent => null;

			public IReadOnlyList<SerializedEntityMessage> InputsSent => null;

			public ReadOnlyAccess(ChannelSerializationResult channelSerializationResult)
			{
			}
		}

		public readonly List<Entity> ExistenceChangesSent;

		public readonly List<Entity> InternalEntitiesSent;

		public readonly List<Entity> AuthorityChangesSent;

		public readonly List<Entity> UpdateChangesSent;

		public readonly List<SerializedEntityMessage> CommandsSent;

		public readonly List<SerializedEntityMessage> InputsSent;

		public readonly List<Entity> Null;

		public readonly ReadOnlyAccess ReadOnly;

		public bool IsEmpty()
		{
			return false;
		}

		public void Clear()
		{
		}
	}
}
