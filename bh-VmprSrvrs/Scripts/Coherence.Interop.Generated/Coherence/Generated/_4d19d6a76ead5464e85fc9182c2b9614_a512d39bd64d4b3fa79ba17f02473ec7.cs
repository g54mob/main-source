using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _4d19d6a76ead5464e85fc9182c2b9614_a512d39bd64d4b3fa79ba17f02473ec7 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _4d19d6a76ead5464e85fc9182c2b9614_a512d39bd64d4b3fa79ba17f02473ec7 FromInterop(IntPtr data, int dataSize)
		{
			return default(_4d19d6a76ead5464e85fc9182c2b9614_a512d39bd64d4b3fa79ba17f02473ec7);
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

		public static void Serialize(_4d19d6a76ead5464e85fc9182c2b9614_a512d39bd64d4b3fa79ba17f02473ec7 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _4d19d6a76ead5464e85fc9182c2b9614_a512d39bd64d4b3fa79ba17f02473ec7 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_4d19d6a76ead5464e85fc9182c2b9614_a512d39bd64d4b3fa79ba17f02473ec7);
		}
	}
}
