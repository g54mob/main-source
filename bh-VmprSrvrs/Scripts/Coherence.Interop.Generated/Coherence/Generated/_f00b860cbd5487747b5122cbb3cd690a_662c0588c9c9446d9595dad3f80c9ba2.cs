using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _f00b860cbd5487747b5122cbb3cd690a_662c0588c9c9446d9595dad3f80c9ba2 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _f00b860cbd5487747b5122cbb3cd690a_662c0588c9c9446d9595dad3f80c9ba2 FromInterop(IntPtr data, int dataSize)
		{
			return default(_f00b860cbd5487747b5122cbb3cd690a_662c0588c9c9446d9595dad3f80c9ba2);
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

		public static void Serialize(_f00b860cbd5487747b5122cbb3cd690a_662c0588c9c9446d9595dad3f80c9ba2 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _f00b860cbd5487747b5122cbb3cd690a_662c0588c9c9446d9595dad3f80c9ba2 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_f00b860cbd5487747b5122cbb3cd690a_662c0588c9c9446d9595dad3f80c9ba2);
		}
	}
}
