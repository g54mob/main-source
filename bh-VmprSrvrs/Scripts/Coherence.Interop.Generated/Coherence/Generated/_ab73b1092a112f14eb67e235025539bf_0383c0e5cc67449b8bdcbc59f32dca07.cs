using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ab73b1092a112f14eb67e235025539bf_0383c0e5cc67449b8bdcbc59f32dca07 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _ab73b1092a112f14eb67e235025539bf_0383c0e5cc67449b8bdcbc59f32dca07 FromInterop(IntPtr data, int dataSize)
		{
			return default(_ab73b1092a112f14eb67e235025539bf_0383c0e5cc67449b8bdcbc59f32dca07);
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

		public static void Serialize(_ab73b1092a112f14eb67e235025539bf_0383c0e5cc67449b8bdcbc59f32dca07 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ab73b1092a112f14eb67e235025539bf_0383c0e5cc67449b8bdcbc59f32dca07 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ab73b1092a112f14eb67e235025539bf_0383c0e5cc67449b8bdcbc59f32dca07);
		}
	}
}
