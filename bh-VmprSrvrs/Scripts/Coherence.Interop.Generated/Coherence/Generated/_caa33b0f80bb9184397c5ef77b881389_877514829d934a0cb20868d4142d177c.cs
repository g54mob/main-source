using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _caa33b0f80bb9184397c5ef77b881389_877514829d934a0cb20868d4142d177c : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _caa33b0f80bb9184397c5ef77b881389_877514829d934a0cb20868d4142d177c FromInterop(IntPtr data, int dataSize)
		{
			return default(_caa33b0f80bb9184397c5ef77b881389_877514829d934a0cb20868d4142d177c);
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

		public _caa33b0f80bb9184397c5ef77b881389_877514829d934a0cb20868d4142d177c(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_caa33b0f80bb9184397c5ef77b881389_877514829d934a0cb20868d4142d177c commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _caa33b0f80bb9184397c5ef77b881389_877514829d934a0cb20868d4142d177c Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_caa33b0f80bb9184397c5ef77b881389_877514829d934a0cb20868d4142d177c);
		}
	}
}
