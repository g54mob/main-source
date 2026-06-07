using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a42f156792f891e4186ebc6d96ec8f5f_eaf86bedad404de583db7c0c8dcd784a : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _a42f156792f891e4186ebc6d96ec8f5f_eaf86bedad404de583db7c0c8dcd784a FromInterop(IntPtr data, int dataSize)
		{
			return default(_a42f156792f891e4186ebc6d96ec8f5f_eaf86bedad404de583db7c0c8dcd784a);
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

		public _a42f156792f891e4186ebc6d96ec8f5f_eaf86bedad404de583db7c0c8dcd784a(Entity entity, bool eraseItems, bool skipTriggers)
		{
			this.eraseItems = false;
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_a42f156792f891e4186ebc6d96ec8f5f_eaf86bedad404de583db7c0c8dcd784a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a42f156792f891e4186ebc6d96ec8f5f_eaf86bedad404de583db7c0c8dcd784a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a42f156792f891e4186ebc6d96ec8f5f_eaf86bedad404de583db7c0c8dcd784a);
		}
	}
}
