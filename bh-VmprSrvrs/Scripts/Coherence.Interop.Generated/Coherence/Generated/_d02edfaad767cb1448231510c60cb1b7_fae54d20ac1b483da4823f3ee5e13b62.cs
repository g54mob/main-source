using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _d02edfaad767cb1448231510c60cb1b7_fae54d20ac1b483da4823f3ee5e13b62 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _d02edfaad767cb1448231510c60cb1b7_fae54d20ac1b483da4823f3ee5e13b62 FromInterop(IntPtr data, int dataSize)
		{
			return default(_d02edfaad767cb1448231510c60cb1b7_fae54d20ac1b483da4823f3ee5e13b62);
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

		public static void Serialize(_d02edfaad767cb1448231510c60cb1b7_fae54d20ac1b483da4823f3ee5e13b62 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _d02edfaad767cb1448231510c60cb1b7_fae54d20ac1b483da4823f3ee5e13b62 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_d02edfaad767cb1448231510c60cb1b7_fae54d20ac1b483da4823f3ee5e13b62);
		}
	}
}
