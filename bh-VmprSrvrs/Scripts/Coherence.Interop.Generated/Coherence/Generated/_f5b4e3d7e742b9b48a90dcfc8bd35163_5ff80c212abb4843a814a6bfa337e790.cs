using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _f5b4e3d7e742b9b48a90dcfc8bd35163_5ff80c212abb4843a814a6bfa337e790 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _f5b4e3d7e742b9b48a90dcfc8bd35163_5ff80c212abb4843a814a6bfa337e790 FromInterop(IntPtr data, int dataSize)
		{
			return default(_f5b4e3d7e742b9b48a90dcfc8bd35163_5ff80c212abb4843a814a6bfa337e790);
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

		public static void Serialize(_f5b4e3d7e742b9b48a90dcfc8bd35163_5ff80c212abb4843a814a6bfa337e790 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _f5b4e3d7e742b9b48a90dcfc8bd35163_5ff80c212abb4843a814a6bfa337e790 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_f5b4e3d7e742b9b48a90dcfc8bd35163_5ff80c212abb4843a814a6bfa337e790);
		}
	}
}
