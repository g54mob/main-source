using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _1ee4e97c7eb3fda4a85f62cf386e89a5_409aef55e8e74feba80d4d53f4a01adf : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public byte eraseItems;

			[FieldOffset(1)]
			public byte skipTriggers;
		}

		public bool eraseItems;

		public bool skipTriggers;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _1ee4e97c7eb3fda4a85f62cf386e89a5_409aef55e8e74feba80d4d53f4a01adf FromInterop(IntPtr data, int dataSize)
		{
			return default(_1ee4e97c7eb3fda4a85f62cf386e89a5_409aef55e8e74feba80d4d53f4a01adf);
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

		public _1ee4e97c7eb3fda4a85f62cf386e89a5_409aef55e8e74feba80d4d53f4a01adf(Entity entity, bool eraseItems, bool skipTriggers)
		{
			this.eraseItems = false;
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_1ee4e97c7eb3fda4a85f62cf386e89a5_409aef55e8e74feba80d4d53f4a01adf commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _1ee4e97c7eb3fda4a85f62cf386e89a5_409aef55e8e74feba80d4d53f4a01adf Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_1ee4e97c7eb3fda4a85f62cf386e89a5_409aef55e8e74feba80d4d53f4a01adf);
		}
	}
}
