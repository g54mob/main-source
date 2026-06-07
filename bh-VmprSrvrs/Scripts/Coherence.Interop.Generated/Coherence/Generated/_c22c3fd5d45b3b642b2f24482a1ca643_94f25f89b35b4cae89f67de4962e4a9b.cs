using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _c22c3fd5d45b3b642b2f24482a1ca643_94f25f89b35b4cae89f67de4962e4a9b : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _c22c3fd5d45b3b642b2f24482a1ca643_94f25f89b35b4cae89f67de4962e4a9b FromInterop(IntPtr data, int dataSize)
		{
			return default(_c22c3fd5d45b3b642b2f24482a1ca643_94f25f89b35b4cae89f67de4962e4a9b);
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

		public static void Serialize(_c22c3fd5d45b3b642b2f24482a1ca643_94f25f89b35b4cae89f67de4962e4a9b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _c22c3fd5d45b3b642b2f24482a1ca643_94f25f89b35b4cae89f67de4962e4a9b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_c22c3fd5d45b3b642b2f24482a1ca643_94f25f89b35b4cae89f67de4962e4a9b);
		}
	}
}
