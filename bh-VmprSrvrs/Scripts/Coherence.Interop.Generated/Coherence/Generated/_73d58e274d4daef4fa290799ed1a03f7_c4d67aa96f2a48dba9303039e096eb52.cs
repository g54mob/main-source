using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _73d58e274d4daef4fa290799ed1a03f7_c4d67aa96f2a48dba9303039e096eb52 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _73d58e274d4daef4fa290799ed1a03f7_c4d67aa96f2a48dba9303039e096eb52 FromInterop(IntPtr data, int dataSize)
		{
			return default(_73d58e274d4daef4fa290799ed1a03f7_c4d67aa96f2a48dba9303039e096eb52);
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

		public _73d58e274d4daef4fa290799ed1a03f7_c4d67aa96f2a48dba9303039e096eb52(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_73d58e274d4daef4fa290799ed1a03f7_c4d67aa96f2a48dba9303039e096eb52 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _73d58e274d4daef4fa290799ed1a03f7_c4d67aa96f2a48dba9303039e096eb52 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_73d58e274d4daef4fa290799ed1a03f7_c4d67aa96f2a48dba9303039e096eb52);
		}
	}
}
