using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _bcdcd4edf4070c740b4053df07a17fd0_b09ac41ec48e4881ba344be8db75783c : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _bcdcd4edf4070c740b4053df07a17fd0_b09ac41ec48e4881ba344be8db75783c FromInterop(IntPtr data, int dataSize)
		{
			return default(_bcdcd4edf4070c740b4053df07a17fd0_b09ac41ec48e4881ba344be8db75783c);
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

		public _bcdcd4edf4070c740b4053df07a17fd0_b09ac41ec48e4881ba344be8db75783c(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_bcdcd4edf4070c740b4053df07a17fd0_b09ac41ec48e4881ba344be8db75783c commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _bcdcd4edf4070c740b4053df07a17fd0_b09ac41ec48e4881ba344be8db75783c Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_bcdcd4edf4070c740b4053df07a17fd0_b09ac41ec48e4881ba344be8db75783c);
		}
	}
}
