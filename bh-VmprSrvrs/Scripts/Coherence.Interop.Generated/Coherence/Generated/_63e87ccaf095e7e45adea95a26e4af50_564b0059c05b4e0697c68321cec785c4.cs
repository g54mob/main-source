using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _63e87ccaf095e7e45adea95a26e4af50_564b0059c05b4e0697c68321cec785c4 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _63e87ccaf095e7e45adea95a26e4af50_564b0059c05b4e0697c68321cec785c4 FromInterop(IntPtr data, int dataSize)
		{
			return default(_63e87ccaf095e7e45adea95a26e4af50_564b0059c05b4e0697c68321cec785c4);
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

		public static void Serialize(_63e87ccaf095e7e45adea95a26e4af50_564b0059c05b4e0697c68321cec785c4 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _63e87ccaf095e7e45adea95a26e4af50_564b0059c05b4e0697c68321cec785c4 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_63e87ccaf095e7e45adea95a26e4af50_564b0059c05b4e0697c68321cec785c4);
		}
	}
}
