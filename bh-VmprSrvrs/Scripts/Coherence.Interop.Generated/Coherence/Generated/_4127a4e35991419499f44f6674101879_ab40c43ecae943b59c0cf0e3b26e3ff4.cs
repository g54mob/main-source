using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _4127a4e35991419499f44f6674101879_ab40c43ecae943b59c0cf0e3b26e3ff4 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _4127a4e35991419499f44f6674101879_ab40c43ecae943b59c0cf0e3b26e3ff4 FromInterop(IntPtr data, int dataSize)
		{
			return default(_4127a4e35991419499f44f6674101879_ab40c43ecae943b59c0cf0e3b26e3ff4);
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

		public static void Serialize(_4127a4e35991419499f44f6674101879_ab40c43ecae943b59c0cf0e3b26e3ff4 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _4127a4e35991419499f44f6674101879_ab40c43ecae943b59c0cf0e3b26e3ff4 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_4127a4e35991419499f44f6674101879_ab40c43ecae943b59c0cf0e3b26e3ff4);
		}
	}
}
