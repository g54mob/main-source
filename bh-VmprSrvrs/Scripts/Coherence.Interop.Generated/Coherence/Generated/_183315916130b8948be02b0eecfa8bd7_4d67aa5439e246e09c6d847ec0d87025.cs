using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _183315916130b8948be02b0eecfa8bd7_4d67aa5439e246e09c6d847ec0d87025 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public float percentage;
		}

		public long startingSimFrame;

		public float percentage;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _183315916130b8948be02b0eecfa8bd7_4d67aa5439e246e09c6d847ec0d87025 FromInterop(IntPtr data, int dataSize)
		{
			return default(_183315916130b8948be02b0eecfa8bd7_4d67aa5439e246e09c6d847ec0d87025);
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

		public _183315916130b8948be02b0eecfa8bd7_4d67aa5439e246e09c6d847ec0d87025(Entity entity, long startingSimFrame, float percentage)
		{
			this.startingSimFrame = 0L;
			this.percentage = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_183315916130b8948be02b0eecfa8bd7_4d67aa5439e246e09c6d847ec0d87025 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _183315916130b8948be02b0eecfa8bd7_4d67aa5439e246e09c6d847ec0d87025 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_183315916130b8948be02b0eecfa8bd7_4d67aa5439e246e09c6d847ec0d87025);
		}
	}
}
