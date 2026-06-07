using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _2a31e0301435c174b8ca614b5621f932_9af7c39609594eeba04b51c38d0889be : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingClientFrame;
		}

		public long startingClientFrame;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _2a31e0301435c174b8ca614b5621f932_9af7c39609594eeba04b51c38d0889be FromInterop(IntPtr data, int dataSize)
		{
			return default(_2a31e0301435c174b8ca614b5621f932_9af7c39609594eeba04b51c38d0889be);
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

		public _2a31e0301435c174b8ca614b5621f932_9af7c39609594eeba04b51c38d0889be(Entity entity, long startingClientFrame)
		{
			this.startingClientFrame = 0L;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_2a31e0301435c174b8ca614b5621f932_9af7c39609594eeba04b51c38d0889be commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _2a31e0301435c174b8ca614b5621f932_9af7c39609594eeba04b51c38d0889be Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_2a31e0301435c174b8ca614b5621f932_9af7c39609594eeba04b51c38d0889be);
		}
	}
}
