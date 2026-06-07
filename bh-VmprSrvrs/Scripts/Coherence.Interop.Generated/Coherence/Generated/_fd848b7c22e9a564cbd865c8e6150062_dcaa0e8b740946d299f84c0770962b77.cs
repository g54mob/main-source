using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _fd848b7c22e9a564cbd865c8e6150062_dcaa0e8b740946d299f84c0770962b77 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _fd848b7c22e9a564cbd865c8e6150062_dcaa0e8b740946d299f84c0770962b77 FromInterop(IntPtr data, int dataSize)
		{
			return default(_fd848b7c22e9a564cbd865c8e6150062_dcaa0e8b740946d299f84c0770962b77);
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

		public static void Serialize(_fd848b7c22e9a564cbd865c8e6150062_dcaa0e8b740946d299f84c0770962b77 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _fd848b7c22e9a564cbd865c8e6150062_dcaa0e8b740946d299f84c0770962b77 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_fd848b7c22e9a564cbd865c8e6150062_dcaa0e8b740946d299f84c0770962b77);
		}
	}
}
