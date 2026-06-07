using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _f11f3c87b586d4b4e867cd143a1d76e1_29aef48dbc2e4355becd8fe573092ced : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _f11f3c87b586d4b4e867cd143a1d76e1_29aef48dbc2e4355becd8fe573092ced FromInterop(IntPtr data, int dataSize)
		{
			return default(_f11f3c87b586d4b4e867cd143a1d76e1_29aef48dbc2e4355becd8fe573092ced);
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

		public _f11f3c87b586d4b4e867cd143a1d76e1_29aef48dbc2e4355becd8fe573092ced(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_f11f3c87b586d4b4e867cd143a1d76e1_29aef48dbc2e4355becd8fe573092ced commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _f11f3c87b586d4b4e867cd143a1d76e1_29aef48dbc2e4355becd8fe573092ced Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_f11f3c87b586d4b4e867cd143a1d76e1_29aef48dbc2e4355becd8fe573092ced);
		}
	}
}
