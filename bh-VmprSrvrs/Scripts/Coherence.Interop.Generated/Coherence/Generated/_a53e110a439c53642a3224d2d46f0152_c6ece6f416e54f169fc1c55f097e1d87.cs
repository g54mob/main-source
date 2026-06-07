using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a53e110a439c53642a3224d2d46f0152_c6ece6f416e54f169fc1c55f097e1d87 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _a53e110a439c53642a3224d2d46f0152_c6ece6f416e54f169fc1c55f097e1d87 FromInterop(IntPtr data, int dataSize)
		{
			return default(_a53e110a439c53642a3224d2d46f0152_c6ece6f416e54f169fc1c55f097e1d87);
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

		public static void Serialize(_a53e110a439c53642a3224d2d46f0152_c6ece6f416e54f169fc1c55f097e1d87 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a53e110a439c53642a3224d2d46f0152_c6ece6f416e54f169fc1c55f097e1d87 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a53e110a439c53642a3224d2d46f0152_c6ece6f416e54f169fc1c55f097e1d87);
		}
	}
}
