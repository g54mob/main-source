using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _e033041743e63fb42aeeefaabbeb7a6e_36a23826e9b3446c84fc65cfc3cd072b : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public uint clientId;
		}

		public uint clientId;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _e033041743e63fb42aeeefaabbeb7a6e_36a23826e9b3446c84fc65cfc3cd072b FromInterop(IntPtr data, int dataSize)
		{
			return default(_e033041743e63fb42aeeefaabbeb7a6e_36a23826e9b3446c84fc65cfc3cd072b);
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

		public _e033041743e63fb42aeeefaabbeb7a6e_36a23826e9b3446c84fc65cfc3cd072b(Entity entity, uint clientId)
		{
			this.clientId = 0u;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_e033041743e63fb42aeeefaabbeb7a6e_36a23826e9b3446c84fc65cfc3cd072b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _e033041743e63fb42aeeefaabbeb7a6e_36a23826e9b3446c84fc65cfc3cd072b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_e033041743e63fb42aeeefaabbeb7a6e_36a23826e9b3446c84fc65cfc3cd072b);
		}
	}
}
