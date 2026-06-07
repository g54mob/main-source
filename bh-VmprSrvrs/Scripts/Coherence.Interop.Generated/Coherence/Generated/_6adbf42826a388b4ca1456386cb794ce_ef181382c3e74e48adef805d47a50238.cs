using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _6adbf42826a388b4ca1456386cb794ce_ef181382c3e74e48adef805d47a50238 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _6adbf42826a388b4ca1456386cb794ce_ef181382c3e74e48adef805d47a50238 FromInterop(IntPtr data, int dataSize)
		{
			return default(_6adbf42826a388b4ca1456386cb794ce_ef181382c3e74e48adef805d47a50238);
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

		public static void Serialize(_6adbf42826a388b4ca1456386cb794ce_ef181382c3e74e48adef805d47a50238 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _6adbf42826a388b4ca1456386cb794ce_ef181382c3e74e48adef805d47a50238 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_6adbf42826a388b4ca1456386cb794ce_ef181382c3e74e48adef805d47a50238);
		}
	}
}
