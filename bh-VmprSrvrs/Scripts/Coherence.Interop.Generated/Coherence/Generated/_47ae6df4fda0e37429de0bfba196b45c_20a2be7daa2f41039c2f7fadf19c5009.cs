using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _47ae6df4fda0e37429de0bfba196b45c_20a2be7daa2f41039c2f7fadf19c5009 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _47ae6df4fda0e37429de0bfba196b45c_20a2be7daa2f41039c2f7fadf19c5009 FromInterop(IntPtr data, int dataSize)
		{
			return default(_47ae6df4fda0e37429de0bfba196b45c_20a2be7daa2f41039c2f7fadf19c5009);
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

		public static void Serialize(_47ae6df4fda0e37429de0bfba196b45c_20a2be7daa2f41039c2f7fadf19c5009 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _47ae6df4fda0e37429de0bfba196b45c_20a2be7daa2f41039c2f7fadf19c5009 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_47ae6df4fda0e37429de0bfba196b45c_20a2be7daa2f41039c2f7fadf19c5009);
		}
	}
}
