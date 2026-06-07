using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _2f9d229f5eee61a47b023f17e42b9001_fe4b4562dcf44445ac3a90d222a46d92 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _2f9d229f5eee61a47b023f17e42b9001_fe4b4562dcf44445ac3a90d222a46d92 FromInterop(IntPtr data, int dataSize)
		{
			return default(_2f9d229f5eee61a47b023f17e42b9001_fe4b4562dcf44445ac3a90d222a46d92);
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

		public static void Serialize(_2f9d229f5eee61a47b023f17e42b9001_fe4b4562dcf44445ac3a90d222a46d92 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _2f9d229f5eee61a47b023f17e42b9001_fe4b4562dcf44445ac3a90d222a46d92 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_2f9d229f5eee61a47b023f17e42b9001_fe4b4562dcf44445ac3a90d222a46d92);
		}
	}
}
