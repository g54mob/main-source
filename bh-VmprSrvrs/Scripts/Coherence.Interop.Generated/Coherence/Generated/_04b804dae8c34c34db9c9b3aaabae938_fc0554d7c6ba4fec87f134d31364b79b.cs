using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _04b804dae8c34c34db9c9b3aaabae938_fc0554d7c6ba4fec87f134d31364b79b : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _04b804dae8c34c34db9c9b3aaabae938_fc0554d7c6ba4fec87f134d31364b79b FromInterop(IntPtr data, int dataSize)
		{
			return default(_04b804dae8c34c34db9c9b3aaabae938_fc0554d7c6ba4fec87f134d31364b79b);
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

		public static void Serialize(_04b804dae8c34c34db9c9b3aaabae938_fc0554d7c6ba4fec87f134d31364b79b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _04b804dae8c34c34db9c9b3aaabae938_fc0554d7c6ba4fec87f134d31364b79b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_04b804dae8c34c34db9c9b3aaabae938_fc0554d7c6ba4fec87f134d31364b79b);
		}
	}
}
