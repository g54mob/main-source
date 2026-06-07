using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _3b1b4803df14c314f9c8257e88fcbf13_3ea96f48f3c94fc797b23b4d7cc37d2b : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _3b1b4803df14c314f9c8257e88fcbf13_3ea96f48f3c94fc797b23b4d7cc37d2b FromInterop(IntPtr data, int dataSize)
		{
			return default(_3b1b4803df14c314f9c8257e88fcbf13_3ea96f48f3c94fc797b23b4d7cc37d2b);
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

		public _3b1b4803df14c314f9c8257e88fcbf13_3ea96f48f3c94fc797b23b4d7cc37d2b(Entity entity, bool eraseItems, bool skipTriggers)
		{
			this.eraseItems = false;
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_3b1b4803df14c314f9c8257e88fcbf13_3ea96f48f3c94fc797b23b4d7cc37d2b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _3b1b4803df14c314f9c8257e88fcbf13_3ea96f48f3c94fc797b23b4d7cc37d2b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_3b1b4803df14c314f9c8257e88fcbf13_3ea96f48f3c94fc797b23b4d7cc37d2b);
		}
	}
}
