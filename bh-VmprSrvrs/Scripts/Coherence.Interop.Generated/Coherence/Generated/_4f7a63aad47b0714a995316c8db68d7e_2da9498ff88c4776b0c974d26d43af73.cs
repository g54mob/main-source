using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _4f7a63aad47b0714a995316c8db68d7e_2da9498ff88c4776b0c974d26d43af73 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _4f7a63aad47b0714a995316c8db68d7e_2da9498ff88c4776b0c974d26d43af73 FromInterop(IntPtr data, int dataSize)
		{
			return default(_4f7a63aad47b0714a995316c8db68d7e_2da9498ff88c4776b0c974d26d43af73);
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

		public _4f7a63aad47b0714a995316c8db68d7e_2da9498ff88c4776b0c974d26d43af73(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_4f7a63aad47b0714a995316c8db68d7e_2da9498ff88c4776b0c974d26d43af73 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _4f7a63aad47b0714a995316c8db68d7e_2da9498ff88c4776b0c974d26d43af73 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_4f7a63aad47b0714a995316c8db68d7e_2da9498ff88c4776b0c974d26d43af73);
		}
	}
}
