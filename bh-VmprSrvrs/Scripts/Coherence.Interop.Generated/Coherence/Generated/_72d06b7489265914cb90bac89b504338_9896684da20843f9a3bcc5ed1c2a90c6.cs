using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _72d06b7489265914cb90bac89b504338_9896684da20843f9a3bcc5ed1c2a90c6 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _72d06b7489265914cb90bac89b504338_9896684da20843f9a3bcc5ed1c2a90c6 FromInterop(IntPtr data, int dataSize)
		{
			return default(_72d06b7489265914cb90bac89b504338_9896684da20843f9a3bcc5ed1c2a90c6);
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

		public static void Serialize(_72d06b7489265914cb90bac89b504338_9896684da20843f9a3bcc5ed1c2a90c6 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _72d06b7489265914cb90bac89b504338_9896684da20843f9a3bcc5ed1c2a90c6 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_72d06b7489265914cb90bac89b504338_9896684da20843f9a3bcc5ed1c2a90c6);
		}
	}
}
