using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a66f3e563634fb24ea9738112145366f_4724419d9c5c4ababce5befda38009dc : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _a66f3e563634fb24ea9738112145366f_4724419d9c5c4ababce5befda38009dc FromInterop(IntPtr data, int dataSize)
		{
			return default(_a66f3e563634fb24ea9738112145366f_4724419d9c5c4ababce5befda38009dc);
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

		public _a66f3e563634fb24ea9738112145366f_4724419d9c5c4ababce5befda38009dc(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_a66f3e563634fb24ea9738112145366f_4724419d9c5c4ababce5befda38009dc commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a66f3e563634fb24ea9738112145366f_4724419d9c5c4ababce5befda38009dc Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a66f3e563634fb24ea9738112145366f_4724419d9c5c4ababce5befda38009dc);
		}
	}
}
