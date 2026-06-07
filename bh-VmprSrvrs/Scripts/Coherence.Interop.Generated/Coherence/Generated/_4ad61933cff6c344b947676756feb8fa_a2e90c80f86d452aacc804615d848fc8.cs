using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _4ad61933cff6c344b947676756feb8fa_a2e90c80f86d452aacc804615d848fc8 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _4ad61933cff6c344b947676756feb8fa_a2e90c80f86d452aacc804615d848fc8 FromInterop(IntPtr data, int dataSize)
		{
			return default(_4ad61933cff6c344b947676756feb8fa_a2e90c80f86d452aacc804615d848fc8);
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

		public _4ad61933cff6c344b947676756feb8fa_a2e90c80f86d452aacc804615d848fc8(Entity entity, long startingSimFrame, float percentage)
		{
			this.startingSimFrame = 0L;
			this.percentage = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_4ad61933cff6c344b947676756feb8fa_a2e90c80f86d452aacc804615d848fc8 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _4ad61933cff6c344b947676756feb8fa_a2e90c80f86d452aacc804615d848fc8 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_4ad61933cff6c344b947676756feb8fa_a2e90c80f86d452aacc804615d848fc8);
		}
	}
}
