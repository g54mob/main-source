using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _af86be262b5c0bb4684f6625caea1d92_0885e99c4e1c404b9af2564c520a60da : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _af86be262b5c0bb4684f6625caea1d92_0885e99c4e1c404b9af2564c520a60da FromInterop(IntPtr data, int dataSize)
		{
			return default(_af86be262b5c0bb4684f6625caea1d92_0885e99c4e1c404b9af2564c520a60da);
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

		public static void Serialize(_af86be262b5c0bb4684f6625caea1d92_0885e99c4e1c404b9af2564c520a60da commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _af86be262b5c0bb4684f6625caea1d92_0885e99c4e1c404b9af2564c520a60da Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_af86be262b5c0bb4684f6625caea1d92_0885e99c4e1c404b9af2564c520a60da);
		}
	}
}
