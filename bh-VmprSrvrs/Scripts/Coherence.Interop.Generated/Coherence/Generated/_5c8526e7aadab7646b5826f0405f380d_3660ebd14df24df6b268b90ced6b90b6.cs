using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _5c8526e7aadab7646b5826f0405f380d_3660ebd14df24df6b268b90ced6b90b6 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _5c8526e7aadab7646b5826f0405f380d_3660ebd14df24df6b268b90ced6b90b6 FromInterop(IntPtr data, int dataSize)
		{
			return default(_5c8526e7aadab7646b5826f0405f380d_3660ebd14df24df6b268b90ced6b90b6);
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

		public static void Serialize(_5c8526e7aadab7646b5826f0405f380d_3660ebd14df24df6b268b90ced6b90b6 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _5c8526e7aadab7646b5826f0405f380d_3660ebd14df24df6b268b90ced6b90b6 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_5c8526e7aadab7646b5826f0405f380d_3660ebd14df24df6b268b90ced6b90b6);
		}
	}
}
