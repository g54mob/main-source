using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _49890ed44d1bdf44096c0c292df0a92d_9b26327776da4b4eab4cb5b23b3fd48f : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _49890ed44d1bdf44096c0c292df0a92d_9b26327776da4b4eab4cb5b23b3fd48f FromInterop(IntPtr data, int dataSize)
		{
			return default(_49890ed44d1bdf44096c0c292df0a92d_9b26327776da4b4eab4cb5b23b3fd48f);
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

		public static void Serialize(_49890ed44d1bdf44096c0c292df0a92d_9b26327776da4b4eab4cb5b23b3fd48f commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _49890ed44d1bdf44096c0c292df0a92d_9b26327776da4b4eab4cb5b23b3fd48f Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_49890ed44d1bdf44096c0c292df0a92d_9b26327776da4b4eab4cb5b23b3fd48f);
		}
	}
}
