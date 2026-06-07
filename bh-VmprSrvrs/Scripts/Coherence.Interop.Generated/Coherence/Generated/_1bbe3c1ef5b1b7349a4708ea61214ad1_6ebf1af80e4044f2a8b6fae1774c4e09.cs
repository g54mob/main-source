using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _1bbe3c1ef5b1b7349a4708ea61214ad1_6ebf1af80e4044f2a8b6fae1774c4e09 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _1bbe3c1ef5b1b7349a4708ea61214ad1_6ebf1af80e4044f2a8b6fae1774c4e09 FromInterop(IntPtr data, int dataSize)
		{
			return default(_1bbe3c1ef5b1b7349a4708ea61214ad1_6ebf1af80e4044f2a8b6fae1774c4e09);
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

		public static void Serialize(_1bbe3c1ef5b1b7349a4708ea61214ad1_6ebf1af80e4044f2a8b6fae1774c4e09 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _1bbe3c1ef5b1b7349a4708ea61214ad1_6ebf1af80e4044f2a8b6fae1774c4e09 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_1bbe3c1ef5b1b7349a4708ea61214ad1_6ebf1af80e4044f2a8b6fae1774c4e09);
		}
	}
}
