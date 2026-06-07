using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _d42d8caef0b99ac4ca8bd2f2af06e044_e40ff87aebb348909866bafe486596b3 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _d42d8caef0b99ac4ca8bd2f2af06e044_e40ff87aebb348909866bafe486596b3 FromInterop(IntPtr data, int dataSize)
		{
			return default(_d42d8caef0b99ac4ca8bd2f2af06e044_e40ff87aebb348909866bafe486596b3);
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

		public static void Serialize(_d42d8caef0b99ac4ca8bd2f2af06e044_e40ff87aebb348909866bafe486596b3 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _d42d8caef0b99ac4ca8bd2f2af06e044_e40ff87aebb348909866bafe486596b3 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_d42d8caef0b99ac4ca8bd2f2af06e044_e40ff87aebb348909866bafe486596b3);
		}
	}
}
