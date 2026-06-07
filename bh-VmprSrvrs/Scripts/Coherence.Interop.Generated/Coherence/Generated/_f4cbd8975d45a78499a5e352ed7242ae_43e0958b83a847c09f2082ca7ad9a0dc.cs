using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _f4cbd8975d45a78499a5e352ed7242ae_43e0958b83a847c09f2082ca7ad9a0dc : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public Entity player;
		}

		public long startingSimFrame;

		public Entity player;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _f4cbd8975d45a78499a5e352ed7242ae_43e0958b83a847c09f2082ca7ad9a0dc FromInterop(IntPtr data, int dataSize)
		{
			return default(_f4cbd8975d45a78499a5e352ed7242ae_43e0958b83a847c09f2082ca7ad9a0dc);
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

		public _f4cbd8975d45a78499a5e352ed7242ae_43e0958b83a847c09f2082ca7ad9a0dc(Entity entity, long startingSimFrame, Entity player)
		{
			this.startingSimFrame = 0L;
			this.player = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_f4cbd8975d45a78499a5e352ed7242ae_43e0958b83a847c09f2082ca7ad9a0dc commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _f4cbd8975d45a78499a5e352ed7242ae_43e0958b83a847c09f2082ca7ad9a0dc Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_f4cbd8975d45a78499a5e352ed7242ae_43e0958b83a847c09f2082ca7ad9a0dc);
		}
	}
}
