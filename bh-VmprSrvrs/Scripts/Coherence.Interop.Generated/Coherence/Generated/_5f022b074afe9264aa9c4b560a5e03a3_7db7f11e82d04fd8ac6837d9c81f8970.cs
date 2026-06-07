using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _5f022b074afe9264aa9c4b560a5e03a3_7db7f11e82d04fd8ac6837d9c81f8970 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public byte skipTriggers;
		}

		public bool skipTriggers;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _5f022b074afe9264aa9c4b560a5e03a3_7db7f11e82d04fd8ac6837d9c81f8970 FromInterop(IntPtr data, int dataSize)
		{
			return default(_5f022b074afe9264aa9c4b560a5e03a3_7db7f11e82d04fd8ac6837d9c81f8970);
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

		public _5f022b074afe9264aa9c4b560a5e03a3_7db7f11e82d04fd8ac6837d9c81f8970(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_5f022b074afe9264aa9c4b560a5e03a3_7db7f11e82d04fd8ac6837d9c81f8970 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _5f022b074afe9264aa9c4b560a5e03a3_7db7f11e82d04fd8ac6837d9c81f8970 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_5f022b074afe9264aa9c4b560a5e03a3_7db7f11e82d04fd8ac6837d9c81f8970);
		}
	}
}
