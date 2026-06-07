using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a42f156792f891e4186ebc6d96ec8f5f_f9601f45b956409daf9cf41d59942a8f : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _a42f156792f891e4186ebc6d96ec8f5f_f9601f45b956409daf9cf41d59942a8f FromInterop(IntPtr data, int dataSize)
		{
			return default(_a42f156792f891e4186ebc6d96ec8f5f_f9601f45b956409daf9cf41d59942a8f);
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

		public static void Serialize(_a42f156792f891e4186ebc6d96ec8f5f_f9601f45b956409daf9cf41d59942a8f commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a42f156792f891e4186ebc6d96ec8f5f_f9601f45b956409daf9cf41d59942a8f Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a42f156792f891e4186ebc6d96ec8f5f_f9601f45b956409daf9cf41d59942a8f);
		}
	}
}
