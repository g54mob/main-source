using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _e3581a039524dad4bab4d7c311344fca_ba1fbd709e6840e8ad5b3e9354bffcb2 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _e3581a039524dad4bab4d7c311344fca_ba1fbd709e6840e8ad5b3e9354bffcb2 FromInterop(IntPtr data, int dataSize)
		{
			return default(_e3581a039524dad4bab4d7c311344fca_ba1fbd709e6840e8ad5b3e9354bffcb2);
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

		public static void Serialize(_e3581a039524dad4bab4d7c311344fca_ba1fbd709e6840e8ad5b3e9354bffcb2 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _e3581a039524dad4bab4d7c311344fca_ba1fbd709e6840e8ad5b3e9354bffcb2 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_e3581a039524dad4bab4d7c311344fca_ba1fbd709e6840e8ad5b3e9354bffcb2);
		}
	}
}
