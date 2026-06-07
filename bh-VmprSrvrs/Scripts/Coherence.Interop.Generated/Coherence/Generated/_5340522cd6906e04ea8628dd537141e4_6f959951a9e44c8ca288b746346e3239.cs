using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _5340522cd6906e04ea8628dd537141e4_6f959951a9e44c8ca288b746346e3239 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _5340522cd6906e04ea8628dd537141e4_6f959951a9e44c8ca288b746346e3239 FromInterop(IntPtr data, int dataSize)
		{
			return default(_5340522cd6906e04ea8628dd537141e4_6f959951a9e44c8ca288b746346e3239);
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

		public static void Serialize(_5340522cd6906e04ea8628dd537141e4_6f959951a9e44c8ca288b746346e3239 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _5340522cd6906e04ea8628dd537141e4_6f959951a9e44c8ca288b746346e3239 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_5340522cd6906e04ea8628dd537141e4_6f959951a9e44c8ca288b746346e3239);
		}
	}
}
