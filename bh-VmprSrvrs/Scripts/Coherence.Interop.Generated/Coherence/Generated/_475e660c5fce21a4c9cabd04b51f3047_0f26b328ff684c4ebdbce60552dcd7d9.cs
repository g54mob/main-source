using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _475e660c5fce21a4c9cabd04b51f3047_0f26b328ff684c4ebdbce60552dcd7d9 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _475e660c5fce21a4c9cabd04b51f3047_0f26b328ff684c4ebdbce60552dcd7d9 FromInterop(IntPtr data, int dataSize)
		{
			return default(_475e660c5fce21a4c9cabd04b51f3047_0f26b328ff684c4ebdbce60552dcd7d9);
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

		public static void Serialize(_475e660c5fce21a4c9cabd04b51f3047_0f26b328ff684c4ebdbce60552dcd7d9 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _475e660c5fce21a4c9cabd04b51f3047_0f26b328ff684c4ebdbce60552dcd7d9 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_475e660c5fce21a4c9cabd04b51f3047_0f26b328ff684c4ebdbce60552dcd7d9);
		}
	}
}
