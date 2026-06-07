using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _650fd14cc5732be4e9ed054245597183_47cf6366933645faa5b687ed272c680a : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _650fd14cc5732be4e9ed054245597183_47cf6366933645faa5b687ed272c680a FromInterop(IntPtr data, int dataSize)
		{
			return default(_650fd14cc5732be4e9ed054245597183_47cf6366933645faa5b687ed272c680a);
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

		public static void Serialize(_650fd14cc5732be4e9ed054245597183_47cf6366933645faa5b687ed272c680a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _650fd14cc5732be4e9ed054245597183_47cf6366933645faa5b687ed272c680a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_650fd14cc5732be4e9ed054245597183_47cf6366933645faa5b687ed272c680a);
		}
	}
}
