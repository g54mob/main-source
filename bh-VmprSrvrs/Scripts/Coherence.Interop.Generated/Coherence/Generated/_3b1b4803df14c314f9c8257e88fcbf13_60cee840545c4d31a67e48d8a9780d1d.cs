using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _3b1b4803df14c314f9c8257e88fcbf13_60cee840545c4d31a67e48d8a9780d1d : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _3b1b4803df14c314f9c8257e88fcbf13_60cee840545c4d31a67e48d8a9780d1d FromInterop(IntPtr data, int dataSize)
		{
			return default(_3b1b4803df14c314f9c8257e88fcbf13_60cee840545c4d31a67e48d8a9780d1d);
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

		public static void Serialize(_3b1b4803df14c314f9c8257e88fcbf13_60cee840545c4d31a67e48d8a9780d1d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _3b1b4803df14c314f9c8257e88fcbf13_60cee840545c4d31a67e48d8a9780d1d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_3b1b4803df14c314f9c8257e88fcbf13_60cee840545c4d31a67e48d8a9780d1d);
		}
	}
}
