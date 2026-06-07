using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _9dd30fc2395013d408bf881d717d21d9_4570ced8efc7475dbb2c9182397e250a : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _9dd30fc2395013d408bf881d717d21d9_4570ced8efc7475dbb2c9182397e250a FromInterop(IntPtr data, int dataSize)
		{
			return default(_9dd30fc2395013d408bf881d717d21d9_4570ced8efc7475dbb2c9182397e250a);
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

		public _9dd30fc2395013d408bf881d717d21d9_4570ced8efc7475dbb2c9182397e250a(Entity entity, long frame, int weaponType)
		{
			this.frame = 0L;
			this.weaponType = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_9dd30fc2395013d408bf881d717d21d9_4570ced8efc7475dbb2c9182397e250a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _9dd30fc2395013d408bf881d717d21d9_4570ced8efc7475dbb2c9182397e250a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_9dd30fc2395013d408bf881d717d21d9_4570ced8efc7475dbb2c9182397e250a);
		}
	}
}
