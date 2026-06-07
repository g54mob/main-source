using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _d0f8196fdb1e0a141b60c32820b800fe_bafeef6ac3db4a248ec14eaa02334308 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _d0f8196fdb1e0a141b60c32820b800fe_bafeef6ac3db4a248ec14eaa02334308 FromInterop(IntPtr data, int dataSize)
		{
			return default(_d0f8196fdb1e0a141b60c32820b800fe_bafeef6ac3db4a248ec14eaa02334308);
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

		public static void Serialize(_d0f8196fdb1e0a141b60c32820b800fe_bafeef6ac3db4a248ec14eaa02334308 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _d0f8196fdb1e0a141b60c32820b800fe_bafeef6ac3db4a248ec14eaa02334308 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_d0f8196fdb1e0a141b60c32820b800fe_bafeef6ac3db4a248ec14eaa02334308);
		}
	}
}
