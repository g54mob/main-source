using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _3b1b4803df14c314f9c8257e88fcbf13_99706a1e244546d281578b0cf95814a7 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public int weaponType;
		}

		public long startingSimFrame;

		public int weaponType;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _3b1b4803df14c314f9c8257e88fcbf13_99706a1e244546d281578b0cf95814a7 FromInterop(IntPtr data, int dataSize)
		{
			return default(_3b1b4803df14c314f9c8257e88fcbf13_99706a1e244546d281578b0cf95814a7);
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

		public _3b1b4803df14c314f9c8257e88fcbf13_99706a1e244546d281578b0cf95814a7(Entity entity, long startingSimFrame, int weaponType)
		{
			this.startingSimFrame = 0L;
			this.weaponType = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_3b1b4803df14c314f9c8257e88fcbf13_99706a1e244546d281578b0cf95814a7 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _3b1b4803df14c314f9c8257e88fcbf13_99706a1e244546d281578b0cf95814a7 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_3b1b4803df14c314f9c8257e88fcbf13_99706a1e244546d281578b0cf95814a7);
		}
	}
}
