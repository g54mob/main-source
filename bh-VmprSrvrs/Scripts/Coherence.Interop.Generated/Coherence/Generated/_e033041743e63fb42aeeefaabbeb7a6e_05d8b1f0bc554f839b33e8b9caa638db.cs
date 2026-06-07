using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _e033041743e63fb42aeeefaabbeb7a6e_05d8b1f0bc554f839b33e8b9caa638db : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _e033041743e63fb42aeeefaabbeb7a6e_05d8b1f0bc554f839b33e8b9caa638db FromInterop(IntPtr data, int dataSize)
		{
			return default(_e033041743e63fb42aeeefaabbeb7a6e_05d8b1f0bc554f839b33e8b9caa638db);
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

		public _e033041743e63fb42aeeefaabbeb7a6e_05d8b1f0bc554f839b33e8b9caa638db(Entity entity, Entity requestingPlayer)
		{
			this.requestingPlayer = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_e033041743e63fb42aeeefaabbeb7a6e_05d8b1f0bc554f839b33e8b9caa638db commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _e033041743e63fb42aeeefaabbeb7a6e_05d8b1f0bc554f839b33e8b9caa638db Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_e033041743e63fb42aeeefaabbeb7a6e_05d8b1f0bc554f839b33e8b9caa638db);
		}
	}
}
