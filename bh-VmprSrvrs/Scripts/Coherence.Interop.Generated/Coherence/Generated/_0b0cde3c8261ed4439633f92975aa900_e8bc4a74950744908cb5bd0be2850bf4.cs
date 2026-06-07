using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _0b0cde3c8261ed4439633f92975aa900_e8bc4a74950744908cb5bd0be2850bf4 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _0b0cde3c8261ed4439633f92975aa900_e8bc4a74950744908cb5bd0be2850bf4 FromInterop(IntPtr data, int dataSize)
		{
			return default(_0b0cde3c8261ed4439633f92975aa900_e8bc4a74950744908cb5bd0be2850bf4);
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

		public static void Serialize(_0b0cde3c8261ed4439633f92975aa900_e8bc4a74950744908cb5bd0be2850bf4 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _0b0cde3c8261ed4439633f92975aa900_e8bc4a74950744908cb5bd0be2850bf4 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_0b0cde3c8261ed4439633f92975aa900_e8bc4a74950744908cb5bd0be2850bf4);
		}
	}
}
