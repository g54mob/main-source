using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _d21a81e38bc5e7c40bc75a117a774677_5ecc66b45b9a45988e28b6579b4656c8 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _d21a81e38bc5e7c40bc75a117a774677_5ecc66b45b9a45988e28b6579b4656c8 FromInterop(IntPtr data, int dataSize)
		{
			return default(_d21a81e38bc5e7c40bc75a117a774677_5ecc66b45b9a45988e28b6579b4656c8);
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

		public static void Serialize(_d21a81e38bc5e7c40bc75a117a774677_5ecc66b45b9a45988e28b6579b4656c8 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _d21a81e38bc5e7c40bc75a117a774677_5ecc66b45b9a45988e28b6579b4656c8 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_d21a81e38bc5e7c40bc75a117a774677_5ecc66b45b9a45988e28b6579b4656c8);
		}
	}
}
