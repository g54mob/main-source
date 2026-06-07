using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _fc859b867e150404da8ebb756e5ca664_28ecbfa3c8bd4e6eb60331a4e14982b6 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _fc859b867e150404da8ebb756e5ca664_28ecbfa3c8bd4e6eb60331a4e14982b6 FromInterop(IntPtr data, int dataSize)
		{
			return default(_fc859b867e150404da8ebb756e5ca664_28ecbfa3c8bd4e6eb60331a4e14982b6);
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

		public static void Serialize(_fc859b867e150404da8ebb756e5ca664_28ecbfa3c8bd4e6eb60331a4e14982b6 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _fc859b867e150404da8ebb756e5ca664_28ecbfa3c8bd4e6eb60331a4e14982b6 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_fc859b867e150404da8ebb756e5ca664_28ecbfa3c8bd4e6eb60331a4e14982b6);
		}
	}
}
