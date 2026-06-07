using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _66c7ea260d90fcb4e9fef1c5cc7f6533_777509b2313444adb2e4e7741641402f : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _66c7ea260d90fcb4e9fef1c5cc7f6533_777509b2313444adb2e4e7741641402f FromInterop(IntPtr data, int dataSize)
		{
			return default(_66c7ea260d90fcb4e9fef1c5cc7f6533_777509b2313444adb2e4e7741641402f);
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

		public static void Serialize(_66c7ea260d90fcb4e9fef1c5cc7f6533_777509b2313444adb2e4e7741641402f commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _66c7ea260d90fcb4e9fef1c5cc7f6533_777509b2313444adb2e4e7741641402f Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_66c7ea260d90fcb4e9fef1c5cc7f6533_777509b2313444adb2e4e7741641402f);
		}
	}
}
