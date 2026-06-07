using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _2cfe417253a942141bf3d54efae7afd6_f341d471180a4c04b63c1086e01d9f56 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long simFrame;

			[FieldOffset(8)]
			public int weaponType;

			[FieldOffset(12)]
			public int itemType;

			[FieldOffset(16)]
			public int index;

			[FieldOffset(20)]
			public int price;

			[FieldOffset(24)]
			public Entity player;
		}

		public long simFrame;

		public int weaponType;

		public int itemType;

		public int index;

		public int price;

		public Entity player;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _2cfe417253a942141bf3d54efae7afd6_f341d471180a4c04b63c1086e01d9f56 FromInterop(IntPtr data, int dataSize)
		{
			return default(_2cfe417253a942141bf3d54efae7afd6_f341d471180a4c04b63c1086e01d9f56);
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

		public _2cfe417253a942141bf3d54efae7afd6_f341d471180a4c04b63c1086e01d9f56(Entity entity, long simFrame, int weaponType, int itemType, int index, int price, Entity player)
		{
			this.simFrame = 0L;
			this.weaponType = 0;
			this.itemType = 0;
			this.index = 0;
			this.price = 0;
			this.player = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_2cfe417253a942141bf3d54efae7afd6_f341d471180a4c04b63c1086e01d9f56 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _2cfe417253a942141bf3d54efae7afd6_f341d471180a4c04b63c1086e01d9f56 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_2cfe417253a942141bf3d54efae7afd6_f341d471180a4c04b63c1086e01d9f56);
		}
	}
}
