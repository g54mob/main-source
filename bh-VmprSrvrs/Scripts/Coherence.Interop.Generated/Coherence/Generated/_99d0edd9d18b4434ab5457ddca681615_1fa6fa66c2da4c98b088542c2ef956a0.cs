using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _99d0edd9d18b4434ab5457ddca681615_1fa6fa66c2da4c98b088542c2ef956a0 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _99d0edd9d18b4434ab5457ddca681615_1fa6fa66c2da4c98b088542c2ef956a0 FromInterop(IntPtr data, int dataSize)
		{
			return default(_99d0edd9d18b4434ab5457ddca681615_1fa6fa66c2da4c98b088542c2ef956a0);
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

		public static void Serialize(_99d0edd9d18b4434ab5457ddca681615_1fa6fa66c2da4c98b088542c2ef956a0 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _99d0edd9d18b4434ab5457ddca681615_1fa6fa66c2da4c98b088542c2ef956a0 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_99d0edd9d18b4434ab5457ddca681615_1fa6fa66c2da4c98b088542c2ef956a0);
		}
	}
}
