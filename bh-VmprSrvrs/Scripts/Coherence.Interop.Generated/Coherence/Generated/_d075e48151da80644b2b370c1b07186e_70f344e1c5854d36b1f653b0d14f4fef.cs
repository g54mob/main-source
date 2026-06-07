using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _d075e48151da80644b2b370c1b07186e_70f344e1c5854d36b1f653b0d14f4fef : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _d075e48151da80644b2b370c1b07186e_70f344e1c5854d36b1f653b0d14f4fef FromInterop(IntPtr data, int dataSize)
		{
			return default(_d075e48151da80644b2b370c1b07186e_70f344e1c5854d36b1f653b0d14f4fef);
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

		public static void Serialize(_d075e48151da80644b2b370c1b07186e_70f344e1c5854d36b1f653b0d14f4fef commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _d075e48151da80644b2b370c1b07186e_70f344e1c5854d36b1f653b0d14f4fef Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_d075e48151da80644b2b370c1b07186e_70f344e1c5854d36b1f653b0d14f4fef);
		}
	}
}
