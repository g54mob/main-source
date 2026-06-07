using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _b62bc17cb38766e4b8a392a8ce43a0f9_b9b58ca020dc4e8cb2e68fbbf351486a : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _b62bc17cb38766e4b8a392a8ce43a0f9_b9b58ca020dc4e8cb2e68fbbf351486a FromInterop(IntPtr data, int dataSize)
		{
			return default(_b62bc17cb38766e4b8a392a8ce43a0f9_b9b58ca020dc4e8cb2e68fbbf351486a);
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

		public static void Serialize(_b62bc17cb38766e4b8a392a8ce43a0f9_b9b58ca020dc4e8cb2e68fbbf351486a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _b62bc17cb38766e4b8a392a8ce43a0f9_b9b58ca020dc4e8cb2e68fbbf351486a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_b62bc17cb38766e4b8a392a8ce43a0f9_b9b58ca020dc4e8cb2e68fbbf351486a);
		}
	}
}
