using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a8691ffe7622e63479163bbb92472346_d232a9b6b36745ea929d407a24278b37 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _a8691ffe7622e63479163bbb92472346_d232a9b6b36745ea929d407a24278b37 FromInterop(IntPtr data, int dataSize)
		{
			return default(_a8691ffe7622e63479163bbb92472346_d232a9b6b36745ea929d407a24278b37);
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

		public static void Serialize(_a8691ffe7622e63479163bbb92472346_d232a9b6b36745ea929d407a24278b37 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a8691ffe7622e63479163bbb92472346_d232a9b6b36745ea929d407a24278b37 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a8691ffe7622e63479163bbb92472346_d232a9b6b36745ea929d407a24278b37);
		}
	}
}
