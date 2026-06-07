using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _b69aa349718557648aaeeb4157595687_bda765a6df3147d696789bdd43176b88 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _b69aa349718557648aaeeb4157595687_bda765a6df3147d696789bdd43176b88 FromInterop(IntPtr data, int dataSize)
		{
			return default(_b69aa349718557648aaeeb4157595687_bda765a6df3147d696789bdd43176b88);
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

		public static void Serialize(_b69aa349718557648aaeeb4157595687_bda765a6df3147d696789bdd43176b88 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _b69aa349718557648aaeeb4157595687_bda765a6df3147d696789bdd43176b88 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_b69aa349718557648aaeeb4157595687_bda765a6df3147d696789bdd43176b88);
		}
	}
}
