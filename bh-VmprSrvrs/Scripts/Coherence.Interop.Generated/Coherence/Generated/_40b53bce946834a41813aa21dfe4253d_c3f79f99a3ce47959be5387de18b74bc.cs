using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _40b53bce946834a41813aa21dfe4253d_c3f79f99a3ce47959be5387de18b74bc : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;
		}

		public long startingSimFrame;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _40b53bce946834a41813aa21dfe4253d_c3f79f99a3ce47959be5387de18b74bc FromInterop(IntPtr data, int dataSize)
		{
			return default(_40b53bce946834a41813aa21dfe4253d_c3f79f99a3ce47959be5387de18b74bc);
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

		public _40b53bce946834a41813aa21dfe4253d_c3f79f99a3ce47959be5387de18b74bc(Entity entity, long startingSimFrame)
		{
			this.startingSimFrame = 0L;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_40b53bce946834a41813aa21dfe4253d_c3f79f99a3ce47959be5387de18b74bc commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _40b53bce946834a41813aa21dfe4253d_c3f79f99a3ce47959be5387de18b74bc Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_40b53bce946834a41813aa21dfe4253d_c3f79f99a3ce47959be5387de18b74bc);
		}
	}
}
