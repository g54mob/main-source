using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _b07e08b354bd89a43a1c9f3f4732fc96_0c7129be8bbd4d779093c0927f38e43d : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _b07e08b354bd89a43a1c9f3f4732fc96_0c7129be8bbd4d779093c0927f38e43d FromInterop(IntPtr data, int dataSize)
		{
			return default(_b07e08b354bd89a43a1c9f3f4732fc96_0c7129be8bbd4d779093c0927f38e43d);
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

		public static void Serialize(_b07e08b354bd89a43a1c9f3f4732fc96_0c7129be8bbd4d779093c0927f38e43d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _b07e08b354bd89a43a1c9f3f4732fc96_0c7129be8bbd4d779093c0927f38e43d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_b07e08b354bd89a43a1c9f3f4732fc96_0c7129be8bbd4d779093c0927f38e43d);
		}
	}
}
