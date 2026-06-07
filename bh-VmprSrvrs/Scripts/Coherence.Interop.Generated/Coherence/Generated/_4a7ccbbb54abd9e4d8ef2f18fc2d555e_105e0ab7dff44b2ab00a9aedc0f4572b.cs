using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _4a7ccbbb54abd9e4d8ef2f18fc2d555e_105e0ab7dff44b2ab00a9aedc0f4572b : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _4a7ccbbb54abd9e4d8ef2f18fc2d555e_105e0ab7dff44b2ab00a9aedc0f4572b FromInterop(IntPtr data, int dataSize)
		{
			return default(_4a7ccbbb54abd9e4d8ef2f18fc2d555e_105e0ab7dff44b2ab00a9aedc0f4572b);
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

		public static void Serialize(_4a7ccbbb54abd9e4d8ef2f18fc2d555e_105e0ab7dff44b2ab00a9aedc0f4572b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _4a7ccbbb54abd9e4d8ef2f18fc2d555e_105e0ab7dff44b2ab00a9aedc0f4572b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_4a7ccbbb54abd9e4d8ef2f18fc2d555e_105e0ab7dff44b2ab00a9aedc0f4572b);
		}
	}
}
