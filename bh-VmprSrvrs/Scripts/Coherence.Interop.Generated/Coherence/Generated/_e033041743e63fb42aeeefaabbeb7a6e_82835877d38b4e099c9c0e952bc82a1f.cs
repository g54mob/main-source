using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _e033041743e63fb42aeeefaabbeb7a6e_82835877d38b4e099c9c0e952bc82a1f : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _e033041743e63fb42aeeefaabbeb7a6e_82835877d38b4e099c9c0e952bc82a1f FromInterop(IntPtr data, int dataSize)
		{
			return default(_e033041743e63fb42aeeefaabbeb7a6e_82835877d38b4e099c9c0e952bc82a1f);
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

		public static void Serialize(_e033041743e63fb42aeeefaabbeb7a6e_82835877d38b4e099c9c0e952bc82a1f commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _e033041743e63fb42aeeefaabbeb7a6e_82835877d38b4e099c9c0e952bc82a1f Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_e033041743e63fb42aeeefaabbeb7a6e_82835877d38b4e099c9c0e952bc82a1f);
		}
	}
}
