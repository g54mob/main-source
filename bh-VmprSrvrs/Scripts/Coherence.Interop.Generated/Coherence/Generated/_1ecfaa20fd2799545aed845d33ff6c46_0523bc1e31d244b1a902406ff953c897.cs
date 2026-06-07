using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _1ecfaa20fd2799545aed845d33ff6c46_0523bc1e31d244b1a902406ff953c897 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _1ecfaa20fd2799545aed845d33ff6c46_0523bc1e31d244b1a902406ff953c897 FromInterop(IntPtr data, int dataSize)
		{
			return default(_1ecfaa20fd2799545aed845d33ff6c46_0523bc1e31d244b1a902406ff953c897);
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

		public static void Serialize(_1ecfaa20fd2799545aed845d33ff6c46_0523bc1e31d244b1a902406ff953c897 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _1ecfaa20fd2799545aed845d33ff6c46_0523bc1e31d244b1a902406ff953c897 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_1ecfaa20fd2799545aed845d33ff6c46_0523bc1e31d244b1a902406ff953c897);
		}
	}
}
