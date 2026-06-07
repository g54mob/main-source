using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _0b28d8c08e451b84e8ecd90fa753b600_34e5aa5f401949658533b70469d9d5c9 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _0b28d8c08e451b84e8ecd90fa753b600_34e5aa5f401949658533b70469d9d5c9 FromInterop(IntPtr data, int dataSize)
		{
			return default(_0b28d8c08e451b84e8ecd90fa753b600_34e5aa5f401949658533b70469d9d5c9);
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

		public static void Serialize(_0b28d8c08e451b84e8ecd90fa753b600_34e5aa5f401949658533b70469d9d5c9 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _0b28d8c08e451b84e8ecd90fa753b600_34e5aa5f401949658533b70469d9d5c9 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_0b28d8c08e451b84e8ecd90fa753b600_34e5aa5f401949658533b70469d9d5c9);
		}
	}
}
