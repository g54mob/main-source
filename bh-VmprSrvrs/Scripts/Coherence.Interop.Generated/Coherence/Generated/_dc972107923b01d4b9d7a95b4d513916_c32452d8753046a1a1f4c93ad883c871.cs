using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _dc972107923b01d4b9d7a95b4d513916_c32452d8753046a1a1f4c93ad883c871 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public float damageAmount;
		}

		public float damageAmount;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _dc972107923b01d4b9d7a95b4d513916_c32452d8753046a1a1f4c93ad883c871 FromInterop(IntPtr data, int dataSize)
		{
			return default(_dc972107923b01d4b9d7a95b4d513916_c32452d8753046a1a1f4c93ad883c871);
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

		public _dc972107923b01d4b9d7a95b4d513916_c32452d8753046a1a1f4c93ad883c871(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_dc972107923b01d4b9d7a95b4d513916_c32452d8753046a1a1f4c93ad883c871 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _dc972107923b01d4b9d7a95b4d513916_c32452d8753046a1a1f4c93ad883c871 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_dc972107923b01d4b9d7a95b4d513916_c32452d8753046a1a1f4c93ad883c871);
		}
	}
}
