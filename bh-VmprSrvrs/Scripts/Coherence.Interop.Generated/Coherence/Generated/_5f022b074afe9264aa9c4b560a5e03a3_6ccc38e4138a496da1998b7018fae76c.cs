using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _5f022b074afe9264aa9c4b560a5e03a3_6ccc38e4138a496da1998b7018fae76c : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _5f022b074afe9264aa9c4b560a5e03a3_6ccc38e4138a496da1998b7018fae76c FromInterop(IntPtr data, int dataSize)
		{
			return default(_5f022b074afe9264aa9c4b560a5e03a3_6ccc38e4138a496da1998b7018fae76c);
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

		public static void Serialize(_5f022b074afe9264aa9c4b560a5e03a3_6ccc38e4138a496da1998b7018fae76c commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _5f022b074afe9264aa9c4b560a5e03a3_6ccc38e4138a496da1998b7018fae76c Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_5f022b074afe9264aa9c4b560a5e03a3_6ccc38e4138a496da1998b7018fae76c);
		}
	}
}
