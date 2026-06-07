using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _de4c84c689767f946af1a41e8c5fd592_2d9b351c5a3844cb87c7f24f4d348657 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _de4c84c689767f946af1a41e8c5fd592_2d9b351c5a3844cb87c7f24f4d348657 FromInterop(IntPtr data, int dataSize)
		{
			return default(_de4c84c689767f946af1a41e8c5fd592_2d9b351c5a3844cb87c7f24f4d348657);
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

		public static void Serialize(_de4c84c689767f946af1a41e8c5fd592_2d9b351c5a3844cb87c7f24f4d348657 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _de4c84c689767f946af1a41e8c5fd592_2d9b351c5a3844cb87c7f24f4d348657 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_de4c84c689767f946af1a41e8c5fd592_2d9b351c5a3844cb87c7f24f4d348657);
		}
	}
}
