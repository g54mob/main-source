using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _e70c46c802e9ae84981cf99734418104_60bd7139233144d7994d1c699cfb6ffa : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _e70c46c802e9ae84981cf99734418104_60bd7139233144d7994d1c699cfb6ffa FromInterop(IntPtr data, int dataSize)
		{
			return default(_e70c46c802e9ae84981cf99734418104_60bd7139233144d7994d1c699cfb6ffa);
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

		public _e70c46c802e9ae84981cf99734418104_60bd7139233144d7994d1c699cfb6ffa(Entity entity, bool eraseItems, bool skipTriggers)
		{
			this.eraseItems = false;
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_e70c46c802e9ae84981cf99734418104_60bd7139233144d7994d1c699cfb6ffa commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _e70c46c802e9ae84981cf99734418104_60bd7139233144d7994d1c699cfb6ffa Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_e70c46c802e9ae84981cf99734418104_60bd7139233144d7994d1c699cfb6ffa);
		}
	}
}
