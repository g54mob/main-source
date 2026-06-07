using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a66f3e563634fb24ea9738112145366f_3f2f5f0a0ae04378a19679f63d0cde8a : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _a66f3e563634fb24ea9738112145366f_3f2f5f0a0ae04378a19679f63d0cde8a FromInterop(IntPtr data, int dataSize)
		{
			return default(_a66f3e563634fb24ea9738112145366f_3f2f5f0a0ae04378a19679f63d0cde8a);
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

		public static void Serialize(_a66f3e563634fb24ea9738112145366f_3f2f5f0a0ae04378a19679f63d0cde8a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a66f3e563634fb24ea9738112145366f_3f2f5f0a0ae04378a19679f63d0cde8a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a66f3e563634fb24ea9738112145366f_3f2f5f0a0ae04378a19679f63d0cde8a);
		}
	}
}
