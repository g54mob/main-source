using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _1ee4e97c7eb3fda4a85f62cf386e89a5_48d0846ae3734ebfb9fb4f24c33d337e : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _1ee4e97c7eb3fda4a85f62cf386e89a5_48d0846ae3734ebfb9fb4f24c33d337e FromInterop(IntPtr data, int dataSize)
		{
			return default(_1ee4e97c7eb3fda4a85f62cf386e89a5_48d0846ae3734ebfb9fb4f24c33d337e);
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

		public static void Serialize(_1ee4e97c7eb3fda4a85f62cf386e89a5_48d0846ae3734ebfb9fb4f24c33d337e commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _1ee4e97c7eb3fda4a85f62cf386e89a5_48d0846ae3734ebfb9fb4f24c33d337e Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_1ee4e97c7eb3fda4a85f62cf386e89a5_48d0846ae3734ebfb9fb4f24c33d337e);
		}
	}
}
