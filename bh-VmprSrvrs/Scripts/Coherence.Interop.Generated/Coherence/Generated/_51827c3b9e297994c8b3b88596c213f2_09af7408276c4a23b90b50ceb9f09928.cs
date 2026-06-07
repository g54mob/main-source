using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _51827c3b9e297994c8b3b88596c213f2_09af7408276c4a23b90b50ceb9f09928 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _51827c3b9e297994c8b3b88596c213f2_09af7408276c4a23b90b50ceb9f09928 FromInterop(IntPtr data, int dataSize)
		{
			return default(_51827c3b9e297994c8b3b88596c213f2_09af7408276c4a23b90b50ceb9f09928);
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

		public static void Serialize(_51827c3b9e297994c8b3b88596c213f2_09af7408276c4a23b90b50ceb9f09928 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _51827c3b9e297994c8b3b88596c213f2_09af7408276c4a23b90b50ceb9f09928 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_51827c3b9e297994c8b3b88596c213f2_09af7408276c4a23b90b50ceb9f09928);
		}
	}
}
