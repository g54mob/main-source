using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _75af081d0fc96b74baf16470fe47390a_b0addca2ccd248d4ae5b1031f0c32313 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _75af081d0fc96b74baf16470fe47390a_b0addca2ccd248d4ae5b1031f0c32313 FromInterop(IntPtr data, int dataSize)
		{
			return default(_75af081d0fc96b74baf16470fe47390a_b0addca2ccd248d4ae5b1031f0c32313);
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

		public _75af081d0fc96b74baf16470fe47390a_b0addca2ccd248d4ae5b1031f0c32313(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_75af081d0fc96b74baf16470fe47390a_b0addca2ccd248d4ae5b1031f0c32313 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _75af081d0fc96b74baf16470fe47390a_b0addca2ccd248d4ae5b1031f0c32313 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_75af081d0fc96b74baf16470fe47390a_b0addca2ccd248d4ae5b1031f0c32313);
		}
	}
}
