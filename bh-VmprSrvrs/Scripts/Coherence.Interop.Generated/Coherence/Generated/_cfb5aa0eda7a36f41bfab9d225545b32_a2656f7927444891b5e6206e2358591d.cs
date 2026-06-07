using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _cfb5aa0eda7a36f41bfab9d225545b32_a2656f7927444891b5e6206e2358591d : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _cfb5aa0eda7a36f41bfab9d225545b32_a2656f7927444891b5e6206e2358591d FromInterop(IntPtr data, int dataSize)
		{
			return default(_cfb5aa0eda7a36f41bfab9d225545b32_a2656f7927444891b5e6206e2358591d);
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

		public _cfb5aa0eda7a36f41bfab9d225545b32_a2656f7927444891b5e6206e2358591d(Entity entity, long frame, int weaponType)
		{
			this.frame = 0L;
			this.weaponType = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_cfb5aa0eda7a36f41bfab9d225545b32_a2656f7927444891b5e6206e2358591d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _cfb5aa0eda7a36f41bfab9d225545b32_a2656f7927444891b5e6206e2358591d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_cfb5aa0eda7a36f41bfab9d225545b32_a2656f7927444891b5e6206e2358591d);
		}
	}
}
