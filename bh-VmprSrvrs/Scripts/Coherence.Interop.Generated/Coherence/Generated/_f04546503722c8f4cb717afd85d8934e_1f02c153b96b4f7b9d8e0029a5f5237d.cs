using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Core;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _f04546503722c8f4cb717afd85d8934e_1f02c153b96b4f7b9d8e0029a5f5237d : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public ByteArray unlockedStages;
		}

		public byte[] unlockedStages;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _f04546503722c8f4cb717afd85d8934e_1f02c153b96b4f7b9d8e0029a5f5237d FromInterop(IntPtr data, int dataSize)
		{
			return default(_f04546503722c8f4cb717afd85d8934e_1f02c153b96b4f7b9d8e0029a5f5237d);
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

		public _f04546503722c8f4cb717afd85d8934e_1f02c153b96b4f7b9d8e0029a5f5237d(Entity entity, byte[] unlockedStages)
		{
			this.unlockedStages = null;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_f04546503722c8f4cb717afd85d8934e_1f02c153b96b4f7b9d8e0029a5f5237d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _f04546503722c8f4cb717afd85d8934e_1f02c153b96b4f7b9d8e0029a5f5237d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_f04546503722c8f4cb717afd85d8934e_1f02c153b96b4f7b9d8e0029a5f5237d);
		}
	}
}
