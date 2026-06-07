using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _16bf351edf119914781e4a6b9d3b7920_db4d14448fcd42cebd2bb64b316e1112 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _16bf351edf119914781e4a6b9d3b7920_db4d14448fcd42cebd2bb64b316e1112 FromInterop(IntPtr data, int dataSize)
		{
			return default(_16bf351edf119914781e4a6b9d3b7920_db4d14448fcd42cebd2bb64b316e1112);
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

		public static void Serialize(_16bf351edf119914781e4a6b9d3b7920_db4d14448fcd42cebd2bb64b316e1112 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _16bf351edf119914781e4a6b9d3b7920_db4d14448fcd42cebd2bb64b316e1112 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_16bf351edf119914781e4a6b9d3b7920_db4d14448fcd42cebd2bb64b316e1112);
		}
	}
}
