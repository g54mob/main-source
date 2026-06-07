using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _e98f6f46022503a4992e6fd7e6cadfd6_45a5c1c535db44b7ac1d0a35e05accc9 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public Entity requestingPlayer;
		}

		public long startingSimFrame;

		public Entity requestingPlayer;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _e98f6f46022503a4992e6fd7e6cadfd6_45a5c1c535db44b7ac1d0a35e05accc9 FromInterop(IntPtr data, int dataSize)
		{
			return default(_e98f6f46022503a4992e6fd7e6cadfd6_45a5c1c535db44b7ac1d0a35e05accc9);
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

		public _e98f6f46022503a4992e6fd7e6cadfd6_45a5c1c535db44b7ac1d0a35e05accc9(Entity entity, long startingSimFrame, Entity requestingPlayer)
		{
			this.startingSimFrame = 0L;
			this.requestingPlayer = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_e98f6f46022503a4992e6fd7e6cadfd6_45a5c1c535db44b7ac1d0a35e05accc9 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _e98f6f46022503a4992e6fd7e6cadfd6_45a5c1c535db44b7ac1d0a35e05accc9 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_e98f6f46022503a4992e6fd7e6cadfd6_45a5c1c535db44b7ac1d0a35e05accc9);
		}
	}
}
