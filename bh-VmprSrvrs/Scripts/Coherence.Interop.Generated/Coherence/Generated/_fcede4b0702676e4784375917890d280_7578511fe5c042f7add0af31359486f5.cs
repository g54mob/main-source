using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _fcede4b0702676e4784375917890d280_7578511fe5c042f7add0af31359486f5 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _fcede4b0702676e4784375917890d280_7578511fe5c042f7add0af31359486f5 FromInterop(IntPtr data, int dataSize)
		{
			return default(_fcede4b0702676e4784375917890d280_7578511fe5c042f7add0af31359486f5);
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

		public static void Serialize(_fcede4b0702676e4784375917890d280_7578511fe5c042f7add0af31359486f5 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _fcede4b0702676e4784375917890d280_7578511fe5c042f7add0af31359486f5 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_fcede4b0702676e4784375917890d280_7578511fe5c042f7add0af31359486f5);
		}
	}
}
