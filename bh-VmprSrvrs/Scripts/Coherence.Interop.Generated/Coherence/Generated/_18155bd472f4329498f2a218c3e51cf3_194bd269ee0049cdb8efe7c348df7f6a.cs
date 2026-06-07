using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _18155bd472f4329498f2a218c3e51cf3_194bd269ee0049cdb8efe7c348df7f6a : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _18155bd472f4329498f2a218c3e51cf3_194bd269ee0049cdb8efe7c348df7f6a FromInterop(IntPtr data, int dataSize)
		{
			return default(_18155bd472f4329498f2a218c3e51cf3_194bd269ee0049cdb8efe7c348df7f6a);
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

		public static void Serialize(_18155bd472f4329498f2a218c3e51cf3_194bd269ee0049cdb8efe7c348df7f6a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _18155bd472f4329498f2a218c3e51cf3_194bd269ee0049cdb8efe7c348df7f6a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_18155bd472f4329498f2a218c3e51cf3_194bd269ee0049cdb8efe7c348df7f6a);
		}
	}
}
