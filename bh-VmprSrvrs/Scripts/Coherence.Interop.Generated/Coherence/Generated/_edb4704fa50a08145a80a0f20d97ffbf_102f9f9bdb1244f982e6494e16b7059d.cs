using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _edb4704fa50a08145a80a0f20d97ffbf_102f9f9bdb1244f982e6494e16b7059d : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _edb4704fa50a08145a80a0f20d97ffbf_102f9f9bdb1244f982e6494e16b7059d FromInterop(IntPtr data, int dataSize)
		{
			return default(_edb4704fa50a08145a80a0f20d97ffbf_102f9f9bdb1244f982e6494e16b7059d);
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

		public static void Serialize(_edb4704fa50a08145a80a0f20d97ffbf_102f9f9bdb1244f982e6494e16b7059d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _edb4704fa50a08145a80a0f20d97ffbf_102f9f9bdb1244f982e6494e16b7059d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_edb4704fa50a08145a80a0f20d97ffbf_102f9f9bdb1244f982e6494e16b7059d);
		}
	}
}
