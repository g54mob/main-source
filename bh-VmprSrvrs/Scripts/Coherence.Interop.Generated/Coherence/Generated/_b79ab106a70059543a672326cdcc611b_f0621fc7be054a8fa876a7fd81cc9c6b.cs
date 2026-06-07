using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _b79ab106a70059543a672326cdcc611b_f0621fc7be054a8fa876a7fd81cc9c6b : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _b79ab106a70059543a672326cdcc611b_f0621fc7be054a8fa876a7fd81cc9c6b FromInterop(IntPtr data, int dataSize)
		{
			return default(_b79ab106a70059543a672326cdcc611b_f0621fc7be054a8fa876a7fd81cc9c6b);
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

		public _b79ab106a70059543a672326cdcc611b_f0621fc7be054a8fa876a7fd81cc9c6b(Entity entity, long frame, int weaponType)
		{
			this.frame = 0L;
			this.weaponType = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_b79ab106a70059543a672326cdcc611b_f0621fc7be054a8fa876a7fd81cc9c6b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _b79ab106a70059543a672326cdcc611b_f0621fc7be054a8fa876a7fd81cc9c6b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_b79ab106a70059543a672326cdcc611b_f0621fc7be054a8fa876a7fd81cc9c6b);
		}
	}
}
