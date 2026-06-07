using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _20bcb04d7eca75d4791a6b8471eb2720_8260e0658f114bfea2be117505e9f91d : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _20bcb04d7eca75d4791a6b8471eb2720_8260e0658f114bfea2be117505e9f91d FromInterop(IntPtr data, int dataSize)
		{
			return default(_20bcb04d7eca75d4791a6b8471eb2720_8260e0658f114bfea2be117505e9f91d);
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

		public static void Serialize(_20bcb04d7eca75d4791a6b8471eb2720_8260e0658f114bfea2be117505e9f91d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _20bcb04d7eca75d4791a6b8471eb2720_8260e0658f114bfea2be117505e9f91d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_20bcb04d7eca75d4791a6b8471eb2720_8260e0658f114bfea2be117505e9f91d);
		}
	}
}
