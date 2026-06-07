using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _0e51949785a30af4c950bf762c05f52f_02cc23e970ed4bf0bb927fad47dff92d : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _0e51949785a30af4c950bf762c05f52f_02cc23e970ed4bf0bb927fad47dff92d FromInterop(IntPtr data, int dataSize)
		{
			return default(_0e51949785a30af4c950bf762c05f52f_02cc23e970ed4bf0bb927fad47dff92d);
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

		public static void Serialize(_0e51949785a30af4c950bf762c05f52f_02cc23e970ed4bf0bb927fad47dff92d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _0e51949785a30af4c950bf762c05f52f_02cc23e970ed4bf0bb927fad47dff92d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_0e51949785a30af4c950bf762c05f52f_02cc23e970ed4bf0bb927fad47dff92d);
		}
	}
}
