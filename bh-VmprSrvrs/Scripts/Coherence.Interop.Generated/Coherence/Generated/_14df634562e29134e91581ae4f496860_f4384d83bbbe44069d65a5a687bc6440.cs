using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _14df634562e29134e91581ae4f496860_f4384d83bbbe44069d65a5a687bc6440 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _14df634562e29134e91581ae4f496860_f4384d83bbbe44069d65a5a687bc6440 FromInterop(IntPtr data, int dataSize)
		{
			return default(_14df634562e29134e91581ae4f496860_f4384d83bbbe44069d65a5a687bc6440);
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

		public _14df634562e29134e91581ae4f496860_f4384d83bbbe44069d65a5a687bc6440(Entity entity, long startingSimFrame, float percentage)
		{
			this.startingSimFrame = 0L;
			this.percentage = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_14df634562e29134e91581ae4f496860_f4384d83bbbe44069d65a5a687bc6440 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _14df634562e29134e91581ae4f496860_f4384d83bbbe44069d65a5a687bc6440 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_14df634562e29134e91581ae4f496860_f4384d83bbbe44069d65a5a687bc6440);
		}
	}
}
