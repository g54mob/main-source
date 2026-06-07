using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _57b5c5fa685b83d4aa86b0d05c841f29_d0f7895ecd1e42fabfc9128a5241476a : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _57b5c5fa685b83d4aa86b0d05c841f29_d0f7895ecd1e42fabfc9128a5241476a FromInterop(IntPtr data, int dataSize)
		{
			return default(_57b5c5fa685b83d4aa86b0d05c841f29_d0f7895ecd1e42fabfc9128a5241476a);
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

		public static void Serialize(_57b5c5fa685b83d4aa86b0d05c841f29_d0f7895ecd1e42fabfc9128a5241476a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _57b5c5fa685b83d4aa86b0d05c841f29_d0f7895ecd1e42fabfc9128a5241476a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_57b5c5fa685b83d4aa86b0d05c841f29_d0f7895ecd1e42fabfc9128a5241476a);
		}
	}
}
