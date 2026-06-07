using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _b85e1821d5c51c64bae206b6a8b601c1_aa81906bc76e47cbb837ac325fbb0c38 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _b85e1821d5c51c64bae206b6a8b601c1_aa81906bc76e47cbb837ac325fbb0c38 FromInterop(IntPtr data, int dataSize)
		{
			return default(_b85e1821d5c51c64bae206b6a8b601c1_aa81906bc76e47cbb837ac325fbb0c38);
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

		public static void Serialize(_b85e1821d5c51c64bae206b6a8b601c1_aa81906bc76e47cbb837ac325fbb0c38 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _b85e1821d5c51c64bae206b6a8b601c1_aa81906bc76e47cbb837ac325fbb0c38 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_b85e1821d5c51c64bae206b6a8b601c1_aa81906bc76e47cbb837ac325fbb0c38);
		}
	}
}
