using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _5e3e58d5412a64640aa3c145df0b642b_e63aa63296b44e01af55c2e1c7e4c376 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public int weaponType;

			[FieldOffset(12)]
			public float value;
		}

		public long startingSimFrame;

		public int weaponType;

		public float value;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _5e3e58d5412a64640aa3c145df0b642b_e63aa63296b44e01af55c2e1c7e4c376 FromInterop(IntPtr data, int dataSize)
		{
			return default(_5e3e58d5412a64640aa3c145df0b642b_e63aa63296b44e01af55c2e1c7e4c376);
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

		public _5e3e58d5412a64640aa3c145df0b642b_e63aa63296b44e01af55c2e1c7e4c376(Entity entity, long startingSimFrame, int weaponType, float value)
		{
			this.startingSimFrame = 0L;
			this.weaponType = 0;
			this.value = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_5e3e58d5412a64640aa3c145df0b642b_e63aa63296b44e01af55c2e1c7e4c376 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _5e3e58d5412a64640aa3c145df0b642b_e63aa63296b44e01af55c2e1c7e4c376 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_5e3e58d5412a64640aa3c145df0b642b_e63aa63296b44e01af55c2e1c7e4c376);
		}
	}
}
