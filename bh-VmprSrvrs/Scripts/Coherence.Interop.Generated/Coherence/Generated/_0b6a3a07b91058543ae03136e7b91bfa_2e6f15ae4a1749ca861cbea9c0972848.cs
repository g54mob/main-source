using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _0b6a3a07b91058543ae03136e7b91bfa_2e6f15ae4a1749ca861cbea9c0972848 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _0b6a3a07b91058543ae03136e7b91bfa_2e6f15ae4a1749ca861cbea9c0972848 FromInterop(IntPtr data, int dataSize)
		{
			return default(_0b6a3a07b91058543ae03136e7b91bfa_2e6f15ae4a1749ca861cbea9c0972848);
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

		public static void Serialize(_0b6a3a07b91058543ae03136e7b91bfa_2e6f15ae4a1749ca861cbea9c0972848 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _0b6a3a07b91058543ae03136e7b91bfa_2e6f15ae4a1749ca861cbea9c0972848 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_0b6a3a07b91058543ae03136e7b91bfa_2e6f15ae4a1749ca861cbea9c0972848);
		}
	}
}
