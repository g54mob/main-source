using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _7f1c012c04ee36647ae6e7556c479b09_bfda58d31c2f48cdb86213ba0146b3f9 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _7f1c012c04ee36647ae6e7556c479b09_bfda58d31c2f48cdb86213ba0146b3f9 FromInterop(IntPtr data, int dataSize)
		{
			return default(_7f1c012c04ee36647ae6e7556c479b09_bfda58d31c2f48cdb86213ba0146b3f9);
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

		public static void Serialize(_7f1c012c04ee36647ae6e7556c479b09_bfda58d31c2f48cdb86213ba0146b3f9 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _7f1c012c04ee36647ae6e7556c479b09_bfda58d31c2f48cdb86213ba0146b3f9 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_7f1c012c04ee36647ae6e7556c479b09_bfda58d31c2f48cdb86213ba0146b3f9);
		}
	}
}
