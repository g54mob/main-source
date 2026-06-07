using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ee7f4f9f85f02314a99817abb3181c1a_6fad9165358044c68904e483609ca91a : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _ee7f4f9f85f02314a99817abb3181c1a_6fad9165358044c68904e483609ca91a FromInterop(IntPtr data, int dataSize)
		{
			return default(_ee7f4f9f85f02314a99817abb3181c1a_6fad9165358044c68904e483609ca91a);
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

		public static void Serialize(_ee7f4f9f85f02314a99817abb3181c1a_6fad9165358044c68904e483609ca91a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ee7f4f9f85f02314a99817abb3181c1a_6fad9165358044c68904e483609ca91a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ee7f4f9f85f02314a99817abb3181c1a_6fad9165358044c68904e483609ca91a);
		}
	}
}
