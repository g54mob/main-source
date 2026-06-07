using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _6c69a4bfa8374fb4480f3356af296730_9002d37e967c453da54a436d548d15ad : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _6c69a4bfa8374fb4480f3356af296730_9002d37e967c453da54a436d548d15ad FromInterop(IntPtr data, int dataSize)
		{
			return default(_6c69a4bfa8374fb4480f3356af296730_9002d37e967c453da54a436d548d15ad);
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

		public static void Serialize(_6c69a4bfa8374fb4480f3356af296730_9002d37e967c453da54a436d548d15ad commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _6c69a4bfa8374fb4480f3356af296730_9002d37e967c453da54a436d548d15ad Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_6c69a4bfa8374fb4480f3356af296730_9002d37e967c453da54a436d548d15ad);
		}
	}
}
