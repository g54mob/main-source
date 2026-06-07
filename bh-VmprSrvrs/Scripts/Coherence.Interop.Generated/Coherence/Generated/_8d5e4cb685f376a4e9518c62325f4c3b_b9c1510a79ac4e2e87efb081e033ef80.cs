using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _8d5e4cb685f376a4e9518c62325f4c3b_b9c1510a79ac4e2e87efb081e033ef80 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _8d5e4cb685f376a4e9518c62325f4c3b_b9c1510a79ac4e2e87efb081e033ef80 FromInterop(IntPtr data, int dataSize)
		{
			return default(_8d5e4cb685f376a4e9518c62325f4c3b_b9c1510a79ac4e2e87efb081e033ef80);
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

		public static void Serialize(_8d5e4cb685f376a4e9518c62325f4c3b_b9c1510a79ac4e2e87efb081e033ef80 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _8d5e4cb685f376a4e9518c62325f4c3b_b9c1510a79ac4e2e87efb081e033ef80 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_8d5e4cb685f376a4e9518c62325f4c3b_b9c1510a79ac4e2e87efb081e033ef80);
		}
	}
}
