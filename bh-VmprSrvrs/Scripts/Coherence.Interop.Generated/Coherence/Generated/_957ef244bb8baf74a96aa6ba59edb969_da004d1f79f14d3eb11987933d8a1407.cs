using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _957ef244bb8baf74a96aa6ba59edb969_da004d1f79f14d3eb11987933d8a1407 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _957ef244bb8baf74a96aa6ba59edb969_da004d1f79f14d3eb11987933d8a1407 FromInterop(IntPtr data, int dataSize)
		{
			return default(_957ef244bb8baf74a96aa6ba59edb969_da004d1f79f14d3eb11987933d8a1407);
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

		public _957ef244bb8baf74a96aa6ba59edb969_da004d1f79f14d3eb11987933d8a1407(Entity entity, bool eraseItems, bool skipTriggers)
		{
			this.eraseItems = false;
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_957ef244bb8baf74a96aa6ba59edb969_da004d1f79f14d3eb11987933d8a1407 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _957ef244bb8baf74a96aa6ba59edb969_da004d1f79f14d3eb11987933d8a1407 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_957ef244bb8baf74a96aa6ba59edb969_da004d1f79f14d3eb11987933d8a1407);
		}
	}
}
