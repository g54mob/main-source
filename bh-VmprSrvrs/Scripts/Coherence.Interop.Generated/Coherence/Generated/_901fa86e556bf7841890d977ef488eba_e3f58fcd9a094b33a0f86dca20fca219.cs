using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _901fa86e556bf7841890d977ef488eba_e3f58fcd9a094b33a0f86dca20fca219 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _901fa86e556bf7841890d977ef488eba_e3f58fcd9a094b33a0f86dca20fca219 FromInterop(IntPtr data, int dataSize)
		{
			return default(_901fa86e556bf7841890d977ef488eba_e3f58fcd9a094b33a0f86dca20fca219);
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

		public static void Serialize(_901fa86e556bf7841890d977ef488eba_e3f58fcd9a094b33a0f86dca20fca219 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _901fa86e556bf7841890d977ef488eba_e3f58fcd9a094b33a0f86dca20fca219 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_901fa86e556bf7841890d977ef488eba_e3f58fcd9a094b33a0f86dca20fca219);
		}
	}
}
