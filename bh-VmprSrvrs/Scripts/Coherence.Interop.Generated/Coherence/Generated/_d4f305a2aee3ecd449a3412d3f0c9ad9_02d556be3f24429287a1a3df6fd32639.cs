using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _d4f305a2aee3ecd449a3412d3f0c9ad9_02d556be3f24429287a1a3df6fd32639 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public byte instantRevival;
		}

		public long startingSimFrame;

		public bool instantRevival;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _d4f305a2aee3ecd449a3412d3f0c9ad9_02d556be3f24429287a1a3df6fd32639 FromInterop(IntPtr data, int dataSize)
		{
			return default(_d4f305a2aee3ecd449a3412d3f0c9ad9_02d556be3f24429287a1a3df6fd32639);
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

		public _d4f305a2aee3ecd449a3412d3f0c9ad9_02d556be3f24429287a1a3df6fd32639(Entity entity, long startingSimFrame, bool instantRevival)
		{
			this.startingSimFrame = 0L;
			this.instantRevival = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_d4f305a2aee3ecd449a3412d3f0c9ad9_02d556be3f24429287a1a3df6fd32639 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _d4f305a2aee3ecd449a3412d3f0c9ad9_02d556be3f24429287a1a3df6fd32639 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_d4f305a2aee3ecd449a3412d3f0c9ad9_02d556be3f24429287a1a3df6fd32639);
		}
	}
}
