using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _f00b860cbd5487747b5122cbb3cd690a_93bad5d55c064d1a9ca0ce58cfa1f8b5 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _f00b860cbd5487747b5122cbb3cd690a_93bad5d55c064d1a9ca0ce58cfa1f8b5 FromInterop(IntPtr data, int dataSize)
		{
			return default(_f00b860cbd5487747b5122cbb3cd690a_93bad5d55c064d1a9ca0ce58cfa1f8b5);
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

		public static void Serialize(_f00b860cbd5487747b5122cbb3cd690a_93bad5d55c064d1a9ca0ce58cfa1f8b5 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _f00b860cbd5487747b5122cbb3cd690a_93bad5d55c064d1a9ca0ce58cfa1f8b5 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_f00b860cbd5487747b5122cbb3cd690a_93bad5d55c064d1a9ca0ce58cfa1f8b5);
		}
	}
}
