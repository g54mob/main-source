using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _accfc10a1b64d6143ab379fe62c0c946_b16c0ddc8c97415ea24877602765c252 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _accfc10a1b64d6143ab379fe62c0c946_b16c0ddc8c97415ea24877602765c252 FromInterop(IntPtr data, int dataSize)
		{
			return default(_accfc10a1b64d6143ab379fe62c0c946_b16c0ddc8c97415ea24877602765c252);
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

		public static void Serialize(_accfc10a1b64d6143ab379fe62c0c946_b16c0ddc8c97415ea24877602765c252 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _accfc10a1b64d6143ab379fe62c0c946_b16c0ddc8c97415ea24877602765c252 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_accfc10a1b64d6143ab379fe62c0c946_b16c0ddc8c97415ea24877602765c252);
		}
	}
}
