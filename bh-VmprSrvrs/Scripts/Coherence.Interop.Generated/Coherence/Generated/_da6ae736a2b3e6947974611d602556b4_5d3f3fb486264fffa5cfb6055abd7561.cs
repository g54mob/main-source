using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _da6ae736a2b3e6947974611d602556b4_5d3f3fb486264fffa5cfb6055abd7561 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _da6ae736a2b3e6947974611d602556b4_5d3f3fb486264fffa5cfb6055abd7561 FromInterop(IntPtr data, int dataSize)
		{
			return default(_da6ae736a2b3e6947974611d602556b4_5d3f3fb486264fffa5cfb6055abd7561);
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

		public static void Serialize(_da6ae736a2b3e6947974611d602556b4_5d3f3fb486264fffa5cfb6055abd7561 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _da6ae736a2b3e6947974611d602556b4_5d3f3fb486264fffa5cfb6055abd7561 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_da6ae736a2b3e6947974611d602556b4_5d3f3fb486264fffa5cfb6055abd7561);
		}
	}
}
