using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _2e752b2d75b3fb0409ac1c6f0166bc09_b86a0d5f92bf48e388e1e22f4999afb2 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _2e752b2d75b3fb0409ac1c6f0166bc09_b86a0d5f92bf48e388e1e22f4999afb2 FromInterop(IntPtr data, int dataSize)
		{
			return default(_2e752b2d75b3fb0409ac1c6f0166bc09_b86a0d5f92bf48e388e1e22f4999afb2);
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

		public _2e752b2d75b3fb0409ac1c6f0166bc09_b86a0d5f92bf48e388e1e22f4999afb2(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_2e752b2d75b3fb0409ac1c6f0166bc09_b86a0d5f92bf48e388e1e22f4999afb2 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _2e752b2d75b3fb0409ac1c6f0166bc09_b86a0d5f92bf48e388e1e22f4999afb2 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_2e752b2d75b3fb0409ac1c6f0166bc09_b86a0d5f92bf48e388e1e22f4999afb2);
		}
	}
}
