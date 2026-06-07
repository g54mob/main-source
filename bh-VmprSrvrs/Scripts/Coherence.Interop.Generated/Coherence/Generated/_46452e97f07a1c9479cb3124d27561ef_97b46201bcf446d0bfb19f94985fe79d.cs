using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _46452e97f07a1c9479cb3124d27561ef_97b46201bcf446d0bfb19f94985fe79d : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _46452e97f07a1c9479cb3124d27561ef_97b46201bcf446d0bfb19f94985fe79d FromInterop(IntPtr data, int dataSize)
		{
			return default(_46452e97f07a1c9479cb3124d27561ef_97b46201bcf446d0bfb19f94985fe79d);
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

		public static void Serialize(_46452e97f07a1c9479cb3124d27561ef_97b46201bcf446d0bfb19f94985fe79d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _46452e97f07a1c9479cb3124d27561ef_97b46201bcf446d0bfb19f94985fe79d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_46452e97f07a1c9479cb3124d27561ef_97b46201bcf446d0bfb19f94985fe79d);
		}
	}
}
