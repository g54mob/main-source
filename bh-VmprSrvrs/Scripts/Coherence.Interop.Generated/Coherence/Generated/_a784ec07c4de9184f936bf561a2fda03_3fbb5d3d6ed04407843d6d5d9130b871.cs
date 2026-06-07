using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a784ec07c4de9184f936bf561a2fda03_3fbb5d3d6ed04407843d6d5d9130b871 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _a784ec07c4de9184f936bf561a2fda03_3fbb5d3d6ed04407843d6d5d9130b871 FromInterop(IntPtr data, int dataSize)
		{
			return default(_a784ec07c4de9184f936bf561a2fda03_3fbb5d3d6ed04407843d6d5d9130b871);
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

		public static void Serialize(_a784ec07c4de9184f936bf561a2fda03_3fbb5d3d6ed04407843d6d5d9130b871 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a784ec07c4de9184f936bf561a2fda03_3fbb5d3d6ed04407843d6d5d9130b871 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a784ec07c4de9184f936bf561a2fda03_3fbb5d3d6ed04407843d6d5d9130b871);
		}
	}
}
