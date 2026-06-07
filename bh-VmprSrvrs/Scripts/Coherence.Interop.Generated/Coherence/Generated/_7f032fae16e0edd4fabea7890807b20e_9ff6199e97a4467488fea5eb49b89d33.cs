using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _7f032fae16e0edd4fabea7890807b20e_9ff6199e97a4467488fea5eb49b89d33 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _7f032fae16e0edd4fabea7890807b20e_9ff6199e97a4467488fea5eb49b89d33 FromInterop(IntPtr data, int dataSize)
		{
			return default(_7f032fae16e0edd4fabea7890807b20e_9ff6199e97a4467488fea5eb49b89d33);
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

		public static void Serialize(_7f032fae16e0edd4fabea7890807b20e_9ff6199e97a4467488fea5eb49b89d33 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _7f032fae16e0edd4fabea7890807b20e_9ff6199e97a4467488fea5eb49b89d33 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_7f032fae16e0edd4fabea7890807b20e_9ff6199e97a4467488fea5eb49b89d33);
		}
	}
}
