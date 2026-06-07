using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _41c1970ce948ae942875b8332185ec4c_7887db1d490e4bacae2b3509ca2a5ec9 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _41c1970ce948ae942875b8332185ec4c_7887db1d490e4bacae2b3509ca2a5ec9 FromInterop(IntPtr data, int dataSize)
		{
			return default(_41c1970ce948ae942875b8332185ec4c_7887db1d490e4bacae2b3509ca2a5ec9);
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

		public static void Serialize(_41c1970ce948ae942875b8332185ec4c_7887db1d490e4bacae2b3509ca2a5ec9 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _41c1970ce948ae942875b8332185ec4c_7887db1d490e4bacae2b3509ca2a5ec9 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_41c1970ce948ae942875b8332185ec4c_7887db1d490e4bacae2b3509ca2a5ec9);
		}
	}
}
