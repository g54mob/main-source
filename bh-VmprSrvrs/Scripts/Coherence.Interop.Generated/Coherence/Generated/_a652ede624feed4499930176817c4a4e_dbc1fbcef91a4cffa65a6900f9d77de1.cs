using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a652ede624feed4499930176817c4a4e_dbc1fbcef91a4cffa65a6900f9d77de1 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _a652ede624feed4499930176817c4a4e_dbc1fbcef91a4cffa65a6900f9d77de1 FromInterop(IntPtr data, int dataSize)
		{
			return default(_a652ede624feed4499930176817c4a4e_dbc1fbcef91a4cffa65a6900f9d77de1);
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

		public static void Serialize(_a652ede624feed4499930176817c4a4e_dbc1fbcef91a4cffa65a6900f9d77de1 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a652ede624feed4499930176817c4a4e_dbc1fbcef91a4cffa65a6900f9d77de1 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a652ede624feed4499930176817c4a4e_dbc1fbcef91a4cffa65a6900f9d77de1);
		}
	}
}
