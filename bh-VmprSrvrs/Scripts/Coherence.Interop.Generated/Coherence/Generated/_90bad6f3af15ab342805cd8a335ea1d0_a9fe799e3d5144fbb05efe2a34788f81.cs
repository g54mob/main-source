using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _90bad6f3af15ab342805cd8a335ea1d0_a9fe799e3d5144fbb05efe2a34788f81 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _90bad6f3af15ab342805cd8a335ea1d0_a9fe799e3d5144fbb05efe2a34788f81 FromInterop(IntPtr data, int dataSize)
		{
			return default(_90bad6f3af15ab342805cd8a335ea1d0_a9fe799e3d5144fbb05efe2a34788f81);
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

		public static void Serialize(_90bad6f3af15ab342805cd8a335ea1d0_a9fe799e3d5144fbb05efe2a34788f81 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _90bad6f3af15ab342805cd8a335ea1d0_a9fe799e3d5144fbb05efe2a34788f81 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_90bad6f3af15ab342805cd8a335ea1d0_a9fe799e3d5144fbb05efe2a34788f81);
		}
	}
}
