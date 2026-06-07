using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _288fba59c5ac81a4082f8a8ff001b3b2_53c421cde77f47e69cfa42863da44921 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _288fba59c5ac81a4082f8a8ff001b3b2_53c421cde77f47e69cfa42863da44921 FromInterop(IntPtr data, int dataSize)
		{
			return default(_288fba59c5ac81a4082f8a8ff001b3b2_53c421cde77f47e69cfa42863da44921);
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

		public static void Serialize(_288fba59c5ac81a4082f8a8ff001b3b2_53c421cde77f47e69cfa42863da44921 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _288fba59c5ac81a4082f8a8ff001b3b2_53c421cde77f47e69cfa42863da44921 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_288fba59c5ac81a4082f8a8ff001b3b2_53c421cde77f47e69cfa42863da44921);
		}
	}
}
