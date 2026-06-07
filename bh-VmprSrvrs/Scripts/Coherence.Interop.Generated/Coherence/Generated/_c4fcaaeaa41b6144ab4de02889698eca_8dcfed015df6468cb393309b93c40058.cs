using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _c4fcaaeaa41b6144ab4de02889698eca_8dcfed015df6468cb393309b93c40058 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _c4fcaaeaa41b6144ab4de02889698eca_8dcfed015df6468cb393309b93c40058 FromInterop(IntPtr data, int dataSize)
		{
			return default(_c4fcaaeaa41b6144ab4de02889698eca_8dcfed015df6468cb393309b93c40058);
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

		public static void Serialize(_c4fcaaeaa41b6144ab4de02889698eca_8dcfed015df6468cb393309b93c40058 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _c4fcaaeaa41b6144ab4de02889698eca_8dcfed015df6468cb393309b93c40058 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_c4fcaaeaa41b6144ab4de02889698eca_8dcfed015df6468cb393309b93c40058);
		}
	}
}
