using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _6f907e4de406af4469f4f94755ec0b51_1ef40833ede34a179f4a2684a0c2b871 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _6f907e4de406af4469f4f94755ec0b51_1ef40833ede34a179f4a2684a0c2b871 FromInterop(IntPtr data, int dataSize)
		{
			return default(_6f907e4de406af4469f4f94755ec0b51_1ef40833ede34a179f4a2684a0c2b871);
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

		public static void Serialize(_6f907e4de406af4469f4f94755ec0b51_1ef40833ede34a179f4a2684a0c2b871 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _6f907e4de406af4469f4f94755ec0b51_1ef40833ede34a179f4a2684a0c2b871 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_6f907e4de406af4469f4f94755ec0b51_1ef40833ede34a179f4a2684a0c2b871);
		}
	}
}
