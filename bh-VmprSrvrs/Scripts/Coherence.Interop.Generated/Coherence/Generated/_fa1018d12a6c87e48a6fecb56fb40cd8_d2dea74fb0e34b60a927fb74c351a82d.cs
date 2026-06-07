using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _fa1018d12a6c87e48a6fecb56fb40cd8_d2dea74fb0e34b60a927fb74c351a82d : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _fa1018d12a6c87e48a6fecb56fb40cd8_d2dea74fb0e34b60a927fb74c351a82d FromInterop(IntPtr data, int dataSize)
		{
			return default(_fa1018d12a6c87e48a6fecb56fb40cd8_d2dea74fb0e34b60a927fb74c351a82d);
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

		public static void Serialize(_fa1018d12a6c87e48a6fecb56fb40cd8_d2dea74fb0e34b60a927fb74c351a82d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _fa1018d12a6c87e48a6fecb56fb40cd8_d2dea74fb0e34b60a927fb74c351a82d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_fa1018d12a6c87e48a6fecb56fb40cd8_d2dea74fb0e34b60a927fb74c351a82d);
		}
	}
}
