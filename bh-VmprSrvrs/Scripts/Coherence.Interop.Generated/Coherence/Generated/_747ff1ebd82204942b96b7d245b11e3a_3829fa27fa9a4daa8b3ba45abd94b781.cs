using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _747ff1ebd82204942b96b7d245b11e3a_3829fa27fa9a4daa8b3ba45abd94b781 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _747ff1ebd82204942b96b7d245b11e3a_3829fa27fa9a4daa8b3ba45abd94b781 FromInterop(IntPtr data, int dataSize)
		{
			return default(_747ff1ebd82204942b96b7d245b11e3a_3829fa27fa9a4daa8b3ba45abd94b781);
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

		public static void Serialize(_747ff1ebd82204942b96b7d245b11e3a_3829fa27fa9a4daa8b3ba45abd94b781 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _747ff1ebd82204942b96b7d245b11e3a_3829fa27fa9a4daa8b3ba45abd94b781 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_747ff1ebd82204942b96b7d245b11e3a_3829fa27fa9a4daa8b3ba45abd94b781);
		}
	}
}
