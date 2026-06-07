using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _d560f31ab1f8a314abb47afabd725958_ccac8c62127847248bc25fd59b903893 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _d560f31ab1f8a314abb47afabd725958_ccac8c62127847248bc25fd59b903893 FromInterop(IntPtr data, int dataSize)
		{
			return default(_d560f31ab1f8a314abb47afabd725958_ccac8c62127847248bc25fd59b903893);
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

		public static void Serialize(_d560f31ab1f8a314abb47afabd725958_ccac8c62127847248bc25fd59b903893 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _d560f31ab1f8a314abb47afabd725958_ccac8c62127847248bc25fd59b903893 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_d560f31ab1f8a314abb47afabd725958_ccac8c62127847248bc25fd59b903893);
		}
	}
}
