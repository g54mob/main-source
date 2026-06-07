using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _f72cbcfeabeed0d48bb2f64bd7b1ef86_a6b15a76c9994bd0b9b964dfe6911a1c : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public float yOffset;

			[FieldOffset(4)]
			public byte follow;

			[FieldOffset(5)]
			public float duration;
		}

		public float yOffset;

		public bool follow;

		public float duration;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _f72cbcfeabeed0d48bb2f64bd7b1ef86_a6b15a76c9994bd0b9b964dfe6911a1c FromInterop(IntPtr data, int dataSize)
		{
			return default(_f72cbcfeabeed0d48bb2f64bd7b1ef86_a6b15a76c9994bd0b9b964dfe6911a1c);
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

		public _f72cbcfeabeed0d48bb2f64bd7b1ef86_a6b15a76c9994bd0b9b964dfe6911a1c(Entity entity, float yOffset, bool follow, float duration)
		{
			this.yOffset = 0f;
			this.follow = false;
			this.duration = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_f72cbcfeabeed0d48bb2f64bd7b1ef86_a6b15a76c9994bd0b9b964dfe6911a1c commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _f72cbcfeabeed0d48bb2f64bd7b1ef86_a6b15a76c9994bd0b9b964dfe6911a1c Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_f72cbcfeabeed0d48bb2f64bd7b1ef86_a6b15a76c9994bd0b9b964dfe6911a1c);
		}
	}
}
