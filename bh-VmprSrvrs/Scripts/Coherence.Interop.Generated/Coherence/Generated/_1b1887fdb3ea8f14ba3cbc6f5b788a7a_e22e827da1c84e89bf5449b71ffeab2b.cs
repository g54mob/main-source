using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _1b1887fdb3ea8f14ba3cbc6f5b788a7a_e22e827da1c84e89bf5449b71ffeab2b : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public Entity requestingPlayer;
		}

		public Entity requestingPlayer;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _1b1887fdb3ea8f14ba3cbc6f5b788a7a_e22e827da1c84e89bf5449b71ffeab2b FromInterop(IntPtr data, int dataSize)
		{
			return default(_1b1887fdb3ea8f14ba3cbc6f5b788a7a_e22e827da1c84e89bf5449b71ffeab2b);
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

		public _1b1887fdb3ea8f14ba3cbc6f5b788a7a_e22e827da1c84e89bf5449b71ffeab2b(Entity entity, Entity requestingPlayer)
		{
			this.requestingPlayer = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_1b1887fdb3ea8f14ba3cbc6f5b788a7a_e22e827da1c84e89bf5449b71ffeab2b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _1b1887fdb3ea8f14ba3cbc6f5b788a7a_e22e827da1c84e89bf5449b71ffeab2b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_1b1887fdb3ea8f14ba3cbc6f5b788a7a_e22e827da1c84e89bf5449b71ffeab2b);
		}
	}
}
