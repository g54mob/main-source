using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _1b1887fdb3ea8f14ba3cbc6f5b788a7a_dbb156699e914d349ea47687485f8810 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _1b1887fdb3ea8f14ba3cbc6f5b788a7a_dbb156699e914d349ea47687485f8810 FromInterop(IntPtr data, int dataSize)
		{
			return default(_1b1887fdb3ea8f14ba3cbc6f5b788a7a_dbb156699e914d349ea47687485f8810);
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

		public static void Serialize(_1b1887fdb3ea8f14ba3cbc6f5b788a7a_dbb156699e914d349ea47687485f8810 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _1b1887fdb3ea8f14ba3cbc6f5b788a7a_dbb156699e914d349ea47687485f8810 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_1b1887fdb3ea8f14ba3cbc6f5b788a7a_dbb156699e914d349ea47687485f8810);
		}
	}
}
