using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _957ef244bb8baf74a96aa6ba59edb969_f1a8c751a4f3446b9d4c1ee30321fc80 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _957ef244bb8baf74a96aa6ba59edb969_f1a8c751a4f3446b9d4c1ee30321fc80 FromInterop(IntPtr data, int dataSize)
		{
			return default(_957ef244bb8baf74a96aa6ba59edb969_f1a8c751a4f3446b9d4c1ee30321fc80);
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

		public _957ef244bb8baf74a96aa6ba59edb969_f1a8c751a4f3446b9d4c1ee30321fc80(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_957ef244bb8baf74a96aa6ba59edb969_f1a8c751a4f3446b9d4c1ee30321fc80 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _957ef244bb8baf74a96aa6ba59edb969_f1a8c751a4f3446b9d4c1ee30321fc80 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_957ef244bb8baf74a96aa6ba59edb969_f1a8c751a4f3446b9d4c1ee30321fc80);
		}
	}
}
