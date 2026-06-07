using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _46489c2ba22519b499410825c8c8efb1_8ae6d4c5dafa4139ace83b2bfb92cdb2 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public Entity player;
		}

		public long startingSimFrame;

		public Entity player;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _46489c2ba22519b499410825c8c8efb1_8ae6d4c5dafa4139ace83b2bfb92cdb2 FromInterop(IntPtr data, int dataSize)
		{
			return default(_46489c2ba22519b499410825c8c8efb1_8ae6d4c5dafa4139ace83b2bfb92cdb2);
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

		public _46489c2ba22519b499410825c8c8efb1_8ae6d4c5dafa4139ace83b2bfb92cdb2(Entity entity, long startingSimFrame, Entity player)
		{
			this.startingSimFrame = 0L;
			this.player = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_46489c2ba22519b499410825c8c8efb1_8ae6d4c5dafa4139ace83b2bfb92cdb2 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _46489c2ba22519b499410825c8c8efb1_8ae6d4c5dafa4139ace83b2bfb92cdb2 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_46489c2ba22519b499410825c8c8efb1_8ae6d4c5dafa4139ace83b2bfb92cdb2);
		}
	}
}
