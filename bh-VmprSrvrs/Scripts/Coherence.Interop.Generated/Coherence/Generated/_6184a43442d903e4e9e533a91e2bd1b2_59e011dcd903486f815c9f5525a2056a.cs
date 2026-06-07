using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _6184a43442d903e4e9e533a91e2bd1b2_59e011dcd903486f815c9f5525a2056a : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _6184a43442d903e4e9e533a91e2bd1b2_59e011dcd903486f815c9f5525a2056a FromInterop(IntPtr data, int dataSize)
		{
			return default(_6184a43442d903e4e9e533a91e2bd1b2_59e011dcd903486f815c9f5525a2056a);
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

		public _6184a43442d903e4e9e533a91e2bd1b2_59e011dcd903486f815c9f5525a2056a(Entity entity, bool eraseItems, bool skipTriggers)
		{
			this.eraseItems = false;
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_6184a43442d903e4e9e533a91e2bd1b2_59e011dcd903486f815c9f5525a2056a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _6184a43442d903e4e9e533a91e2bd1b2_59e011dcd903486f815c9f5525a2056a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_6184a43442d903e4e9e533a91e2bd1b2_59e011dcd903486f815c9f5525a2056a);
		}
	}
}
