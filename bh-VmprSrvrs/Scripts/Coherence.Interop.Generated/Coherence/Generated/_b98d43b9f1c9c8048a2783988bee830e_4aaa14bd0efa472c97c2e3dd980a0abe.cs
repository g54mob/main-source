using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _b98d43b9f1c9c8048a2783988bee830e_4aaa14bd0efa472c97c2e3dd980a0abe : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _b98d43b9f1c9c8048a2783988bee830e_4aaa14bd0efa472c97c2e3dd980a0abe FromInterop(IntPtr data, int dataSize)
		{
			return default(_b98d43b9f1c9c8048a2783988bee830e_4aaa14bd0efa472c97c2e3dd980a0abe);
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

		public static void Serialize(_b98d43b9f1c9c8048a2783988bee830e_4aaa14bd0efa472c97c2e3dd980a0abe commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _b98d43b9f1c9c8048a2783988bee830e_4aaa14bd0efa472c97c2e3dd980a0abe Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_b98d43b9f1c9c8048a2783988bee830e_4aaa14bd0efa472c97c2e3dd980a0abe);
		}
	}
}
