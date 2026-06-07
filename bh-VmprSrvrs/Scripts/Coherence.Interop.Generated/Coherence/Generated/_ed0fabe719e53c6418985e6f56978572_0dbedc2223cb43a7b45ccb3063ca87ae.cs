using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ed0fabe719e53c6418985e6f56978572_0dbedc2223cb43a7b45ccb3063ca87ae : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingClientFrame;
		}

		public long startingClientFrame;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _ed0fabe719e53c6418985e6f56978572_0dbedc2223cb43a7b45ccb3063ca87ae FromInterop(IntPtr data, int dataSize)
		{
			return default(_ed0fabe719e53c6418985e6f56978572_0dbedc2223cb43a7b45ccb3063ca87ae);
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

		public _ed0fabe719e53c6418985e6f56978572_0dbedc2223cb43a7b45ccb3063ca87ae(Entity entity, long startingClientFrame)
		{
			this.startingClientFrame = 0L;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_ed0fabe719e53c6418985e6f56978572_0dbedc2223cb43a7b45ccb3063ca87ae commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ed0fabe719e53c6418985e6f56978572_0dbedc2223cb43a7b45ccb3063ca87ae Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ed0fabe719e53c6418985e6f56978572_0dbedc2223cb43a7b45ccb3063ca87ae);
		}
	}
}
