using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _d6fc9483b3f1f6541b4122c5b5318fff_9b057fc0a72d48a686bc222998fe1c66 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _d6fc9483b3f1f6541b4122c5b5318fff_9b057fc0a72d48a686bc222998fe1c66 FromInterop(IntPtr data, int dataSize)
		{
			return default(_d6fc9483b3f1f6541b4122c5b5318fff_9b057fc0a72d48a686bc222998fe1c66);
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

		public _d6fc9483b3f1f6541b4122c5b5318fff_9b057fc0a72d48a686bc222998fe1c66(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_d6fc9483b3f1f6541b4122c5b5318fff_9b057fc0a72d48a686bc222998fe1c66 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _d6fc9483b3f1f6541b4122c5b5318fff_9b057fc0a72d48a686bc222998fe1c66 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_d6fc9483b3f1f6541b4122c5b5318fff_9b057fc0a72d48a686bc222998fe1c66);
		}
	}
}
