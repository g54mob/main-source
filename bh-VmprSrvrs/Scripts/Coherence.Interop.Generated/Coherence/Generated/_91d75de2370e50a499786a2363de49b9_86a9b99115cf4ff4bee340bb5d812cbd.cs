using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Core;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _91d75de2370e50a499786a2363de49b9_86a9b99115cf4ff4bee340bb5d812cbd : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public Entity boss;

			[FieldOffset(4)]
			public byte hasChains;

			[FieldOffset(5)]
			public ByteArray spriteName;

			[FieldOffset(21)]
			public byte isHead;
		}

		public Entity boss;

		public bool hasChains;

		public string spriteName;

		public bool isHead;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _91d75de2370e50a499786a2363de49b9_86a9b99115cf4ff4bee340bb5d812cbd FromInterop(IntPtr data, int dataSize)
		{
			return default(_91d75de2370e50a499786a2363de49b9_86a9b99115cf4ff4bee340bb5d812cbd);
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

		public _91d75de2370e50a499786a2363de49b9_86a9b99115cf4ff4bee340bb5d812cbd(Entity entity, Entity boss, bool hasChains, string spriteName, bool isHead)
		{
			this.boss = default(Entity);
			this.hasChains = false;
			this.spriteName = null;
			this.isHead = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_91d75de2370e50a499786a2363de49b9_86a9b99115cf4ff4bee340bb5d812cbd commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _91d75de2370e50a499786a2363de49b9_86a9b99115cf4ff4bee340bb5d812cbd Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_91d75de2370e50a499786a2363de49b9_86a9b99115cf4ff4bee340bb5d812cbd);
		}
	}
}
