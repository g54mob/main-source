using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _7f11d9d5827fa65409eac7e9081f4255_4e2dba6a50eb4f3fbabc0c58f7229011 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _7f11d9d5827fa65409eac7e9081f4255_4e2dba6a50eb4f3fbabc0c58f7229011 FromInterop(IntPtr data, int dataSize)
		{
			return default(_7f11d9d5827fa65409eac7e9081f4255_4e2dba6a50eb4f3fbabc0c58f7229011);
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

		public static void Serialize(_7f11d9d5827fa65409eac7e9081f4255_4e2dba6a50eb4f3fbabc0c58f7229011 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _7f11d9d5827fa65409eac7e9081f4255_4e2dba6a50eb4f3fbabc0c58f7229011 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_7f11d9d5827fa65409eac7e9081f4255_4e2dba6a50eb4f3fbabc0c58f7229011);
		}
	}
}
