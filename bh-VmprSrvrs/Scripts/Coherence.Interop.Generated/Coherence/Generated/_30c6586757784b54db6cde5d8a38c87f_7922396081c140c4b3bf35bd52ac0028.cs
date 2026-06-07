using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _30c6586757784b54db6cde5d8a38c87f_7922396081c140c4b3bf35bd52ac0028 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _30c6586757784b54db6cde5d8a38c87f_7922396081c140c4b3bf35bd52ac0028 FromInterop(IntPtr data, int dataSize)
		{
			return default(_30c6586757784b54db6cde5d8a38c87f_7922396081c140c4b3bf35bd52ac0028);
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

		public static void Serialize(_30c6586757784b54db6cde5d8a38c87f_7922396081c140c4b3bf35bd52ac0028 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _30c6586757784b54db6cde5d8a38c87f_7922396081c140c4b3bf35bd52ac0028 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_30c6586757784b54db6cde5d8a38c87f_7922396081c140c4b3bf35bd52ac0028);
		}
	}
}
