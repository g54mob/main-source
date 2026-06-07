using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _18f4f7361a86e0945ad53b26e17c318f_975956c191884e3c9d14c9a9d30c4473 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _18f4f7361a86e0945ad53b26e17c318f_975956c191884e3c9d14c9a9d30c4473 FromInterop(IntPtr data, int dataSize)
		{
			return default(_18f4f7361a86e0945ad53b26e17c318f_975956c191884e3c9d14c9a9d30c4473);
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

		public static void Serialize(_18f4f7361a86e0945ad53b26e17c318f_975956c191884e3c9d14c9a9d30c4473 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _18f4f7361a86e0945ad53b26e17c318f_975956c191884e3c9d14c9a9d30c4473 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_18f4f7361a86e0945ad53b26e17c318f_975956c191884e3c9d14c9a9d30c4473);
		}
	}
}
