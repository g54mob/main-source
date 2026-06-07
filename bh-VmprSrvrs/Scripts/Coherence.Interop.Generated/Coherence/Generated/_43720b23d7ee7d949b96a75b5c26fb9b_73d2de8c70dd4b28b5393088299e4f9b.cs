using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _43720b23d7ee7d949b96a75b5c26fb9b_73d2de8c70dd4b28b5393088299e4f9b : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public int weaponType;
		}

		public long startingSimFrame;

		public int weaponType;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _43720b23d7ee7d949b96a75b5c26fb9b_73d2de8c70dd4b28b5393088299e4f9b FromInterop(IntPtr data, int dataSize)
		{
			return default(_43720b23d7ee7d949b96a75b5c26fb9b_73d2de8c70dd4b28b5393088299e4f9b);
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

		public _43720b23d7ee7d949b96a75b5c26fb9b_73d2de8c70dd4b28b5393088299e4f9b(Entity entity, long startingSimFrame, int weaponType)
		{
			this.startingSimFrame = 0L;
			this.weaponType = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_43720b23d7ee7d949b96a75b5c26fb9b_73d2de8c70dd4b28b5393088299e4f9b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _43720b23d7ee7d949b96a75b5c26fb9b_73d2de8c70dd4b28b5393088299e4f9b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_43720b23d7ee7d949b96a75b5c26fb9b_73d2de8c70dd4b28b5393088299e4f9b);
		}
	}
}
