using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _86fed05d1d130f6418432c5115236ad3_37816fce1ca342439f497660e016beb7 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _86fed05d1d130f6418432c5115236ad3_37816fce1ca342439f497660e016beb7 FromInterop(IntPtr data, int dataSize)
		{
			return default(_86fed05d1d130f6418432c5115236ad3_37816fce1ca342439f497660e016beb7);
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

		public static void Serialize(_86fed05d1d130f6418432c5115236ad3_37816fce1ca342439f497660e016beb7 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _86fed05d1d130f6418432c5115236ad3_37816fce1ca342439f497660e016beb7 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_86fed05d1d130f6418432c5115236ad3_37816fce1ca342439f497660e016beb7);
		}
	}
}
