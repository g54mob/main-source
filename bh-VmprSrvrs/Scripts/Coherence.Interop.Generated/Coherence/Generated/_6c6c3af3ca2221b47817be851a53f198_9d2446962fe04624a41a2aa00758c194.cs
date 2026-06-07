using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _6c6c3af3ca2221b47817be851a53f198_9d2446962fe04624a41a2aa00758c194 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _6c6c3af3ca2221b47817be851a53f198_9d2446962fe04624a41a2aa00758c194 FromInterop(IntPtr data, int dataSize)
		{
			return default(_6c6c3af3ca2221b47817be851a53f198_9d2446962fe04624a41a2aa00758c194);
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

		public _6c6c3af3ca2221b47817be851a53f198_9d2446962fe04624a41a2aa00758c194(Entity entity, bool eraseItems, bool skipTriggers)
		{
			this.eraseItems = false;
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_6c6c3af3ca2221b47817be851a53f198_9d2446962fe04624a41a2aa00758c194 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _6c6c3af3ca2221b47817be851a53f198_9d2446962fe04624a41a2aa00758c194 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_6c6c3af3ca2221b47817be851a53f198_9d2446962fe04624a41a2aa00758c194);
		}
	}
}
