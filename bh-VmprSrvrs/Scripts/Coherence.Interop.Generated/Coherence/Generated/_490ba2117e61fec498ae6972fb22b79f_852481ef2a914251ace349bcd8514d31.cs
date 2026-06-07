using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _490ba2117e61fec498ae6972fb22b79f_852481ef2a914251ace349bcd8514d31 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _490ba2117e61fec498ae6972fb22b79f_852481ef2a914251ace349bcd8514d31 FromInterop(IntPtr data, int dataSize)
		{
			return default(_490ba2117e61fec498ae6972fb22b79f_852481ef2a914251ace349bcd8514d31);
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

		public static void Serialize(_490ba2117e61fec498ae6972fb22b79f_852481ef2a914251ace349bcd8514d31 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _490ba2117e61fec498ae6972fb22b79f_852481ef2a914251ace349bcd8514d31 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_490ba2117e61fec498ae6972fb22b79f_852481ef2a914251ace349bcd8514d31);
		}
	}
}
