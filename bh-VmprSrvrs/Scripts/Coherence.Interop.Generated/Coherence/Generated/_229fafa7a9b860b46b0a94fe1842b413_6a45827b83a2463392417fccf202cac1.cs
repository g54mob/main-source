using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _229fafa7a9b860b46b0a94fe1842b413_6a45827b83a2463392417fccf202cac1 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _229fafa7a9b860b46b0a94fe1842b413_6a45827b83a2463392417fccf202cac1 FromInterop(IntPtr data, int dataSize)
		{
			return default(_229fafa7a9b860b46b0a94fe1842b413_6a45827b83a2463392417fccf202cac1);
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

		public static void Serialize(_229fafa7a9b860b46b0a94fe1842b413_6a45827b83a2463392417fccf202cac1 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _229fafa7a9b860b46b0a94fe1842b413_6a45827b83a2463392417fccf202cac1 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_229fafa7a9b860b46b0a94fe1842b413_6a45827b83a2463392417fccf202cac1);
		}
	}
}
