using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _681fb067cbba7f147916b4995c9b2aaa_3b89c96f509f4b9387aa8b6fffcffd05 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _681fb067cbba7f147916b4995c9b2aaa_3b89c96f509f4b9387aa8b6fffcffd05 FromInterop(IntPtr data, int dataSize)
		{
			return default(_681fb067cbba7f147916b4995c9b2aaa_3b89c96f509f4b9387aa8b6fffcffd05);
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

		public static void Serialize(_681fb067cbba7f147916b4995c9b2aaa_3b89c96f509f4b9387aa8b6fffcffd05 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _681fb067cbba7f147916b4995c9b2aaa_3b89c96f509f4b9387aa8b6fffcffd05 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_681fb067cbba7f147916b4995c9b2aaa_3b89c96f509f4b9387aa8b6fffcffd05);
		}
	}
}
