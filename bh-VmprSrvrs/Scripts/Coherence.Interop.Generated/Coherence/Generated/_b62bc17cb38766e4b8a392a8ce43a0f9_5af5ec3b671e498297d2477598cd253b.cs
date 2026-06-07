using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _b62bc17cb38766e4b8a392a8ce43a0f9_5af5ec3b671e498297d2477598cd253b : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public byte skipTriggers;
		}

		public bool skipTriggers;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _b62bc17cb38766e4b8a392a8ce43a0f9_5af5ec3b671e498297d2477598cd253b FromInterop(IntPtr data, int dataSize)
		{
			return default(_b62bc17cb38766e4b8a392a8ce43a0f9_5af5ec3b671e498297d2477598cd253b);
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

		public _b62bc17cb38766e4b8a392a8ce43a0f9_5af5ec3b671e498297d2477598cd253b(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_b62bc17cb38766e4b8a392a8ce43a0f9_5af5ec3b671e498297d2477598cd253b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _b62bc17cb38766e4b8a392a8ce43a0f9_5af5ec3b671e498297d2477598cd253b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_b62bc17cb38766e4b8a392a8ce43a0f9_5af5ec3b671e498297d2477598cd253b);
		}
	}
}
