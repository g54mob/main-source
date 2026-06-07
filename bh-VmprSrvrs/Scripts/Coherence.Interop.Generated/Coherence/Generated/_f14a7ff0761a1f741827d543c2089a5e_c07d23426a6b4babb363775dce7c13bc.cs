using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _f14a7ff0761a1f741827d543c2089a5e_c07d23426a6b4babb363775dce7c13bc : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _f14a7ff0761a1f741827d543c2089a5e_c07d23426a6b4babb363775dce7c13bc FromInterop(IntPtr data, int dataSize)
		{
			return default(_f14a7ff0761a1f741827d543c2089a5e_c07d23426a6b4babb363775dce7c13bc);
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

		public static void Serialize(_f14a7ff0761a1f741827d543c2089a5e_c07d23426a6b4babb363775dce7c13bc commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _f14a7ff0761a1f741827d543c2089a5e_c07d23426a6b4babb363775dce7c13bc Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_f14a7ff0761a1f741827d543c2089a5e_c07d23426a6b4babb363775dce7c13bc);
		}
	}
}
