using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _aa8b165cabacc0042aced6f611ac8e53_7c73cb554d984d52b017ab011d070d51 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _aa8b165cabacc0042aced6f611ac8e53_7c73cb554d984d52b017ab011d070d51 FromInterop(IntPtr data, int dataSize)
		{
			return default(_aa8b165cabacc0042aced6f611ac8e53_7c73cb554d984d52b017ab011d070d51);
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

		public static void Serialize(_aa8b165cabacc0042aced6f611ac8e53_7c73cb554d984d52b017ab011d070d51 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _aa8b165cabacc0042aced6f611ac8e53_7c73cb554d984d52b017ab011d070d51 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_aa8b165cabacc0042aced6f611ac8e53_7c73cb554d984d52b017ab011d070d51);
		}
	}
}
