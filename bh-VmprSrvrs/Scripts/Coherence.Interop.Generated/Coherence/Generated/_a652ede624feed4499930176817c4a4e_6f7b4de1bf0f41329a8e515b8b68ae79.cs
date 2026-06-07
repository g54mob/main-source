using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a652ede624feed4499930176817c4a4e_6f7b4de1bf0f41329a8e515b8b68ae79 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long frame;

			[FieldOffset(8)]
			public int weaponType;
		}

		public long frame;

		public int weaponType;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _a652ede624feed4499930176817c4a4e_6f7b4de1bf0f41329a8e515b8b68ae79 FromInterop(IntPtr data, int dataSize)
		{
			return default(_a652ede624feed4499930176817c4a4e_6f7b4de1bf0f41329a8e515b8b68ae79);
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

		public _a652ede624feed4499930176817c4a4e_6f7b4de1bf0f41329a8e515b8b68ae79(Entity entity, long frame, int weaponType)
		{
			this.frame = 0L;
			this.weaponType = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_a652ede624feed4499930176817c4a4e_6f7b4de1bf0f41329a8e515b8b68ae79 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a652ede624feed4499930176817c4a4e_6f7b4de1bf0f41329a8e515b8b68ae79 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a652ede624feed4499930176817c4a4e_6f7b4de1bf0f41329a8e515b8b68ae79);
		}
	}
}
