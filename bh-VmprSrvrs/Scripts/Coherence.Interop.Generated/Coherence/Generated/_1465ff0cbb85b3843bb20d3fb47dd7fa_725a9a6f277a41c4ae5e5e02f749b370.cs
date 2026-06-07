using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _1465ff0cbb85b3843bb20d3fb47dd7fa_725a9a6f277a41c4ae5e5e02f749b370 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _1465ff0cbb85b3843bb20d3fb47dd7fa_725a9a6f277a41c4ae5e5e02f749b370 FromInterop(IntPtr data, int dataSize)
		{
			return default(_1465ff0cbb85b3843bb20d3fb47dd7fa_725a9a6f277a41c4ae5e5e02f749b370);
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

		public _1465ff0cbb85b3843bb20d3fb47dd7fa_725a9a6f277a41c4ae5e5e02f749b370(Entity entity, bool eraseItems, bool skipTriggers)
		{
			this.eraseItems = false;
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_1465ff0cbb85b3843bb20d3fb47dd7fa_725a9a6f277a41c4ae5e5e02f749b370 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _1465ff0cbb85b3843bb20d3fb47dd7fa_725a9a6f277a41c4ae5e5e02f749b370 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_1465ff0cbb85b3843bb20d3fb47dd7fa_725a9a6f277a41c4ae5e5e02f749b370);
		}
	}
}
