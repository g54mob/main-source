using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ecd2d48a841ddd446813c48b3fbcfa19_500a2ac3c9194e33bb60095252d75446 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _ecd2d48a841ddd446813c48b3fbcfa19_500a2ac3c9194e33bb60095252d75446 FromInterop(IntPtr data, int dataSize)
		{
			return default(_ecd2d48a841ddd446813c48b3fbcfa19_500a2ac3c9194e33bb60095252d75446);
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

		public static void Serialize(_ecd2d48a841ddd446813c48b3fbcfa19_500a2ac3c9194e33bb60095252d75446 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ecd2d48a841ddd446813c48b3fbcfa19_500a2ac3c9194e33bb60095252d75446 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ecd2d48a841ddd446813c48b3fbcfa19_500a2ac3c9194e33bb60095252d75446);
		}
	}
}
