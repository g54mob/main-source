using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _630fe76294bd55440b994747eda8b687_5f48a1cec5c64554a04bba0f1a8769d1 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _630fe76294bd55440b994747eda8b687_5f48a1cec5c64554a04bba0f1a8769d1 FromInterop(IntPtr data, int dataSize)
		{
			return default(_630fe76294bd55440b994747eda8b687_5f48a1cec5c64554a04bba0f1a8769d1);
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

		public static void Serialize(_630fe76294bd55440b994747eda8b687_5f48a1cec5c64554a04bba0f1a8769d1 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _630fe76294bd55440b994747eda8b687_5f48a1cec5c64554a04bba0f1a8769d1 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_630fe76294bd55440b994747eda8b687_5f48a1cec5c64554a04bba0f1a8769d1);
		}
	}
}
