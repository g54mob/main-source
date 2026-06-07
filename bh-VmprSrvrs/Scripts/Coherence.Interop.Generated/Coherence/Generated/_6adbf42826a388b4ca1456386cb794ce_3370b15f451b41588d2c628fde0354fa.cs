using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _6adbf42826a388b4ca1456386cb794ce_3370b15f451b41588d2c628fde0354fa : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _6adbf42826a388b4ca1456386cb794ce_3370b15f451b41588d2c628fde0354fa FromInterop(IntPtr data, int dataSize)
		{
			return default(_6adbf42826a388b4ca1456386cb794ce_3370b15f451b41588d2c628fde0354fa);
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

		public _6adbf42826a388b4ca1456386cb794ce_3370b15f451b41588d2c628fde0354fa(Entity entity, long startingSimFrame, Entity requestingPlayer)
		{
			this.startingSimFrame = 0L;
			this.requestingPlayer = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_6adbf42826a388b4ca1456386cb794ce_3370b15f451b41588d2c628fde0354fa commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _6adbf42826a388b4ca1456386cb794ce_3370b15f451b41588d2c628fde0354fa Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_6adbf42826a388b4ca1456386cb794ce_3370b15f451b41588d2c628fde0354fa);
		}
	}
}
