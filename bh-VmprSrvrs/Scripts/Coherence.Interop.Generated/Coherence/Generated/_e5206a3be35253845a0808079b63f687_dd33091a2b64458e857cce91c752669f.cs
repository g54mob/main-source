using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _e5206a3be35253845a0808079b63f687_dd33091a2b64458e857cce91c752669f : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _e5206a3be35253845a0808079b63f687_dd33091a2b64458e857cce91c752669f FromInterop(IntPtr data, int dataSize)
		{
			return default(_e5206a3be35253845a0808079b63f687_dd33091a2b64458e857cce91c752669f);
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

		public static void Serialize(_e5206a3be35253845a0808079b63f687_dd33091a2b64458e857cce91c752669f commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _e5206a3be35253845a0808079b63f687_dd33091a2b64458e857cce91c752669f Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_e5206a3be35253845a0808079b63f687_dd33091a2b64458e857cce91c752669f);
		}
	}
}
