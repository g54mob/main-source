using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _c14a809f00fd4b14cbfb6e4f2c23ad22_be3ee1f492fa4eb386ff7ef0c3d360cb : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _c14a809f00fd4b14cbfb6e4f2c23ad22_be3ee1f492fa4eb386ff7ef0c3d360cb FromInterop(IntPtr data, int dataSize)
		{
			return default(_c14a809f00fd4b14cbfb6e4f2c23ad22_be3ee1f492fa4eb386ff7ef0c3d360cb);
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

		public static void Serialize(_c14a809f00fd4b14cbfb6e4f2c23ad22_be3ee1f492fa4eb386ff7ef0c3d360cb commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _c14a809f00fd4b14cbfb6e4f2c23ad22_be3ee1f492fa4eb386ff7ef0c3d360cb Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_c14a809f00fd4b14cbfb6e4f2c23ad22_be3ee1f492fa4eb386ff7ef0c3d360cb);
		}
	}
}
