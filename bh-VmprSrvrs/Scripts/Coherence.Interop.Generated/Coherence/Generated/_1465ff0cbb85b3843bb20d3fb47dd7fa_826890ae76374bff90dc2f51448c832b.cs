using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _1465ff0cbb85b3843bb20d3fb47dd7fa_826890ae76374bff90dc2f51448c832b : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _1465ff0cbb85b3843bb20d3fb47dd7fa_826890ae76374bff90dc2f51448c832b FromInterop(IntPtr data, int dataSize)
		{
			return default(_1465ff0cbb85b3843bb20d3fb47dd7fa_826890ae76374bff90dc2f51448c832b);
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

		public static void Serialize(_1465ff0cbb85b3843bb20d3fb47dd7fa_826890ae76374bff90dc2f51448c832b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _1465ff0cbb85b3843bb20d3fb47dd7fa_826890ae76374bff90dc2f51448c832b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_1465ff0cbb85b3843bb20d3fb47dd7fa_826890ae76374bff90dc2f51448c832b);
		}
	}
}
