using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _7f021e4d33fdce8458921e62a3c6c885_89b1b3eab037492b85dbf3442d2d0879 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _7f021e4d33fdce8458921e62a3c6c885_89b1b3eab037492b85dbf3442d2d0879 FromInterop(IntPtr data, int dataSize)
		{
			return default(_7f021e4d33fdce8458921e62a3c6c885_89b1b3eab037492b85dbf3442d2d0879);
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

		public static void Serialize(_7f021e4d33fdce8458921e62a3c6c885_89b1b3eab037492b85dbf3442d2d0879 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _7f021e4d33fdce8458921e62a3c6c885_89b1b3eab037492b85dbf3442d2d0879 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_7f021e4d33fdce8458921e62a3c6c885_89b1b3eab037492b85dbf3442d2d0879);
		}
	}
}
