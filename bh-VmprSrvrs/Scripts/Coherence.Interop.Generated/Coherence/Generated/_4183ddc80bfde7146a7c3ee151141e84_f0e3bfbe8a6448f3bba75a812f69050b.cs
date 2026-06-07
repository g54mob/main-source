using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _4183ddc80bfde7146a7c3ee151141e84_f0e3bfbe8a6448f3bba75a812f69050b : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _4183ddc80bfde7146a7c3ee151141e84_f0e3bfbe8a6448f3bba75a812f69050b FromInterop(IntPtr data, int dataSize)
		{
			return default(_4183ddc80bfde7146a7c3ee151141e84_f0e3bfbe8a6448f3bba75a812f69050b);
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

		public static void Serialize(_4183ddc80bfde7146a7c3ee151141e84_f0e3bfbe8a6448f3bba75a812f69050b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _4183ddc80bfde7146a7c3ee151141e84_f0e3bfbe8a6448f3bba75a812f69050b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_4183ddc80bfde7146a7c3ee151141e84_f0e3bfbe8a6448f3bba75a812f69050b);
		}
	}
}
