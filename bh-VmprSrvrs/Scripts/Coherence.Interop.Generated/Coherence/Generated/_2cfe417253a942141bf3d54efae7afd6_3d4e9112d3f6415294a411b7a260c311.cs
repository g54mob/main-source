using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _2cfe417253a942141bf3d54efae7afd6_3d4e9112d3f6415294a411b7a260c311 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public int limitBreakIndex;

			[FieldOffset(12)]
			public byte alwaysRandomLimitBreak;

			[FieldOffset(13)]
			public Entity receivingCharacter;
		}

		public long startingSimFrame;

		public int limitBreakIndex;

		public bool alwaysRandomLimitBreak;

		public Entity receivingCharacter;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _2cfe417253a942141bf3d54efae7afd6_3d4e9112d3f6415294a411b7a260c311 FromInterop(IntPtr data, int dataSize)
		{
			return default(_2cfe417253a942141bf3d54efae7afd6_3d4e9112d3f6415294a411b7a260c311);
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

		public _2cfe417253a942141bf3d54efae7afd6_3d4e9112d3f6415294a411b7a260c311(Entity entity, long startingSimFrame, int limitBreakIndex, bool alwaysRandomLimitBreak, Entity receivingCharacter)
		{
			this.startingSimFrame = 0L;
			this.limitBreakIndex = 0;
			this.alwaysRandomLimitBreak = false;
			this.receivingCharacter = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_2cfe417253a942141bf3d54efae7afd6_3d4e9112d3f6415294a411b7a260c311 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _2cfe417253a942141bf3d54efae7afd6_3d4e9112d3f6415294a411b7a260c311 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_2cfe417253a942141bf3d54efae7afd6_3d4e9112d3f6415294a411b7a260c311);
		}
	}
}
