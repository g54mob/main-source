using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _20153b7a59ab6d241adc6002b14d9033_becd45b2ed304c1cb733bdd706c9d698 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public byte isLeft;
		}

		public bool isLeft;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _20153b7a59ab6d241adc6002b14d9033_becd45b2ed304c1cb733bdd706c9d698 FromInterop(IntPtr data, int dataSize)
		{
			return default(_20153b7a59ab6d241adc6002b14d9033_becd45b2ed304c1cb733bdd706c9d698);
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

		public _20153b7a59ab6d241adc6002b14d9033_becd45b2ed304c1cb733bdd706c9d698(Entity entity, bool isLeft)
		{
			this.isLeft = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_20153b7a59ab6d241adc6002b14d9033_becd45b2ed304c1cb733bdd706c9d698 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _20153b7a59ab6d241adc6002b14d9033_becd45b2ed304c1cb733bdd706c9d698 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_20153b7a59ab6d241adc6002b14d9033_becd45b2ed304c1cb733bdd706c9d698);
		}
	}
}
