using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _48ae2c3adf311c941a5a0ebf01081294_ee97145fa4324e02ac94aea374587120 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _48ae2c3adf311c941a5a0ebf01081294_ee97145fa4324e02ac94aea374587120 FromInterop(IntPtr data, int dataSize)
		{
			return default(_48ae2c3adf311c941a5a0ebf01081294_ee97145fa4324e02ac94aea374587120);
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

		public static void Serialize(_48ae2c3adf311c941a5a0ebf01081294_ee97145fa4324e02ac94aea374587120 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _48ae2c3adf311c941a5a0ebf01081294_ee97145fa4324e02ac94aea374587120 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_48ae2c3adf311c941a5a0ebf01081294_ee97145fa4324e02ac94aea374587120);
		}
	}
}
