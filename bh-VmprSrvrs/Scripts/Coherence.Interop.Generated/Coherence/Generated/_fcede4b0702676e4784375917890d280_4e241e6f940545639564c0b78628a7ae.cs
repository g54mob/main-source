using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _fcede4b0702676e4784375917890d280_4e241e6f940545639564c0b78628a7ae : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _fcede4b0702676e4784375917890d280_4e241e6f940545639564c0b78628a7ae FromInterop(IntPtr data, int dataSize)
		{
			return default(_fcede4b0702676e4784375917890d280_4e241e6f940545639564c0b78628a7ae);
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

		public static void Serialize(_fcede4b0702676e4784375917890d280_4e241e6f940545639564c0b78628a7ae commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _fcede4b0702676e4784375917890d280_4e241e6f940545639564c0b78628a7ae Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_fcede4b0702676e4784375917890d280_4e241e6f940545639564c0b78628a7ae);
		}
	}
}
