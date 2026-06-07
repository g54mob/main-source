using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _c1017fb45e8abba4f83a940a3e8f5905_f370c8ccd89946f9bb71b157956c1919 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _c1017fb45e8abba4f83a940a3e8f5905_f370c8ccd89946f9bb71b157956c1919 FromInterop(IntPtr data, int dataSize)
		{
			return default(_c1017fb45e8abba4f83a940a3e8f5905_f370c8ccd89946f9bb71b157956c1919);
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

		public static void Serialize(_c1017fb45e8abba4f83a940a3e8f5905_f370c8ccd89946f9bb71b157956c1919 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _c1017fb45e8abba4f83a940a3e8f5905_f370c8ccd89946f9bb71b157956c1919 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_c1017fb45e8abba4f83a940a3e8f5905_f370c8ccd89946f9bb71b157956c1919);
		}
	}
}
