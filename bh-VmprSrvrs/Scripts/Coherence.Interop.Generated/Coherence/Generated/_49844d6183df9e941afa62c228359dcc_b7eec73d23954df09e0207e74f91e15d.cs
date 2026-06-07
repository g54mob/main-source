using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _49844d6183df9e941afa62c228359dcc_b7eec73d23954df09e0207e74f91e15d : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _49844d6183df9e941afa62c228359dcc_b7eec73d23954df09e0207e74f91e15d FromInterop(IntPtr data, int dataSize)
		{
			return default(_49844d6183df9e941afa62c228359dcc_b7eec73d23954df09e0207e74f91e15d);
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

		public static void Serialize(_49844d6183df9e941afa62c228359dcc_b7eec73d23954df09e0207e74f91e15d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _49844d6183df9e941afa62c228359dcc_b7eec73d23954df09e0207e74f91e15d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_49844d6183df9e941afa62c228359dcc_b7eec73d23954df09e0207e74f91e15d);
		}
	}
}
