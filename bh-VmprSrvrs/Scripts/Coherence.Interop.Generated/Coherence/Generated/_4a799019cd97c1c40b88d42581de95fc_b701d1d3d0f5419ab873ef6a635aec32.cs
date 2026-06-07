using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _4a799019cd97c1c40b88d42581de95fc_b701d1d3d0f5419ab873ef6a635aec32 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _4a799019cd97c1c40b88d42581de95fc_b701d1d3d0f5419ab873ef6a635aec32 FromInterop(IntPtr data, int dataSize)
		{
			return default(_4a799019cd97c1c40b88d42581de95fc_b701d1d3d0f5419ab873ef6a635aec32);
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

		public static void Serialize(_4a799019cd97c1c40b88d42581de95fc_b701d1d3d0f5419ab873ef6a635aec32 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _4a799019cd97c1c40b88d42581de95fc_b701d1d3d0f5419ab873ef6a635aec32 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_4a799019cd97c1c40b88d42581de95fc_b701d1d3d0f5419ab873ef6a635aec32);
		}
	}
}
