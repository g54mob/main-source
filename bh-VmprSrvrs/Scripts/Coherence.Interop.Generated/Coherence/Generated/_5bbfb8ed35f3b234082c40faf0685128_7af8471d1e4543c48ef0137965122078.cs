using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _5bbfb8ed35f3b234082c40faf0685128_7af8471d1e4543c48ef0137965122078 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public uint clientId;
		}

		public uint clientId;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _5bbfb8ed35f3b234082c40faf0685128_7af8471d1e4543c48ef0137965122078 FromInterop(IntPtr data, int dataSize)
		{
			return default(_5bbfb8ed35f3b234082c40faf0685128_7af8471d1e4543c48ef0137965122078);
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

		public _5bbfb8ed35f3b234082c40faf0685128_7af8471d1e4543c48ef0137965122078(Entity entity, uint clientId)
		{
			this.clientId = 0u;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_5bbfb8ed35f3b234082c40faf0685128_7af8471d1e4543c48ef0137965122078 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _5bbfb8ed35f3b234082c40faf0685128_7af8471d1e4543c48ef0137965122078 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_5bbfb8ed35f3b234082c40faf0685128_7af8471d1e4543c48ef0137965122078);
		}
	}
}
