using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _49890ed44d1bdf44096c0c292df0a92d_0902b566ea9c458795b8535e6678c6a7 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _49890ed44d1bdf44096c0c292df0a92d_0902b566ea9c458795b8535e6678c6a7 FromInterop(IntPtr data, int dataSize)
		{
			return default(_49890ed44d1bdf44096c0c292df0a92d_0902b566ea9c458795b8535e6678c6a7);
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

		public _49890ed44d1bdf44096c0c292df0a92d_0902b566ea9c458795b8535e6678c6a7(Entity entity, long startingSimFrame, bool instantRevival)
		{
			this.startingSimFrame = 0L;
			this.instantRevival = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_49890ed44d1bdf44096c0c292df0a92d_0902b566ea9c458795b8535e6678c6a7 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _49890ed44d1bdf44096c0c292df0a92d_0902b566ea9c458795b8535e6678c6a7 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_49890ed44d1bdf44096c0c292df0a92d_0902b566ea9c458795b8535e6678c6a7);
		}
	}
}
