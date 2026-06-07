using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _02f4603b68bd05a4eac4f889c63b8d92_742e3008953c4b36930ac1016e2c15f2 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _02f4603b68bd05a4eac4f889c63b8d92_742e3008953c4b36930ac1016e2c15f2 FromInterop(IntPtr data, int dataSize)
		{
			return default(_02f4603b68bd05a4eac4f889c63b8d92_742e3008953c4b36930ac1016e2c15f2);
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

		public static void Serialize(_02f4603b68bd05a4eac4f889c63b8d92_742e3008953c4b36930ac1016e2c15f2 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _02f4603b68bd05a4eac4f889c63b8d92_742e3008953c4b36930ac1016e2c15f2 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_02f4603b68bd05a4eac4f889c63b8d92_742e3008953c4b36930ac1016e2c15f2);
		}
	}
}
