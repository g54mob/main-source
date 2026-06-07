using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _6adbf42826a388b4ca1456386cb794ce_49d83b2110724b1da8f0c7c15e53f8c2 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _6adbf42826a388b4ca1456386cb794ce_49d83b2110724b1da8f0c7c15e53f8c2 FromInterop(IntPtr data, int dataSize)
		{
			return default(_6adbf42826a388b4ca1456386cb794ce_49d83b2110724b1da8f0c7c15e53f8c2);
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

		public _6adbf42826a388b4ca1456386cb794ce_49d83b2110724b1da8f0c7c15e53f8c2(Entity entity, Entity requestingPlayer)
		{
			this.requestingPlayer = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_6adbf42826a388b4ca1456386cb794ce_49d83b2110724b1da8f0c7c15e53f8c2 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _6adbf42826a388b4ca1456386cb794ce_49d83b2110724b1da8f0c7c15e53f8c2 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_6adbf42826a388b4ca1456386cb794ce_49d83b2110724b1da8f0c7c15e53f8c2);
		}
	}
}
