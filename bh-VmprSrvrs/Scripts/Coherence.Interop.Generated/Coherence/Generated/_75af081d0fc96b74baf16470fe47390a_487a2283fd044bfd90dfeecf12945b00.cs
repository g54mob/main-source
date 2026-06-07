using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _75af081d0fc96b74baf16470fe47390a_487a2283fd044bfd90dfeecf12945b00 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _75af081d0fc96b74baf16470fe47390a_487a2283fd044bfd90dfeecf12945b00 FromInterop(IntPtr data, int dataSize)
		{
			return default(_75af081d0fc96b74baf16470fe47390a_487a2283fd044bfd90dfeecf12945b00);
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

		public _75af081d0fc96b74baf16470fe47390a_487a2283fd044bfd90dfeecf12945b00(Entity entity, long startingSimFrame)
		{
			this.startingSimFrame = 0L;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_75af081d0fc96b74baf16470fe47390a_487a2283fd044bfd90dfeecf12945b00 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _75af081d0fc96b74baf16470fe47390a_487a2283fd044bfd90dfeecf12945b00 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_75af081d0fc96b74baf16470fe47390a_487a2283fd044bfd90dfeecf12945b00);
		}
	}
}
