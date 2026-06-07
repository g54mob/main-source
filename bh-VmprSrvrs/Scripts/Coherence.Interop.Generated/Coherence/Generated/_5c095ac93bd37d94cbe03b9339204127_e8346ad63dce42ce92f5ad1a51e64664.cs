using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _5c095ac93bd37d94cbe03b9339204127_e8346ad63dce42ce92f5ad1a51e64664 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _5c095ac93bd37d94cbe03b9339204127_e8346ad63dce42ce92f5ad1a51e64664 FromInterop(IntPtr data, int dataSize)
		{
			return default(_5c095ac93bd37d94cbe03b9339204127_e8346ad63dce42ce92f5ad1a51e64664);
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

		public _5c095ac93bd37d94cbe03b9339204127_e8346ad63dce42ce92f5ad1a51e64664(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_5c095ac93bd37d94cbe03b9339204127_e8346ad63dce42ce92f5ad1a51e64664 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _5c095ac93bd37d94cbe03b9339204127_e8346ad63dce42ce92f5ad1a51e64664 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_5c095ac93bd37d94cbe03b9339204127_e8346ad63dce42ce92f5ad1a51e64664);
		}
	}
}
