using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _935395f70f9bc7d4fa614948272047da_a653a731c0224f08b2f93f927e76f547 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _935395f70f9bc7d4fa614948272047da_a653a731c0224f08b2f93f927e76f547 FromInterop(IntPtr data, int dataSize)
		{
			return default(_935395f70f9bc7d4fa614948272047da_a653a731c0224f08b2f93f927e76f547);
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

		public static void Serialize(_935395f70f9bc7d4fa614948272047da_a653a731c0224f08b2f93f927e76f547 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _935395f70f9bc7d4fa614948272047da_a653a731c0224f08b2f93f927e76f547 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_935395f70f9bc7d4fa614948272047da_a653a731c0224f08b2f93f927e76f547);
		}
	}
}
