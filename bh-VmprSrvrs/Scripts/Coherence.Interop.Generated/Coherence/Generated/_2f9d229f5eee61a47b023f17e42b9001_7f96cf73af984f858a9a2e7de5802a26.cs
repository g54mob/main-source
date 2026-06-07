using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _2f9d229f5eee61a47b023f17e42b9001_7f96cf73af984f858a9a2e7de5802a26 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public Entity requestingPlayer;
		}

		public Entity requestingPlayer;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _2f9d229f5eee61a47b023f17e42b9001_7f96cf73af984f858a9a2e7de5802a26 FromInterop(IntPtr data, int dataSize)
		{
			return default(_2f9d229f5eee61a47b023f17e42b9001_7f96cf73af984f858a9a2e7de5802a26);
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

		public _2f9d229f5eee61a47b023f17e42b9001_7f96cf73af984f858a9a2e7de5802a26(Entity entity, Entity requestingPlayer)
		{
			this.requestingPlayer = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_2f9d229f5eee61a47b023f17e42b9001_7f96cf73af984f858a9a2e7de5802a26 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _2f9d229f5eee61a47b023f17e42b9001_7f96cf73af984f858a9a2e7de5802a26 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_2f9d229f5eee61a47b023f17e42b9001_7f96cf73af984f858a9a2e7de5802a26);
		}
	}
}
