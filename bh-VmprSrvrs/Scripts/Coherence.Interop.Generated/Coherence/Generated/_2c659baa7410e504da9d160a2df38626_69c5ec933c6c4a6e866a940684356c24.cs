using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _2c659baa7410e504da9d160a2df38626_69c5ec933c6c4a6e866a940684356c24 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _2c659baa7410e504da9d160a2df38626_69c5ec933c6c4a6e866a940684356c24 FromInterop(IntPtr data, int dataSize)
		{
			return default(_2c659baa7410e504da9d160a2df38626_69c5ec933c6c4a6e866a940684356c24);
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

		public static void Serialize(_2c659baa7410e504da9d160a2df38626_69c5ec933c6c4a6e866a940684356c24 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _2c659baa7410e504da9d160a2df38626_69c5ec933c6c4a6e866a940684356c24 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_2c659baa7410e504da9d160a2df38626_69c5ec933c6c4a6e866a940684356c24);
		}
	}
}
