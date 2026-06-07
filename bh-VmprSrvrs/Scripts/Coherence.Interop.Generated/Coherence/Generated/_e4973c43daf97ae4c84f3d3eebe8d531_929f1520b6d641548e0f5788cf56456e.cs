using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _e4973c43daf97ae4c84f3d3eebe8d531_929f1520b6d641548e0f5788cf56456e : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _e4973c43daf97ae4c84f3d3eebe8d531_929f1520b6d641548e0f5788cf56456e FromInterop(IntPtr data, int dataSize)
		{
			return default(_e4973c43daf97ae4c84f3d3eebe8d531_929f1520b6d641548e0f5788cf56456e);
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

		public _e4973c43daf97ae4c84f3d3eebe8d531_929f1520b6d641548e0f5788cf56456e(Entity entity, long frame, int weaponType)
		{
			this.frame = 0L;
			this.weaponType = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_e4973c43daf97ae4c84f3d3eebe8d531_929f1520b6d641548e0f5788cf56456e commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _e4973c43daf97ae4c84f3d3eebe8d531_929f1520b6d641548e0f5788cf56456e Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_e4973c43daf97ae4c84f3d3eebe8d531_929f1520b6d641548e0f5788cf56456e);
		}
	}
}
