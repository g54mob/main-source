using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _6f907e4de406af4469f4f94755ec0b51_77604428376445e8a6b5552da3016b4e : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _6f907e4de406af4469f4f94755ec0b51_77604428376445e8a6b5552da3016b4e FromInterop(IntPtr data, int dataSize)
		{
			return default(_6f907e4de406af4469f4f94755ec0b51_77604428376445e8a6b5552da3016b4e);
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

		public _6f907e4de406af4469f4f94755ec0b51_77604428376445e8a6b5552da3016b4e(Entity entity, Entity requestingPlayer)
		{
			this.requestingPlayer = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_6f907e4de406af4469f4f94755ec0b51_77604428376445e8a6b5552da3016b4e commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _6f907e4de406af4469f4f94755ec0b51_77604428376445e8a6b5552da3016b4e Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_6f907e4de406af4469f4f94755ec0b51_77604428376445e8a6b5552da3016b4e);
		}
	}
}
