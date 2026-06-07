using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _82037ad5be0af844f97d234ba5248672_70049ecaceb7475cbedf9c59ea90589c : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _82037ad5be0af844f97d234ba5248672_70049ecaceb7475cbedf9c59ea90589c FromInterop(IntPtr data, int dataSize)
		{
			return default(_82037ad5be0af844f97d234ba5248672_70049ecaceb7475cbedf9c59ea90589c);
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

		public static void Serialize(_82037ad5be0af844f97d234ba5248672_70049ecaceb7475cbedf9c59ea90589c commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _82037ad5be0af844f97d234ba5248672_70049ecaceb7475cbedf9c59ea90589c Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_82037ad5be0af844f97d234ba5248672_70049ecaceb7475cbedf9c59ea90589c);
		}
	}
}
