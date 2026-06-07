using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _008f4af4477886447bb0655f28aeff14_3a12d1e7f6a04c3baff761724d92f266 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _008f4af4477886447bb0655f28aeff14_3a12d1e7f6a04c3baff761724d92f266 FromInterop(IntPtr data, int dataSize)
		{
			return default(_008f4af4477886447bb0655f28aeff14_3a12d1e7f6a04c3baff761724d92f266);
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

		public static void Serialize(_008f4af4477886447bb0655f28aeff14_3a12d1e7f6a04c3baff761724d92f266 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _008f4af4477886447bb0655f28aeff14_3a12d1e7f6a04c3baff761724d92f266 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_008f4af4477886447bb0655f28aeff14_3a12d1e7f6a04c3baff761724d92f266);
		}
	}
}
