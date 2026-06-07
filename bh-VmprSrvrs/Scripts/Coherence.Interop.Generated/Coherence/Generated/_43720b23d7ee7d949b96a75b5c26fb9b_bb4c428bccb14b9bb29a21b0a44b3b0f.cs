using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _43720b23d7ee7d949b96a75b5c26fb9b_bb4c428bccb14b9bb29a21b0a44b3b0f : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public float damageAmount;
		}

		public float damageAmount;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _43720b23d7ee7d949b96a75b5c26fb9b_bb4c428bccb14b9bb29a21b0a44b3b0f FromInterop(IntPtr data, int dataSize)
		{
			return default(_43720b23d7ee7d949b96a75b5c26fb9b_bb4c428bccb14b9bb29a21b0a44b3b0f);
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

		public _43720b23d7ee7d949b96a75b5c26fb9b_bb4c428bccb14b9bb29a21b0a44b3b0f(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_43720b23d7ee7d949b96a75b5c26fb9b_bb4c428bccb14b9bb29a21b0a44b3b0f commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _43720b23d7ee7d949b96a75b5c26fb9b_bb4c428bccb14b9bb29a21b0a44b3b0f Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_43720b23d7ee7d949b96a75b5c26fb9b_bb4c428bccb14b9bb29a21b0a44b3b0f);
		}
	}
}
