using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _c22c3fd5d45b3b642b2f24482a1ca643_0bc82414ffae4ea4a03449efce0ab6ca : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public byte eraseItems;

			[FieldOffset(1)]
			public byte skipTriggers;
		}

		public bool eraseItems;

		public bool skipTriggers;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _c22c3fd5d45b3b642b2f24482a1ca643_0bc82414ffae4ea4a03449efce0ab6ca FromInterop(IntPtr data, int dataSize)
		{
			return default(_c22c3fd5d45b3b642b2f24482a1ca643_0bc82414ffae4ea4a03449efce0ab6ca);
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

		public _c22c3fd5d45b3b642b2f24482a1ca643_0bc82414ffae4ea4a03449efce0ab6ca(Entity entity, bool eraseItems, bool skipTriggers)
		{
			this.eraseItems = false;
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_c22c3fd5d45b3b642b2f24482a1ca643_0bc82414ffae4ea4a03449efce0ab6ca commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _c22c3fd5d45b3b642b2f24482a1ca643_0bc82414ffae4ea4a03449efce0ab6ca Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_c22c3fd5d45b3b642b2f24482a1ca643_0bc82414ffae4ea4a03449efce0ab6ca);
		}
	}
}
