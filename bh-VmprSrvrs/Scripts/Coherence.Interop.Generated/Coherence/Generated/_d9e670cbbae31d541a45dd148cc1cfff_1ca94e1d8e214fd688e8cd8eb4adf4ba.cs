using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _d9e670cbbae31d541a45dd148cc1cfff_1ca94e1d8e214fd688e8cd8eb4adf4ba : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _d9e670cbbae31d541a45dd148cc1cfff_1ca94e1d8e214fd688e8cd8eb4adf4ba FromInterop(IntPtr data, int dataSize)
		{
			return default(_d9e670cbbae31d541a45dd148cc1cfff_1ca94e1d8e214fd688e8cd8eb4adf4ba);
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

		public _d9e670cbbae31d541a45dd148cc1cfff_1ca94e1d8e214fd688e8cd8eb4adf4ba(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_d9e670cbbae31d541a45dd148cc1cfff_1ca94e1d8e214fd688e8cd8eb4adf4ba commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _d9e670cbbae31d541a45dd148cc1cfff_1ca94e1d8e214fd688e8cd8eb4adf4ba Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_d9e670cbbae31d541a45dd148cc1cfff_1ca94e1d8e214fd688e8cd8eb4adf4ba);
		}
	}
}
