using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _4af6860640899fa4398db18d20d22593_1d8c8cc97f434ac1aa57ec2ed06d9adb : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _4af6860640899fa4398db18d20d22593_1d8c8cc97f434ac1aa57ec2ed06d9adb FromInterop(IntPtr data, int dataSize)
		{
			return default(_4af6860640899fa4398db18d20d22593_1d8c8cc97f434ac1aa57ec2ed06d9adb);
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

		public static void Serialize(_4af6860640899fa4398db18d20d22593_1d8c8cc97f434ac1aa57ec2ed06d9adb commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _4af6860640899fa4398db18d20d22593_1d8c8cc97f434ac1aa57ec2ed06d9adb Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_4af6860640899fa4398db18d20d22593_1d8c8cc97f434ac1aa57ec2ed06d9adb);
		}
	}
}
