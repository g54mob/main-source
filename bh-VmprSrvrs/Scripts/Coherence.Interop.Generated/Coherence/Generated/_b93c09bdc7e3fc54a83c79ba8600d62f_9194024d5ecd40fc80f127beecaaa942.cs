using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _b93c09bdc7e3fc54a83c79ba8600d62f_9194024d5ecd40fc80f127beecaaa942 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _b93c09bdc7e3fc54a83c79ba8600d62f_9194024d5ecd40fc80f127beecaaa942 FromInterop(IntPtr data, int dataSize)
		{
			return default(_b93c09bdc7e3fc54a83c79ba8600d62f_9194024d5ecd40fc80f127beecaaa942);
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

		public static void Serialize(_b93c09bdc7e3fc54a83c79ba8600d62f_9194024d5ecd40fc80f127beecaaa942 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _b93c09bdc7e3fc54a83c79ba8600d62f_9194024d5ecd40fc80f127beecaaa942 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_b93c09bdc7e3fc54a83c79ba8600d62f_9194024d5ecd40fc80f127beecaaa942);
		}
	}
}
