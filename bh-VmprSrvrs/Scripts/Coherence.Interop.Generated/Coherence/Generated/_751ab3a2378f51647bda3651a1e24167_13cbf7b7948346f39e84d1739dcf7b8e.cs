using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _751ab3a2378f51647bda3651a1e24167_13cbf7b7948346f39e84d1739dcf7b8e : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _751ab3a2378f51647bda3651a1e24167_13cbf7b7948346f39e84d1739dcf7b8e FromInterop(IntPtr data, int dataSize)
		{
			return default(_751ab3a2378f51647bda3651a1e24167_13cbf7b7948346f39e84d1739dcf7b8e);
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

		public static void Serialize(_751ab3a2378f51647bda3651a1e24167_13cbf7b7948346f39e84d1739dcf7b8e commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _751ab3a2378f51647bda3651a1e24167_13cbf7b7948346f39e84d1739dcf7b8e Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_751ab3a2378f51647bda3651a1e24167_13cbf7b7948346f39e84d1739dcf7b8e);
		}
	}
}
