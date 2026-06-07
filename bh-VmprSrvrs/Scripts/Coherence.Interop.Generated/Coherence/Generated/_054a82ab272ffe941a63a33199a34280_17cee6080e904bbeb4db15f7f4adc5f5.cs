using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _054a82ab272ffe941a63a33199a34280_17cee6080e904bbeb4db15f7f4adc5f5 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _054a82ab272ffe941a63a33199a34280_17cee6080e904bbeb4db15f7f4adc5f5 FromInterop(IntPtr data, int dataSize)
		{
			return default(_054a82ab272ffe941a63a33199a34280_17cee6080e904bbeb4db15f7f4adc5f5);
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

		public static void Serialize(_054a82ab272ffe941a63a33199a34280_17cee6080e904bbeb4db15f7f4adc5f5 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _054a82ab272ffe941a63a33199a34280_17cee6080e904bbeb4db15f7f4adc5f5 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_054a82ab272ffe941a63a33199a34280_17cee6080e904bbeb4db15f7f4adc5f5);
		}
	}
}
