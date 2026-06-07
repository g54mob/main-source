using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _428511d43dcea284a88597578067b45b_60b68286b6c24bd0873c6e301be2a70a : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _428511d43dcea284a88597578067b45b_60b68286b6c24bd0873c6e301be2a70a FromInterop(IntPtr data, int dataSize)
		{
			return default(_428511d43dcea284a88597578067b45b_60b68286b6c24bd0873c6e301be2a70a);
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

		public _428511d43dcea284a88597578067b45b_60b68286b6c24bd0873c6e301be2a70a(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_428511d43dcea284a88597578067b45b_60b68286b6c24bd0873c6e301be2a70a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _428511d43dcea284a88597578067b45b_60b68286b6c24bd0873c6e301be2a70a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_428511d43dcea284a88597578067b45b_60b68286b6c24bd0873c6e301be2a70a);
		}
	}
}
