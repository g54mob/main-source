using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _088d19625c3862641b3ea6e1f1010762_da3e918d8a25433e8520727c404ddb3e : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _088d19625c3862641b3ea6e1f1010762_da3e918d8a25433e8520727c404ddb3e FromInterop(IntPtr data, int dataSize)
		{
			return default(_088d19625c3862641b3ea6e1f1010762_da3e918d8a25433e8520727c404ddb3e);
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

		public _088d19625c3862641b3ea6e1f1010762_da3e918d8a25433e8520727c404ddb3e(Entity entity, long startingSimFrame, float percentage)
		{
			this.startingSimFrame = 0L;
			this.percentage = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_088d19625c3862641b3ea6e1f1010762_da3e918d8a25433e8520727c404ddb3e commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _088d19625c3862641b3ea6e1f1010762_da3e918d8a25433e8520727c404ddb3e Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_088d19625c3862641b3ea6e1f1010762_da3e918d8a25433e8520727c404ddb3e);
		}
	}
}
