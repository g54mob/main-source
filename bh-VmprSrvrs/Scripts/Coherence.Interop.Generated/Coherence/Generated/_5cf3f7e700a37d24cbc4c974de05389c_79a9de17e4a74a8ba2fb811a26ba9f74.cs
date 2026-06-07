using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _5cf3f7e700a37d24cbc4c974de05389c_79a9de17e4a74a8ba2fb811a26ba9f74 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _5cf3f7e700a37d24cbc4c974de05389c_79a9de17e4a74a8ba2fb811a26ba9f74 FromInterop(IntPtr data, int dataSize)
		{
			return default(_5cf3f7e700a37d24cbc4c974de05389c_79a9de17e4a74a8ba2fb811a26ba9f74);
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

		public static void Serialize(_5cf3f7e700a37d24cbc4c974de05389c_79a9de17e4a74a8ba2fb811a26ba9f74 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _5cf3f7e700a37d24cbc4c974de05389c_79a9de17e4a74a8ba2fb811a26ba9f74 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_5cf3f7e700a37d24cbc4c974de05389c_79a9de17e4a74a8ba2fb811a26ba9f74);
		}
	}
}
