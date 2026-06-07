using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _e4dddf95fdbf66f4385e3ab9ece2db40_dd88e5781a854503b78310cd013284ec : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingClientFrame;
		}

		public long startingClientFrame;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _e4dddf95fdbf66f4385e3ab9ece2db40_dd88e5781a854503b78310cd013284ec FromInterop(IntPtr data, int dataSize)
		{
			return default(_e4dddf95fdbf66f4385e3ab9ece2db40_dd88e5781a854503b78310cd013284ec);
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

		public _e4dddf95fdbf66f4385e3ab9ece2db40_dd88e5781a854503b78310cd013284ec(Entity entity, long startingClientFrame)
		{
			this.startingClientFrame = 0L;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_e4dddf95fdbf66f4385e3ab9ece2db40_dd88e5781a854503b78310cd013284ec commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _e4dddf95fdbf66f4385e3ab9ece2db40_dd88e5781a854503b78310cd013284ec Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_e4dddf95fdbf66f4385e3ab9ece2db40_dd88e5781a854503b78310cd013284ec);
		}
	}
}
