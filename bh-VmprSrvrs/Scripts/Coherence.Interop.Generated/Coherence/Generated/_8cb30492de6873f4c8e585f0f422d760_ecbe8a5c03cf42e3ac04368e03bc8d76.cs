using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _8cb30492de6873f4c8e585f0f422d760_ecbe8a5c03cf42e3ac04368e03bc8d76 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _8cb30492de6873f4c8e585f0f422d760_ecbe8a5c03cf42e3ac04368e03bc8d76 FromInterop(IntPtr data, int dataSize)
		{
			return default(_8cb30492de6873f4c8e585f0f422d760_ecbe8a5c03cf42e3ac04368e03bc8d76);
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

		public static void Serialize(_8cb30492de6873f4c8e585f0f422d760_ecbe8a5c03cf42e3ac04368e03bc8d76 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _8cb30492de6873f4c8e585f0f422d760_ecbe8a5c03cf42e3ac04368e03bc8d76 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_8cb30492de6873f4c8e585f0f422d760_ecbe8a5c03cf42e3ac04368e03bc8d76);
		}
	}
}
