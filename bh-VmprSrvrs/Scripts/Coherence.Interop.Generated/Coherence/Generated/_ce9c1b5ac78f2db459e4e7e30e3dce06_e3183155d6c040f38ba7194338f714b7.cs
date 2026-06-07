using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ce9c1b5ac78f2db459e4e7e30e3dce06_e3183155d6c040f38ba7194338f714b7 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _ce9c1b5ac78f2db459e4e7e30e3dce06_e3183155d6c040f38ba7194338f714b7 FromInterop(IntPtr data, int dataSize)
		{
			return default(_ce9c1b5ac78f2db459e4e7e30e3dce06_e3183155d6c040f38ba7194338f714b7);
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

		public static void Serialize(_ce9c1b5ac78f2db459e4e7e30e3dce06_e3183155d6c040f38ba7194338f714b7 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ce9c1b5ac78f2db459e4e7e30e3dce06_e3183155d6c040f38ba7194338f714b7 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ce9c1b5ac78f2db459e4e7e30e3dce06_e3183155d6c040f38ba7194338f714b7);
		}
	}
}
