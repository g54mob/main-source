using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _b29f1af98803f164bbbef37a5210543c_30a07a61263c4ddea38599bb2af48be5 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _b29f1af98803f164bbbef37a5210543c_30a07a61263c4ddea38599bb2af48be5 FromInterop(IntPtr data, int dataSize)
		{
			return default(_b29f1af98803f164bbbef37a5210543c_30a07a61263c4ddea38599bb2af48be5);
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

		public static void Serialize(_b29f1af98803f164bbbef37a5210543c_30a07a61263c4ddea38599bb2af48be5 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _b29f1af98803f164bbbef37a5210543c_30a07a61263c4ddea38599bb2af48be5 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_b29f1af98803f164bbbef37a5210543c_30a07a61263c4ddea38599bb2af48be5);
		}
	}
}
