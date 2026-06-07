using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _6c7370e1a1cb09243a87e36c01eb5f91_453f7d2bbfc342deb96898c1cedd4a1d : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _6c7370e1a1cb09243a87e36c01eb5f91_453f7d2bbfc342deb96898c1cedd4a1d FromInterop(IntPtr data, int dataSize)
		{
			return default(_6c7370e1a1cb09243a87e36c01eb5f91_453f7d2bbfc342deb96898c1cedd4a1d);
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

		public static void Serialize(_6c7370e1a1cb09243a87e36c01eb5f91_453f7d2bbfc342deb96898c1cedd4a1d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _6c7370e1a1cb09243a87e36c01eb5f91_453f7d2bbfc342deb96898c1cedd4a1d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_6c7370e1a1cb09243a87e36c01eb5f91_453f7d2bbfc342deb96898c1cedd4a1d);
		}
	}
}
