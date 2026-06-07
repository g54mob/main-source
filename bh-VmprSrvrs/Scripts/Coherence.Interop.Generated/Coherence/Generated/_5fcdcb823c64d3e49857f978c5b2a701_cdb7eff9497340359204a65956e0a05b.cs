using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _5fcdcb823c64d3e49857f978c5b2a701_cdb7eff9497340359204a65956e0a05b : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public byte eraseItems;

			[FieldOffset(1)]
			public byte skipTriggers;
		}

		public bool eraseItems;

		public bool skipTriggers;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _5fcdcb823c64d3e49857f978c5b2a701_cdb7eff9497340359204a65956e0a05b FromInterop(IntPtr data, int dataSize)
		{
			return default(_5fcdcb823c64d3e49857f978c5b2a701_cdb7eff9497340359204a65956e0a05b);
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

		public _5fcdcb823c64d3e49857f978c5b2a701_cdb7eff9497340359204a65956e0a05b(Entity entity, bool eraseItems, bool skipTriggers)
		{
			this.eraseItems = false;
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_5fcdcb823c64d3e49857f978c5b2a701_cdb7eff9497340359204a65956e0a05b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _5fcdcb823c64d3e49857f978c5b2a701_cdb7eff9497340359204a65956e0a05b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_5fcdcb823c64d3e49857f978c5b2a701_cdb7eff9497340359204a65956e0a05b);
		}
	}
}
