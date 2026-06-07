using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _2ee54d65527d6e349ac1574e8a829011_12e88be5332e48a6b6cd4af518626cc1 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public float damageAmount;
		}

		public float damageAmount;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _2ee54d65527d6e349ac1574e8a829011_12e88be5332e48a6b6cd4af518626cc1 FromInterop(IntPtr data, int dataSize)
		{
			return default(_2ee54d65527d6e349ac1574e8a829011_12e88be5332e48a6b6cd4af518626cc1);
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

		public _2ee54d65527d6e349ac1574e8a829011_12e88be5332e48a6b6cd4af518626cc1(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_2ee54d65527d6e349ac1574e8a829011_12e88be5332e48a6b6cd4af518626cc1 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _2ee54d65527d6e349ac1574e8a829011_12e88be5332e48a6b6cd4af518626cc1 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_2ee54d65527d6e349ac1574e8a829011_12e88be5332e48a6b6cd4af518626cc1);
		}
	}
}
