using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _2c659baa7410e504da9d160a2df38626_85cd7893efe74b9bbe2160d2eed957e2 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _2c659baa7410e504da9d160a2df38626_85cd7893efe74b9bbe2160d2eed957e2 FromInterop(IntPtr data, int dataSize)
		{
			return default(_2c659baa7410e504da9d160a2df38626_85cd7893efe74b9bbe2160d2eed957e2);
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

		public static void Serialize(_2c659baa7410e504da9d160a2df38626_85cd7893efe74b9bbe2160d2eed957e2 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _2c659baa7410e504da9d160a2df38626_85cd7893efe74b9bbe2160d2eed957e2 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_2c659baa7410e504da9d160a2df38626_85cd7893efe74b9bbe2160d2eed957e2);
		}
	}
}
