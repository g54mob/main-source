using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _87ae72cdba9ade446811d62dc7f908b0_5c5f6f0408c74ddfac02f6bd175f6111 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _87ae72cdba9ade446811d62dc7f908b0_5c5f6f0408c74ddfac02f6bd175f6111 FromInterop(IntPtr data, int dataSize)
		{
			return default(_87ae72cdba9ade446811d62dc7f908b0_5c5f6f0408c74ddfac02f6bd175f6111);
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

		public static void Serialize(_87ae72cdba9ade446811d62dc7f908b0_5c5f6f0408c74ddfac02f6bd175f6111 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _87ae72cdba9ade446811d62dc7f908b0_5c5f6f0408c74ddfac02f6bd175f6111 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_87ae72cdba9ade446811d62dc7f908b0_5c5f6f0408c74ddfac02f6bd175f6111);
		}
	}
}
