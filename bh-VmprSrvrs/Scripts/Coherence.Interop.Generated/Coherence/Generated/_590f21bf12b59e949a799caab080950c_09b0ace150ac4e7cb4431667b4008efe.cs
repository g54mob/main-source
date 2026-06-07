using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _590f21bf12b59e949a799caab080950c_09b0ace150ac4e7cb4431667b4008efe : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _590f21bf12b59e949a799caab080950c_09b0ace150ac4e7cb4431667b4008efe FromInterop(IntPtr data, int dataSize)
		{
			return default(_590f21bf12b59e949a799caab080950c_09b0ace150ac4e7cb4431667b4008efe);
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

		public static void Serialize(_590f21bf12b59e949a799caab080950c_09b0ace150ac4e7cb4431667b4008efe commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _590f21bf12b59e949a799caab080950c_09b0ace150ac4e7cb4431667b4008efe Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_590f21bf12b59e949a799caab080950c_09b0ace150ac4e7cb4431667b4008efe);
		}
	}
}
