using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _f97a6360a238ba0429101a386982079d_9945880286244f138b20f45192c2dc39 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _f97a6360a238ba0429101a386982079d_9945880286244f138b20f45192c2dc39 FromInterop(IntPtr data, int dataSize)
		{
			return default(_f97a6360a238ba0429101a386982079d_9945880286244f138b20f45192c2dc39);
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

		public static void Serialize(_f97a6360a238ba0429101a386982079d_9945880286244f138b20f45192c2dc39 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _f97a6360a238ba0429101a386982079d_9945880286244f138b20f45192c2dc39 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_f97a6360a238ba0429101a386982079d_9945880286244f138b20f45192c2dc39);
		}
	}
}
