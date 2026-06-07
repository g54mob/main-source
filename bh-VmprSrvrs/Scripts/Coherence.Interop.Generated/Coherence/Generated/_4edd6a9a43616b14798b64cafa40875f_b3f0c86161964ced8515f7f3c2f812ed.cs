using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _4edd6a9a43616b14798b64cafa40875f_b3f0c86161964ced8515f7f3c2f812ed : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _4edd6a9a43616b14798b64cafa40875f_b3f0c86161964ced8515f7f3c2f812ed FromInterop(IntPtr data, int dataSize)
		{
			return default(_4edd6a9a43616b14798b64cafa40875f_b3f0c86161964ced8515f7f3c2f812ed);
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

		public static void Serialize(_4edd6a9a43616b14798b64cafa40875f_b3f0c86161964ced8515f7f3c2f812ed commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _4edd6a9a43616b14798b64cafa40875f_b3f0c86161964ced8515f7f3c2f812ed Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_4edd6a9a43616b14798b64cafa40875f_b3f0c86161964ced8515f7f3c2f812ed);
		}
	}
}
