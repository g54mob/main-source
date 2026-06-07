using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _2cfe417253a942141bf3d54efae7afd6_8f73e6836ad64de9a176ddea2db71ff4 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public short enemyType;

			[FieldOffset(2)]
			public byte wasCartRider;

			[FieldOffset(3)]
			public Entity followedCharacterSync;
		}

		public short enemyType;

		public bool wasCartRider;

		public Entity followedCharacterSync;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _2cfe417253a942141bf3d54efae7afd6_8f73e6836ad64de9a176ddea2db71ff4 FromInterop(IntPtr data, int dataSize)
		{
			return default(_2cfe417253a942141bf3d54efae7afd6_8f73e6836ad64de9a176ddea2db71ff4);
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

		public _2cfe417253a942141bf3d54efae7afd6_8f73e6836ad64de9a176ddea2db71ff4(Entity entity, short enemyType, bool wasCartRider, Entity followedCharacterSync)
		{
			this.enemyType = 0;
			this.wasCartRider = false;
			this.followedCharacterSync = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_2cfe417253a942141bf3d54efae7afd6_8f73e6836ad64de9a176ddea2db71ff4 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _2cfe417253a942141bf3d54efae7afd6_8f73e6836ad64de9a176ddea2db71ff4 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_2cfe417253a942141bf3d54efae7afd6_8f73e6836ad64de9a176ddea2db71ff4);
		}
	}
}
