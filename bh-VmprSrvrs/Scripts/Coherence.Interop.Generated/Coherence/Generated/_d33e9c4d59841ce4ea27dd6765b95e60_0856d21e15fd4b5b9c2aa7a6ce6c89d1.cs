using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _d33e9c4d59841ce4ea27dd6765b95e60_0856d21e15fd4b5b9c2aa7a6ce6c89d1 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _d33e9c4d59841ce4ea27dd6765b95e60_0856d21e15fd4b5b9c2aa7a6ce6c89d1 FromInterop(IntPtr data, int dataSize)
		{
			return default(_d33e9c4d59841ce4ea27dd6765b95e60_0856d21e15fd4b5b9c2aa7a6ce6c89d1);
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

		public static void Serialize(_d33e9c4d59841ce4ea27dd6765b95e60_0856d21e15fd4b5b9c2aa7a6ce6c89d1 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _d33e9c4d59841ce4ea27dd6765b95e60_0856d21e15fd4b5b9c2aa7a6ce6c89d1 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_d33e9c4d59841ce4ea27dd6765b95e60_0856d21e15fd4b5b9c2aa7a6ce6c89d1);
		}
	}
}
