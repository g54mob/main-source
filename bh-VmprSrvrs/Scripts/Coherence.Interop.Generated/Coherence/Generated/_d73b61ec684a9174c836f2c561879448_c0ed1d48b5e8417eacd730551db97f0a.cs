using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _d73b61ec684a9174c836f2c561879448_c0ed1d48b5e8417eacd730551db97f0a : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _d73b61ec684a9174c836f2c561879448_c0ed1d48b5e8417eacd730551db97f0a FromInterop(IntPtr data, int dataSize)
		{
			return default(_d73b61ec684a9174c836f2c561879448_c0ed1d48b5e8417eacd730551db97f0a);
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

		public static void Serialize(_d73b61ec684a9174c836f2c561879448_c0ed1d48b5e8417eacd730551db97f0a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _d73b61ec684a9174c836f2c561879448_c0ed1d48b5e8417eacd730551db97f0a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_d73b61ec684a9174c836f2c561879448_c0ed1d48b5e8417eacd730551db97f0a);
		}
	}
}
