using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ad325606f9c20fb4a828724c40cf9d36_826da8c6c11141d8b3188f2a4a10ae19 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public Entity player;
		}

		public long startingSimFrame;

		public Entity player;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _ad325606f9c20fb4a828724c40cf9d36_826da8c6c11141d8b3188f2a4a10ae19 FromInterop(IntPtr data, int dataSize)
		{
			return default(_ad325606f9c20fb4a828724c40cf9d36_826da8c6c11141d8b3188f2a4a10ae19);
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

		public _ad325606f9c20fb4a828724c40cf9d36_826da8c6c11141d8b3188f2a4a10ae19(Entity entity, long startingSimFrame, Entity player)
		{
			this.startingSimFrame = 0L;
			this.player = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_ad325606f9c20fb4a828724c40cf9d36_826da8c6c11141d8b3188f2a4a10ae19 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ad325606f9c20fb4a828724c40cf9d36_826da8c6c11141d8b3188f2a4a10ae19 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ad325606f9c20fb4a828724c40cf9d36_826da8c6c11141d8b3188f2a4a10ae19);
		}
	}
}
