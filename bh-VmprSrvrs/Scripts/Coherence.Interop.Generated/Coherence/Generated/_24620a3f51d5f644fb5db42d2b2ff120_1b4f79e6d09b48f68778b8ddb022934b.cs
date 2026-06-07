using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _24620a3f51d5f644fb5db42d2b2ff120_1b4f79e6d09b48f68778b8ddb022934b : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _24620a3f51d5f644fb5db42d2b2ff120_1b4f79e6d09b48f68778b8ddb022934b FromInterop(IntPtr data, int dataSize)
		{
			return default(_24620a3f51d5f644fb5db42d2b2ff120_1b4f79e6d09b48f68778b8ddb022934b);
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

		public static void Serialize(_24620a3f51d5f644fb5db42d2b2ff120_1b4f79e6d09b48f68778b8ddb022934b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _24620a3f51d5f644fb5db42d2b2ff120_1b4f79e6d09b48f68778b8ddb022934b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_24620a3f51d5f644fb5db42d2b2ff120_1b4f79e6d09b48f68778b8ddb022934b);
		}
	}
}
