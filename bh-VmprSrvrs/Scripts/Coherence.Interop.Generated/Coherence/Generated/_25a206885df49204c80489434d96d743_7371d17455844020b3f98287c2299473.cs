using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _25a206885df49204c80489434d96d743_7371d17455844020b3f98287c2299473 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _25a206885df49204c80489434d96d743_7371d17455844020b3f98287c2299473 FromInterop(IntPtr data, int dataSize)
		{
			return default(_25a206885df49204c80489434d96d743_7371d17455844020b3f98287c2299473);
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

		public static void Serialize(_25a206885df49204c80489434d96d743_7371d17455844020b3f98287c2299473 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _25a206885df49204c80489434d96d743_7371d17455844020b3f98287c2299473 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_25a206885df49204c80489434d96d743_7371d17455844020b3f98287c2299473);
		}
	}
}
