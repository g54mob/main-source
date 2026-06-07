using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a5a2f4b0e3907f545b69e23fea6e3c89_d4d3ab71151142ccaeef7a2a782666ca : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public Entity player;
		}

		public long startingSimFrame;

		public Entity player;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _a5a2f4b0e3907f545b69e23fea6e3c89_d4d3ab71151142ccaeef7a2a782666ca FromInterop(IntPtr data, int dataSize)
		{
			return default(_a5a2f4b0e3907f545b69e23fea6e3c89_d4d3ab71151142ccaeef7a2a782666ca);
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

		public _a5a2f4b0e3907f545b69e23fea6e3c89_d4d3ab71151142ccaeef7a2a782666ca(Entity entity, long startingSimFrame, Entity player)
		{
			this.startingSimFrame = 0L;
			this.player = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_a5a2f4b0e3907f545b69e23fea6e3c89_d4d3ab71151142ccaeef7a2a782666ca commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a5a2f4b0e3907f545b69e23fea6e3c89_d4d3ab71151142ccaeef7a2a782666ca Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a5a2f4b0e3907f545b69e23fea6e3c89_d4d3ab71151142ccaeef7a2a782666ca);
		}
	}
}
