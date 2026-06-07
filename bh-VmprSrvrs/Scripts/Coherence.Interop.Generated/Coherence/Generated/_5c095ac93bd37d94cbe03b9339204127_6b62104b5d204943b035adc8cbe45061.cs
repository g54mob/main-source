using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _5c095ac93bd37d94cbe03b9339204127_6b62104b5d204943b035adc8cbe45061 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _5c095ac93bd37d94cbe03b9339204127_6b62104b5d204943b035adc8cbe45061 FromInterop(IntPtr data, int dataSize)
		{
			return default(_5c095ac93bd37d94cbe03b9339204127_6b62104b5d204943b035adc8cbe45061);
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

		public _5c095ac93bd37d94cbe03b9339204127_6b62104b5d204943b035adc8cbe45061(Entity entity, long frame, int weaponType)
		{
			this.frame = 0L;
			this.weaponType = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_5c095ac93bd37d94cbe03b9339204127_6b62104b5d204943b035adc8cbe45061 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _5c095ac93bd37d94cbe03b9339204127_6b62104b5d204943b035adc8cbe45061 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_5c095ac93bd37d94cbe03b9339204127_6b62104b5d204943b035adc8cbe45061);
		}
	}
}
