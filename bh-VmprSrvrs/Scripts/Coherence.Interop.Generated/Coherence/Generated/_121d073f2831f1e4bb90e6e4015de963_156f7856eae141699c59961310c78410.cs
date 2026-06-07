using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _121d073f2831f1e4bb90e6e4015de963_156f7856eae141699c59961310c78410 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _121d073f2831f1e4bb90e6e4015de963_156f7856eae141699c59961310c78410 FromInterop(IntPtr data, int dataSize)
		{
			return default(_121d073f2831f1e4bb90e6e4015de963_156f7856eae141699c59961310c78410);
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

		public static void Serialize(_121d073f2831f1e4bb90e6e4015de963_156f7856eae141699c59961310c78410 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _121d073f2831f1e4bb90e6e4015de963_156f7856eae141699c59961310c78410 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_121d073f2831f1e4bb90e6e4015de963_156f7856eae141699c59961310c78410);
		}
	}
}
