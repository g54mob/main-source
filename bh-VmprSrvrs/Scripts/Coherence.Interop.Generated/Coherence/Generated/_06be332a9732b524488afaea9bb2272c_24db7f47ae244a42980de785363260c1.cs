using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _06be332a9732b524488afaea9bb2272c_24db7f47ae244a42980de785363260c1 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _06be332a9732b524488afaea9bb2272c_24db7f47ae244a42980de785363260c1 FromInterop(IntPtr data, int dataSize)
		{
			return default(_06be332a9732b524488afaea9bb2272c_24db7f47ae244a42980de785363260c1);
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

		public static void Serialize(_06be332a9732b524488afaea9bb2272c_24db7f47ae244a42980de785363260c1 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _06be332a9732b524488afaea9bb2272c_24db7f47ae244a42980de785363260c1 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_06be332a9732b524488afaea9bb2272c_24db7f47ae244a42980de785363260c1);
		}
	}
}
