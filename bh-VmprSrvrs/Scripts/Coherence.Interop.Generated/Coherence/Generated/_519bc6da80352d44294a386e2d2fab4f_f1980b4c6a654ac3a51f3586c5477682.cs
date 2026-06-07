using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _519bc6da80352d44294a386e2d2fab4f_f1980b4c6a654ac3a51f3586c5477682 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _519bc6da80352d44294a386e2d2fab4f_f1980b4c6a654ac3a51f3586c5477682 FromInterop(IntPtr data, int dataSize)
		{
			return default(_519bc6da80352d44294a386e2d2fab4f_f1980b4c6a654ac3a51f3586c5477682);
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

		public static void Serialize(_519bc6da80352d44294a386e2d2fab4f_f1980b4c6a654ac3a51f3586c5477682 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _519bc6da80352d44294a386e2d2fab4f_f1980b4c6a654ac3a51f3586c5477682 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_519bc6da80352d44294a386e2d2fab4f_f1980b4c6a654ac3a51f3586c5477682);
		}
	}
}
