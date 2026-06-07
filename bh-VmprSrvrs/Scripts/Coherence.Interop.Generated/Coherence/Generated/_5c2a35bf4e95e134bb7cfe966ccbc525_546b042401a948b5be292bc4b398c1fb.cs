using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _5c2a35bf4e95e134bb7cfe966ccbc525_546b042401a948b5be292bc4b398c1fb : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _5c2a35bf4e95e134bb7cfe966ccbc525_546b042401a948b5be292bc4b398c1fb FromInterop(IntPtr data, int dataSize)
		{
			return default(_5c2a35bf4e95e134bb7cfe966ccbc525_546b042401a948b5be292bc4b398c1fb);
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

		public static void Serialize(_5c2a35bf4e95e134bb7cfe966ccbc525_546b042401a948b5be292bc4b398c1fb commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _5c2a35bf4e95e134bb7cfe966ccbc525_546b042401a948b5be292bc4b398c1fb Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_5c2a35bf4e95e134bb7cfe966ccbc525_546b042401a948b5be292bc4b398c1fb);
		}
	}
}
