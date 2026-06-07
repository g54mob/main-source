using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _96928f9678c3c4d499d936f24357008f_2a46a2778ae54c7d8230a21eb72e7926 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _96928f9678c3c4d499d936f24357008f_2a46a2778ae54c7d8230a21eb72e7926 FromInterop(IntPtr data, int dataSize)
		{
			return default(_96928f9678c3c4d499d936f24357008f_2a46a2778ae54c7d8230a21eb72e7926);
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

		public static void Serialize(_96928f9678c3c4d499d936f24357008f_2a46a2778ae54c7d8230a21eb72e7926 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _96928f9678c3c4d499d936f24357008f_2a46a2778ae54c7d8230a21eb72e7926 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_96928f9678c3c4d499d936f24357008f_2a46a2778ae54c7d8230a21eb72e7926);
		}
	}
}
