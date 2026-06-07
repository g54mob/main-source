using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _4f7a63aad47b0714a995316c8db68d7e_92ee65bad43c46de90d185675f7bd7ef : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long frame;

			[FieldOffset(8)]
			public int weaponType;
		}

		public long frame;

		public int weaponType;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _4f7a63aad47b0714a995316c8db68d7e_92ee65bad43c46de90d185675f7bd7ef FromInterop(IntPtr data, int dataSize)
		{
			return default(_4f7a63aad47b0714a995316c8db68d7e_92ee65bad43c46de90d185675f7bd7ef);
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

		public _4f7a63aad47b0714a995316c8db68d7e_92ee65bad43c46de90d185675f7bd7ef(Entity entity, long frame, int weaponType)
		{
			this.frame = 0L;
			this.weaponType = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_4f7a63aad47b0714a995316c8db68d7e_92ee65bad43c46de90d185675f7bd7ef commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _4f7a63aad47b0714a995316c8db68d7e_92ee65bad43c46de90d185675f7bd7ef Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_4f7a63aad47b0714a995316c8db68d7e_92ee65bad43c46de90d185675f7bd7ef);
		}
	}
}
