using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _8a924c4c0294f3e41ba0defae1cb8d7d_f58078db34c94801938a76c734677d74 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _8a924c4c0294f3e41ba0defae1cb8d7d_f58078db34c94801938a76c734677d74 FromInterop(IntPtr data, int dataSize)
		{
			return default(_8a924c4c0294f3e41ba0defae1cb8d7d_f58078db34c94801938a76c734677d74);
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

		public static void Serialize(_8a924c4c0294f3e41ba0defae1cb8d7d_f58078db34c94801938a76c734677d74 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _8a924c4c0294f3e41ba0defae1cb8d7d_f58078db34c94801938a76c734677d74 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_8a924c4c0294f3e41ba0defae1cb8d7d_f58078db34c94801938a76c734677d74);
		}
	}
}
