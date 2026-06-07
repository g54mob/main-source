using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _553304c5f197d5d43b0145f3c53d7d03_20309307a0144758874a5467cfe792ac : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _553304c5f197d5d43b0145f3c53d7d03_20309307a0144758874a5467cfe792ac FromInterop(IntPtr data, int dataSize)
		{
			return default(_553304c5f197d5d43b0145f3c53d7d03_20309307a0144758874a5467cfe792ac);
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

		public static void Serialize(_553304c5f197d5d43b0145f3c53d7d03_20309307a0144758874a5467cfe792ac commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _553304c5f197d5d43b0145f3c53d7d03_20309307a0144758874a5467cfe792ac Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_553304c5f197d5d43b0145f3c53d7d03_20309307a0144758874a5467cfe792ac);
		}
	}
}
