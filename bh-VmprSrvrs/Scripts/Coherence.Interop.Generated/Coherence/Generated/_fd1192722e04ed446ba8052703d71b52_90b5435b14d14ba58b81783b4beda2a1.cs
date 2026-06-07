using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _fd1192722e04ed446ba8052703d71b52_90b5435b14d14ba58b81783b4beda2a1 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _fd1192722e04ed446ba8052703d71b52_90b5435b14d14ba58b81783b4beda2a1 FromInterop(IntPtr data, int dataSize)
		{
			return default(_fd1192722e04ed446ba8052703d71b52_90b5435b14d14ba58b81783b4beda2a1);
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

		public static void Serialize(_fd1192722e04ed446ba8052703d71b52_90b5435b14d14ba58b81783b4beda2a1 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _fd1192722e04ed446ba8052703d71b52_90b5435b14d14ba58b81783b4beda2a1 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_fd1192722e04ed446ba8052703d71b52_90b5435b14d14ba58b81783b4beda2a1);
		}
	}
}
