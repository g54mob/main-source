using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _005f5e65376a2994493ddbe5c24f5150_8ce674dca0ac4563a25e9ef7657b8337 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _005f5e65376a2994493ddbe5c24f5150_8ce674dca0ac4563a25e9ef7657b8337 FromInterop(IntPtr data, int dataSize)
		{
			return default(_005f5e65376a2994493ddbe5c24f5150_8ce674dca0ac4563a25e9ef7657b8337);
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

		public static void Serialize(_005f5e65376a2994493ddbe5c24f5150_8ce674dca0ac4563a25e9ef7657b8337 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _005f5e65376a2994493ddbe5c24f5150_8ce674dca0ac4563a25e9ef7657b8337 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_005f5e65376a2994493ddbe5c24f5150_8ce674dca0ac4563a25e9ef7657b8337);
		}
	}
}
