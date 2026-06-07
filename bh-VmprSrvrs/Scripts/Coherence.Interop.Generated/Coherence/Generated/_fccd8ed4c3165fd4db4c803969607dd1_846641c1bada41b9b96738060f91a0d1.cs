using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _fccd8ed4c3165fd4db4c803969607dd1_846641c1bada41b9b96738060f91a0d1 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _fccd8ed4c3165fd4db4c803969607dd1_846641c1bada41b9b96738060f91a0d1 FromInterop(IntPtr data, int dataSize)
		{
			return default(_fccd8ed4c3165fd4db4c803969607dd1_846641c1bada41b9b96738060f91a0d1);
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

		public static void Serialize(_fccd8ed4c3165fd4db4c803969607dd1_846641c1bada41b9b96738060f91a0d1 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _fccd8ed4c3165fd4db4c803969607dd1_846641c1bada41b9b96738060f91a0d1 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_fccd8ed4c3165fd4db4c803969607dd1_846641c1bada41b9b96738060f91a0d1);
		}
	}
}
