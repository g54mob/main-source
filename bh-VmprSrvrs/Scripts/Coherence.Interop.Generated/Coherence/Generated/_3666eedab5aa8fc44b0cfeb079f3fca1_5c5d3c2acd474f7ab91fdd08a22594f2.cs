using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _3666eedab5aa8fc44b0cfeb079f3fca1_5c5d3c2acd474f7ab91fdd08a22594f2 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _3666eedab5aa8fc44b0cfeb079f3fca1_5c5d3c2acd474f7ab91fdd08a22594f2 FromInterop(IntPtr data, int dataSize)
		{
			return default(_3666eedab5aa8fc44b0cfeb079f3fca1_5c5d3c2acd474f7ab91fdd08a22594f2);
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

		public static void Serialize(_3666eedab5aa8fc44b0cfeb079f3fca1_5c5d3c2acd474f7ab91fdd08a22594f2 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _3666eedab5aa8fc44b0cfeb079f3fca1_5c5d3c2acd474f7ab91fdd08a22594f2 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_3666eedab5aa8fc44b0cfeb079f3fca1_5c5d3c2acd474f7ab91fdd08a22594f2);
		}
	}
}
