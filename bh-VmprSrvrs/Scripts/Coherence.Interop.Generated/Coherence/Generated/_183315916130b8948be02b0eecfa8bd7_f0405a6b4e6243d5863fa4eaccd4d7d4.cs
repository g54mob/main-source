using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _183315916130b8948be02b0eecfa8bd7_f0405a6b4e6243d5863fa4eaccd4d7d4 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _183315916130b8948be02b0eecfa8bd7_f0405a6b4e6243d5863fa4eaccd4d7d4 FromInterop(IntPtr data, int dataSize)
		{
			return default(_183315916130b8948be02b0eecfa8bd7_f0405a6b4e6243d5863fa4eaccd4d7d4);
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

		public static void Serialize(_183315916130b8948be02b0eecfa8bd7_f0405a6b4e6243d5863fa4eaccd4d7d4 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _183315916130b8948be02b0eecfa8bd7_f0405a6b4e6243d5863fa4eaccd4d7d4 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_183315916130b8948be02b0eecfa8bd7_f0405a6b4e6243d5863fa4eaccd4d7d4);
		}
	}
}
