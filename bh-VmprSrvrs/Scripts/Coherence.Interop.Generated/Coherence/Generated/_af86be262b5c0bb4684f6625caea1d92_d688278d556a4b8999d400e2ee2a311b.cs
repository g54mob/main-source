using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _af86be262b5c0bb4684f6625caea1d92_d688278d556a4b8999d400e2ee2a311b : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _af86be262b5c0bb4684f6625caea1d92_d688278d556a4b8999d400e2ee2a311b FromInterop(IntPtr data, int dataSize)
		{
			return default(_af86be262b5c0bb4684f6625caea1d92_d688278d556a4b8999d400e2ee2a311b);
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

		public _af86be262b5c0bb4684f6625caea1d92_d688278d556a4b8999d400e2ee2a311b(Entity entity, bool eraseItems, bool skipTriggers)
		{
			this.eraseItems = false;
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_af86be262b5c0bb4684f6625caea1d92_d688278d556a4b8999d400e2ee2a311b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _af86be262b5c0bb4684f6625caea1d92_d688278d556a4b8999d400e2ee2a311b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_af86be262b5c0bb4684f6625caea1d92_d688278d556a4b8999d400e2ee2a311b);
		}
	}
}
