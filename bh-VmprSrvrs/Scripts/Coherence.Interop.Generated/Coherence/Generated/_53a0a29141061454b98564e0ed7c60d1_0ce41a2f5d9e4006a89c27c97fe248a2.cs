using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _53a0a29141061454b98564e0ed7c60d1_0ce41a2f5d9e4006a89c27c97fe248a2 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _53a0a29141061454b98564e0ed7c60d1_0ce41a2f5d9e4006a89c27c97fe248a2 FromInterop(IntPtr data, int dataSize)
		{
			return default(_53a0a29141061454b98564e0ed7c60d1_0ce41a2f5d9e4006a89c27c97fe248a2);
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

		public static void Serialize(_53a0a29141061454b98564e0ed7c60d1_0ce41a2f5d9e4006a89c27c97fe248a2 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _53a0a29141061454b98564e0ed7c60d1_0ce41a2f5d9e4006a89c27c97fe248a2 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_53a0a29141061454b98564e0ed7c60d1_0ce41a2f5d9e4006a89c27c97fe248a2);
		}
	}
}
