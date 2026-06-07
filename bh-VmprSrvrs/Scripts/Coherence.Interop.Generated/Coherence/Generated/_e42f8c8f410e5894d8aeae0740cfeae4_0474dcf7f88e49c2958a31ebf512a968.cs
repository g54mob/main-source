using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _e42f8c8f410e5894d8aeae0740cfeae4_0474dcf7f88e49c2958a31ebf512a968 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _e42f8c8f410e5894d8aeae0740cfeae4_0474dcf7f88e49c2958a31ebf512a968 FromInterop(IntPtr data, int dataSize)
		{
			return default(_e42f8c8f410e5894d8aeae0740cfeae4_0474dcf7f88e49c2958a31ebf512a968);
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

		public _e42f8c8f410e5894d8aeae0740cfeae4_0474dcf7f88e49c2958a31ebf512a968(Entity entity, long startingClientFrame)
		{
			this.startingClientFrame = 0L;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_e42f8c8f410e5894d8aeae0740cfeae4_0474dcf7f88e49c2958a31ebf512a968 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _e42f8c8f410e5894d8aeae0740cfeae4_0474dcf7f88e49c2958a31ebf512a968 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_e42f8c8f410e5894d8aeae0740cfeae4_0474dcf7f88e49c2958a31ebf512a968);
		}
	}
}
