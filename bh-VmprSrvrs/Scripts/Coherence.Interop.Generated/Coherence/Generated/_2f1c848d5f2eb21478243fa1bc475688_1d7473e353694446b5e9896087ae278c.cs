using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _2f1c848d5f2eb21478243fa1bc475688_1d7473e353694446b5e9896087ae278c : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public byte skipTriggers;
		}

		public bool skipTriggers;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _2f1c848d5f2eb21478243fa1bc475688_1d7473e353694446b5e9896087ae278c FromInterop(IntPtr data, int dataSize)
		{
			return default(_2f1c848d5f2eb21478243fa1bc475688_1d7473e353694446b5e9896087ae278c);
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

		public _2f1c848d5f2eb21478243fa1bc475688_1d7473e353694446b5e9896087ae278c(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_2f1c848d5f2eb21478243fa1bc475688_1d7473e353694446b5e9896087ae278c commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _2f1c848d5f2eb21478243fa1bc475688_1d7473e353694446b5e9896087ae278c Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_2f1c848d5f2eb21478243fa1bc475688_1d7473e353694446b5e9896087ae278c);
		}
	}
}
