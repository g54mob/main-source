using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _74e5cc846f3f0c541bf20a1120752388_0a1a5af1057146d19f22e630c9bcc245 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _74e5cc846f3f0c541bf20a1120752388_0a1a5af1057146d19f22e630c9bcc245 FromInterop(IntPtr data, int dataSize)
		{
			return default(_74e5cc846f3f0c541bf20a1120752388_0a1a5af1057146d19f22e630c9bcc245);
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

		public static void Serialize(_74e5cc846f3f0c541bf20a1120752388_0a1a5af1057146d19f22e630c9bcc245 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _74e5cc846f3f0c541bf20a1120752388_0a1a5af1057146d19f22e630c9bcc245 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_74e5cc846f3f0c541bf20a1120752388_0a1a5af1057146d19f22e630c9bcc245);
		}
	}
}
