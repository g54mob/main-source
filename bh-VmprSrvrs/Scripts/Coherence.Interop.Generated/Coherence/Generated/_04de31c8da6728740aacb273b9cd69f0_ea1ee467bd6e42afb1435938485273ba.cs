using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _04de31c8da6728740aacb273b9cd69f0_ea1ee467bd6e42afb1435938485273ba : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _04de31c8da6728740aacb273b9cd69f0_ea1ee467bd6e42afb1435938485273ba FromInterop(IntPtr data, int dataSize)
		{
			return default(_04de31c8da6728740aacb273b9cd69f0_ea1ee467bd6e42afb1435938485273ba);
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

		public static void Serialize(_04de31c8da6728740aacb273b9cd69f0_ea1ee467bd6e42afb1435938485273ba commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _04de31c8da6728740aacb273b9cd69f0_ea1ee467bd6e42afb1435938485273ba Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_04de31c8da6728740aacb273b9cd69f0_ea1ee467bd6e42afb1435938485273ba);
		}
	}
}
