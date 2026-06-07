using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _183315916130b8948be02b0eecfa8bd7_d4bc43afff9d4765b626be2b4bf10a7b : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _183315916130b8948be02b0eecfa8bd7_d4bc43afff9d4765b626be2b4bf10a7b FromInterop(IntPtr data, int dataSize)
		{
			return default(_183315916130b8948be02b0eecfa8bd7_d4bc43afff9d4765b626be2b4bf10a7b);
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

		public static void Serialize(_183315916130b8948be02b0eecfa8bd7_d4bc43afff9d4765b626be2b4bf10a7b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _183315916130b8948be02b0eecfa8bd7_d4bc43afff9d4765b626be2b4bf10a7b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_183315916130b8948be02b0eecfa8bd7_d4bc43afff9d4765b626be2b4bf10a7b);
		}
	}
}
