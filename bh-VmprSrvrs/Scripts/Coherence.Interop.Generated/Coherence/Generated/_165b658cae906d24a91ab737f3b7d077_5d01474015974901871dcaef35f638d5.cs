using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _165b658cae906d24a91ab737f3b7d077_5d01474015974901871dcaef35f638d5 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _165b658cae906d24a91ab737f3b7d077_5d01474015974901871dcaef35f638d5 FromInterop(IntPtr data, int dataSize)
		{
			return default(_165b658cae906d24a91ab737f3b7d077_5d01474015974901871dcaef35f638d5);
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

		public static void Serialize(_165b658cae906d24a91ab737f3b7d077_5d01474015974901871dcaef35f638d5 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _165b658cae906d24a91ab737f3b7d077_5d01474015974901871dcaef35f638d5 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_165b658cae906d24a91ab737f3b7d077_5d01474015974901871dcaef35f638d5);
		}
	}
}
