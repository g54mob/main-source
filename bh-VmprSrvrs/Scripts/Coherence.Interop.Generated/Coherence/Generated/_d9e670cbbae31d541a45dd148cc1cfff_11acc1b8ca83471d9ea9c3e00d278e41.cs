using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _d9e670cbbae31d541a45dd148cc1cfff_11acc1b8ca83471d9ea9c3e00d278e41 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _d9e670cbbae31d541a45dd148cc1cfff_11acc1b8ca83471d9ea9c3e00d278e41 FromInterop(IntPtr data, int dataSize)
		{
			return default(_d9e670cbbae31d541a45dd148cc1cfff_11acc1b8ca83471d9ea9c3e00d278e41);
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

		public _d9e670cbbae31d541a45dd148cc1cfff_11acc1b8ca83471d9ea9c3e00d278e41(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_d9e670cbbae31d541a45dd148cc1cfff_11acc1b8ca83471d9ea9c3e00d278e41 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _d9e670cbbae31d541a45dd148cc1cfff_11acc1b8ca83471d9ea9c3e00d278e41 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_d9e670cbbae31d541a45dd148cc1cfff_11acc1b8ca83471d9ea9c3e00d278e41);
		}
	}
}
