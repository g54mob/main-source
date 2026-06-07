using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _519bc6da80352d44294a386e2d2fab4f_4920c192af3f421e89ffa87fab256502 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _519bc6da80352d44294a386e2d2fab4f_4920c192af3f421e89ffa87fab256502 FromInterop(IntPtr data, int dataSize)
		{
			return default(_519bc6da80352d44294a386e2d2fab4f_4920c192af3f421e89ffa87fab256502);
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

		public _519bc6da80352d44294a386e2d2fab4f_4920c192af3f421e89ffa87fab256502(Entity entity, long startingSimFrame, Entity player)
		{
			this.startingSimFrame = 0L;
			this.player = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_519bc6da80352d44294a386e2d2fab4f_4920c192af3f421e89ffa87fab256502 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _519bc6da80352d44294a386e2d2fab4f_4920c192af3f421e89ffa87fab256502 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_519bc6da80352d44294a386e2d2fab4f_4920c192af3f421e89ffa87fab256502);
		}
	}
}
