using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a42f156792f891e4186ebc6d96ec8f5f_69fea2cb1a884218b0218761a548e2d7 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public float percentage;
		}

		public long startingSimFrame;

		public float percentage;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _a42f156792f891e4186ebc6d96ec8f5f_69fea2cb1a884218b0218761a548e2d7 FromInterop(IntPtr data, int dataSize)
		{
			return default(_a42f156792f891e4186ebc6d96ec8f5f_69fea2cb1a884218b0218761a548e2d7);
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

		public _a42f156792f891e4186ebc6d96ec8f5f_69fea2cb1a884218b0218761a548e2d7(Entity entity, long startingSimFrame, float percentage)
		{
			this.startingSimFrame = 0L;
			this.percentage = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_a42f156792f891e4186ebc6d96ec8f5f_69fea2cb1a884218b0218761a548e2d7 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a42f156792f891e4186ebc6d96ec8f5f_69fea2cb1a884218b0218761a548e2d7 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a42f156792f891e4186ebc6d96ec8f5f_69fea2cb1a884218b0218761a548e2d7);
		}
	}
}
