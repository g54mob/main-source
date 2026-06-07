using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _dc972107923b01d4b9d7a95b4d513916_6a63ee91a10547e5adfa44a03a09418b : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long frame;

			[FieldOffset(8)]
			public int weaponType;
		}

		public long frame;

		public int weaponType;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _dc972107923b01d4b9d7a95b4d513916_6a63ee91a10547e5adfa44a03a09418b FromInterop(IntPtr data, int dataSize)
		{
			return default(_dc972107923b01d4b9d7a95b4d513916_6a63ee91a10547e5adfa44a03a09418b);
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

		public _dc972107923b01d4b9d7a95b4d513916_6a63ee91a10547e5adfa44a03a09418b(Entity entity, long frame, int weaponType)
		{
			this.frame = 0L;
			this.weaponType = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_dc972107923b01d4b9d7a95b4d513916_6a63ee91a10547e5adfa44a03a09418b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _dc972107923b01d4b9d7a95b4d513916_6a63ee91a10547e5adfa44a03a09418b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_dc972107923b01d4b9d7a95b4d513916_6a63ee91a10547e5adfa44a03a09418b);
		}
	}
}
