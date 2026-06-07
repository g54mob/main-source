using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _65618a9761bc0af44853f3d7d64d8002_3894ee8327c143e69613cf261377bd1b : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _65618a9761bc0af44853f3d7d64d8002_3894ee8327c143e69613cf261377bd1b FromInterop(IntPtr data, int dataSize)
		{
			return default(_65618a9761bc0af44853f3d7d64d8002_3894ee8327c143e69613cf261377bd1b);
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

		public static void Serialize(_65618a9761bc0af44853f3d7d64d8002_3894ee8327c143e69613cf261377bd1b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _65618a9761bc0af44853f3d7d64d8002_3894ee8327c143e69613cf261377bd1b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_65618a9761bc0af44853f3d7d64d8002_3894ee8327c143e69613cf261377bd1b);
		}
	}
}
