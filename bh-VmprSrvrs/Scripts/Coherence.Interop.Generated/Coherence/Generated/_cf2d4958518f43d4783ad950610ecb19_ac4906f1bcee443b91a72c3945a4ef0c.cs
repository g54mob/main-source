using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _cf2d4958518f43d4783ad950610ecb19_ac4906f1bcee443b91a72c3945a4ef0c : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _cf2d4958518f43d4783ad950610ecb19_ac4906f1bcee443b91a72c3945a4ef0c FromInterop(IntPtr data, int dataSize)
		{
			return default(_cf2d4958518f43d4783ad950610ecb19_ac4906f1bcee443b91a72c3945a4ef0c);
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

		public static void Serialize(_cf2d4958518f43d4783ad950610ecb19_ac4906f1bcee443b91a72c3945a4ef0c commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _cf2d4958518f43d4783ad950610ecb19_ac4906f1bcee443b91a72c3945a4ef0c Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_cf2d4958518f43d4783ad950610ecb19_ac4906f1bcee443b91a72c3945a4ef0c);
		}
	}
}
