using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _30179d4af99c81d4a943d5f6bd7c0bbb_04e135e6b1f9455790e73db5c3e69eb2 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _30179d4af99c81d4a943d5f6bd7c0bbb_04e135e6b1f9455790e73db5c3e69eb2 FromInterop(IntPtr data, int dataSize)
		{
			return default(_30179d4af99c81d4a943d5f6bd7c0bbb_04e135e6b1f9455790e73db5c3e69eb2);
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

		public static void Serialize(_30179d4af99c81d4a943d5f6bd7c0bbb_04e135e6b1f9455790e73db5c3e69eb2 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _30179d4af99c81d4a943d5f6bd7c0bbb_04e135e6b1f9455790e73db5c3e69eb2 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_30179d4af99c81d4a943d5f6bd7c0bbb_04e135e6b1f9455790e73db5c3e69eb2);
		}
	}
}
