using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _8f69b5b90f9820c48b20d38d4878a1f0_085741c3d1e043f3a511a6b4502f3c86 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _8f69b5b90f9820c48b20d38d4878a1f0_085741c3d1e043f3a511a6b4502f3c86 FromInterop(IntPtr data, int dataSize)
		{
			return default(_8f69b5b90f9820c48b20d38d4878a1f0_085741c3d1e043f3a511a6b4502f3c86);
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

		public static void Serialize(_8f69b5b90f9820c48b20d38d4878a1f0_085741c3d1e043f3a511a6b4502f3c86 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _8f69b5b90f9820c48b20d38d4878a1f0_085741c3d1e043f3a511a6b4502f3c86 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_8f69b5b90f9820c48b20d38d4878a1f0_085741c3d1e043f3a511a6b4502f3c86);
		}
	}
}
