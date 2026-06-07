using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct QuerySynced : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public byte liveQuerySynced;

			[FieldOffset(1)]
			public byte globalQuerySynced;
		}

		public bool liveQuerySynced;

		public bool globalQuerySynced;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static QuerySynced FromInterop(IntPtr data, int dataSize)
		{
			return default(QuerySynced);
		}

		public uint GetComponentType()
		{
			return 0u;
		}

		public IEntityMessage Clone()
		{
			return null;
		}

		public IEntityMapper.Error MapToAbsolute(IEntityMapper mapper, Logger logger)
		{
			return default(IEntityMapper.Error);
		}

		public IEntityMapper.Error MapToRelative(IEntityMapper mapper, Logger logger)
		{
			return default(IEntityMapper.Error);
		}

		public HashSet<Entity> GetEntityRefs()
		{
			return null;
		}

		public void NullEntityRefs(Entity entity)
		{
		}

		public QuerySynced(Entity entity, bool liveQuerySynced, bool globalQuerySynced)
		{
			this.liveQuerySynced = false;
			this.globalQuerySynced = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(QuerySynced commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static QuerySynced Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(QuerySynced);
		}
	}
}
