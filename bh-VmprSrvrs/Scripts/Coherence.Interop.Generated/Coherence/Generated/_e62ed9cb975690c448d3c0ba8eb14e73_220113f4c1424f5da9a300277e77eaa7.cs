using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _e62ed9cb975690c448d3c0ba8eb14e73_220113f4c1424f5da9a300277e77eaa7 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _e62ed9cb975690c448d3c0ba8eb14e73_220113f4c1424f5da9a300277e77eaa7 FromInterop(IntPtr data, int dataSize)
		{
			return default(_e62ed9cb975690c448d3c0ba8eb14e73_220113f4c1424f5da9a300277e77eaa7);
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

		public _e62ed9cb975690c448d3c0ba8eb14e73_220113f4c1424f5da9a300277e77eaa7(Entity entity, long frame, int weaponType)
		{
			this.frame = 0L;
			this.weaponType = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_e62ed9cb975690c448d3c0ba8eb14e73_220113f4c1424f5da9a300277e77eaa7 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _e62ed9cb975690c448d3c0ba8eb14e73_220113f4c1424f5da9a300277e77eaa7 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_e62ed9cb975690c448d3c0ba8eb14e73_220113f4c1424f5da9a300277e77eaa7);
		}
	}
}
