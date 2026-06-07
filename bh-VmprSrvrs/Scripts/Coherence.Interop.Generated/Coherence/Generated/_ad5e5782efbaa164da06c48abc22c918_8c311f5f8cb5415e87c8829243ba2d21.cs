using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ad5e5782efbaa164da06c48abc22c918_8c311f5f8cb5415e87c8829243ba2d21 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _ad5e5782efbaa164da06c48abc22c918_8c311f5f8cb5415e87c8829243ba2d21 FromInterop(IntPtr data, int dataSize)
		{
			return default(_ad5e5782efbaa164da06c48abc22c918_8c311f5f8cb5415e87c8829243ba2d21);
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

		public static void Serialize(_ad5e5782efbaa164da06c48abc22c918_8c311f5f8cb5415e87c8829243ba2d21 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ad5e5782efbaa164da06c48abc22c918_8c311f5f8cb5415e87c8829243ba2d21 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ad5e5782efbaa164da06c48abc22c918_8c311f5f8cb5415e87c8829243ba2d21);
		}
	}
}
