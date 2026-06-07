using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ba1c8b17e52bed441b02a3c7489360d2_05e46daf5f1343da8c1f102f4ffbb33e : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _ba1c8b17e52bed441b02a3c7489360d2_05e46daf5f1343da8c1f102f4ffbb33e FromInterop(IntPtr data, int dataSize)
		{
			return default(_ba1c8b17e52bed441b02a3c7489360d2_05e46daf5f1343da8c1f102f4ffbb33e);
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

		public static void Serialize(_ba1c8b17e52bed441b02a3c7489360d2_05e46daf5f1343da8c1f102f4ffbb33e commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ba1c8b17e52bed441b02a3c7489360d2_05e46daf5f1343da8c1f102f4ffbb33e Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ba1c8b17e52bed441b02a3c7489360d2_05e46daf5f1343da8c1f102f4ffbb33e);
		}
	}
}
