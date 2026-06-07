using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _de05d1ac240105148a399ffba1e0e071_a2e692be74fd462281aef254d807164a : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _de05d1ac240105148a399ffba1e0e071_a2e692be74fd462281aef254d807164a FromInterop(IntPtr data, int dataSize)
		{
			return default(_de05d1ac240105148a399ffba1e0e071_a2e692be74fd462281aef254d807164a);
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

		public _de05d1ac240105148a399ffba1e0e071_a2e692be74fd462281aef254d807164a(Entity entity, Entity requestingPlayer)
		{
			this.requestingPlayer = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_de05d1ac240105148a399ffba1e0e071_a2e692be74fd462281aef254d807164a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _de05d1ac240105148a399ffba1e0e071_a2e692be74fd462281aef254d807164a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_de05d1ac240105148a399ffba1e0e071_a2e692be74fd462281aef254d807164a);
		}
	}
}
