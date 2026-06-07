using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _0dea4d311a8ad4f47a1ed47e23e15854_1f12f143d189482d918596459e607998 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _0dea4d311a8ad4f47a1ed47e23e15854_1f12f143d189482d918596459e607998 FromInterop(IntPtr data, int dataSize)
		{
			return default(_0dea4d311a8ad4f47a1ed47e23e15854_1f12f143d189482d918596459e607998);
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

		public _0dea4d311a8ad4f47a1ed47e23e15854_1f12f143d189482d918596459e607998(Entity entity, long startingSimFrame, Entity requestingPlayer)
		{
			this.startingSimFrame = 0L;
			this.requestingPlayer = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_0dea4d311a8ad4f47a1ed47e23e15854_1f12f143d189482d918596459e607998 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _0dea4d311a8ad4f47a1ed47e23e15854_1f12f143d189482d918596459e607998 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_0dea4d311a8ad4f47a1ed47e23e15854_1f12f143d189482d918596459e607998);
		}
	}
}
