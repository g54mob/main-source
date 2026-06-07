using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Core;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _f04546503722c8f4cb717afd85d8934e_cc9b38b79e234b6c856c077287345c0d : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public ByteArray sealedItems;
		}

		public byte[] sealedItems;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _f04546503722c8f4cb717afd85d8934e_cc9b38b79e234b6c856c077287345c0d FromInterop(IntPtr data, int dataSize)
		{
			return default(_f04546503722c8f4cb717afd85d8934e_cc9b38b79e234b6c856c077287345c0d);
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

		public _f04546503722c8f4cb717afd85d8934e_cc9b38b79e234b6c856c077287345c0d(Entity entity, byte[] sealedItems)
		{
			this.sealedItems = null;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_f04546503722c8f4cb717afd85d8934e_cc9b38b79e234b6c856c077287345c0d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _f04546503722c8f4cb717afd85d8934e_cc9b38b79e234b6c856c077287345c0d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_f04546503722c8f4cb717afd85d8934e_cc9b38b79e234b6c856c077287345c0d);
		}
	}
}
