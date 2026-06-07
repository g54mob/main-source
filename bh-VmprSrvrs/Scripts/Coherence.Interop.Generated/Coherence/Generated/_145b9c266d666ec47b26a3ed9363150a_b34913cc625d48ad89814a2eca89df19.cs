using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _145b9c266d666ec47b26a3ed9363150a_b34913cc625d48ad89814a2eca89df19 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _145b9c266d666ec47b26a3ed9363150a_b34913cc625d48ad89814a2eca89df19 FromInterop(IntPtr data, int dataSize)
		{
			return default(_145b9c266d666ec47b26a3ed9363150a_b34913cc625d48ad89814a2eca89df19);
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

		public static void Serialize(_145b9c266d666ec47b26a3ed9363150a_b34913cc625d48ad89814a2eca89df19 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _145b9c266d666ec47b26a3ed9363150a_b34913cc625d48ad89814a2eca89df19 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_145b9c266d666ec47b26a3ed9363150a_b34913cc625d48ad89814a2eca89df19);
		}
	}
}
