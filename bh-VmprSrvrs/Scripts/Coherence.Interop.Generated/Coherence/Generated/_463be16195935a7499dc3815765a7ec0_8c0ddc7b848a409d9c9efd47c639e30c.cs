using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _463be16195935a7499dc3815765a7ec0_8c0ddc7b848a409d9c9efd47c639e30c : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _463be16195935a7499dc3815765a7ec0_8c0ddc7b848a409d9c9efd47c639e30c FromInterop(IntPtr data, int dataSize)
		{
			return default(_463be16195935a7499dc3815765a7ec0_8c0ddc7b848a409d9c9efd47c639e30c);
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

		public static void Serialize(_463be16195935a7499dc3815765a7ec0_8c0ddc7b848a409d9c9efd47c639e30c commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _463be16195935a7499dc3815765a7ec0_8c0ddc7b848a409d9c9efd47c639e30c Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_463be16195935a7499dc3815765a7ec0_8c0ddc7b848a409d9c9efd47c639e30c);
		}
	}
}
