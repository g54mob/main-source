using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _d9e670cbbae31d541a45dd148cc1cfff_e592da964ce6417699c5fb6f72541e26 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _d9e670cbbae31d541a45dd148cc1cfff_e592da964ce6417699c5fb6f72541e26 FromInterop(IntPtr data, int dataSize)
		{
			return default(_d9e670cbbae31d541a45dd148cc1cfff_e592da964ce6417699c5fb6f72541e26);
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

		public static void Serialize(_d9e670cbbae31d541a45dd148cc1cfff_e592da964ce6417699c5fb6f72541e26 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _d9e670cbbae31d541a45dd148cc1cfff_e592da964ce6417699c5fb6f72541e26 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_d9e670cbbae31d541a45dd148cc1cfff_e592da964ce6417699c5fb6f72541e26);
		}
	}
}
