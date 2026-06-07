using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _519bc6da80352d44294a386e2d2fab4f_5097d51dc4a849fd80c9b2c794bc756b : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _519bc6da80352d44294a386e2d2fab4f_5097d51dc4a849fd80c9b2c794bc756b FromInterop(IntPtr data, int dataSize)
		{
			return default(_519bc6da80352d44294a386e2d2fab4f_5097d51dc4a849fd80c9b2c794bc756b);
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

		public _519bc6da80352d44294a386e2d2fab4f_5097d51dc4a849fd80c9b2c794bc756b(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_519bc6da80352d44294a386e2d2fab4f_5097d51dc4a849fd80c9b2c794bc756b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _519bc6da80352d44294a386e2d2fab4f_5097d51dc4a849fd80c9b2c794bc756b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_519bc6da80352d44294a386e2d2fab4f_5097d51dc4a849fd80c9b2c794bc756b);
		}
	}
}
