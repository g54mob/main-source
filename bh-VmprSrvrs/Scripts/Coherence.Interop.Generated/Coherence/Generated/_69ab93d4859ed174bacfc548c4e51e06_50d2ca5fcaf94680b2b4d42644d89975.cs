using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _69ab93d4859ed174bacfc548c4e51e06_50d2ca5fcaf94680b2b4d42644d89975 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _69ab93d4859ed174bacfc548c4e51e06_50d2ca5fcaf94680b2b4d42644d89975 FromInterop(IntPtr data, int dataSize)
		{
			return default(_69ab93d4859ed174bacfc548c4e51e06_50d2ca5fcaf94680b2b4d42644d89975);
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

		public static void Serialize(_69ab93d4859ed174bacfc548c4e51e06_50d2ca5fcaf94680b2b4d42644d89975 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _69ab93d4859ed174bacfc548c4e51e06_50d2ca5fcaf94680b2b4d42644d89975 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_69ab93d4859ed174bacfc548c4e51e06_50d2ca5fcaf94680b2b4d42644d89975);
		}
	}
}
