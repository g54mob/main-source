using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _20976c99945ba92458236101a7c5aafd_a4431b9820d04c1db7c2e0ffc5d09d14 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _20976c99945ba92458236101a7c5aafd_a4431b9820d04c1db7c2e0ffc5d09d14 FromInterop(IntPtr data, int dataSize)
		{
			return default(_20976c99945ba92458236101a7c5aafd_a4431b9820d04c1db7c2e0ffc5d09d14);
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

		public static void Serialize(_20976c99945ba92458236101a7c5aafd_a4431b9820d04c1db7c2e0ffc5d09d14 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _20976c99945ba92458236101a7c5aafd_a4431b9820d04c1db7c2e0ffc5d09d14 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_20976c99945ba92458236101a7c5aafd_a4431b9820d04c1db7c2e0ffc5d09d14);
		}
	}
}
