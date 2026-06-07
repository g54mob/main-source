using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _49890ed44d1bdf44096c0c292df0a92d_fc2c473b359a4da18a695be722db80f6 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _49890ed44d1bdf44096c0c292df0a92d_fc2c473b359a4da18a695be722db80f6 FromInterop(IntPtr data, int dataSize)
		{
			return default(_49890ed44d1bdf44096c0c292df0a92d_fc2c473b359a4da18a695be722db80f6);
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

		public _49890ed44d1bdf44096c0c292df0a92d_fc2c473b359a4da18a695be722db80f6(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_49890ed44d1bdf44096c0c292df0a92d_fc2c473b359a4da18a695be722db80f6 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _49890ed44d1bdf44096c0c292df0a92d_fc2c473b359a4da18a695be722db80f6 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_49890ed44d1bdf44096c0c292df0a92d_fc2c473b359a4da18a695be722db80f6);
		}
	}
}
