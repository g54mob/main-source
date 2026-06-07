using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _f15f79c39e404b443a561f650ec6e91d_805ddab70f664a6594dde8d0f63c9134 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _f15f79c39e404b443a561f650ec6e91d_805ddab70f664a6594dde8d0f63c9134 FromInterop(IntPtr data, int dataSize)
		{
			return default(_f15f79c39e404b443a561f650ec6e91d_805ddab70f664a6594dde8d0f63c9134);
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

		public static void Serialize(_f15f79c39e404b443a561f650ec6e91d_805ddab70f664a6594dde8d0f63c9134 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _f15f79c39e404b443a561f650ec6e91d_805ddab70f664a6594dde8d0f63c9134 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_f15f79c39e404b443a561f650ec6e91d_805ddab70f664a6594dde8d0f63c9134);
		}
	}
}
