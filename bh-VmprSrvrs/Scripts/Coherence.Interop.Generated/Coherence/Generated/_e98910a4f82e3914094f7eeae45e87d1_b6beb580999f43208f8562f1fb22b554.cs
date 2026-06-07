using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _e98910a4f82e3914094f7eeae45e87d1_b6beb580999f43208f8562f1fb22b554 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _e98910a4f82e3914094f7eeae45e87d1_b6beb580999f43208f8562f1fb22b554 FromInterop(IntPtr data, int dataSize)
		{
			return default(_e98910a4f82e3914094f7eeae45e87d1_b6beb580999f43208f8562f1fb22b554);
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

		public static void Serialize(_e98910a4f82e3914094f7eeae45e87d1_b6beb580999f43208f8562f1fb22b554 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _e98910a4f82e3914094f7eeae45e87d1_b6beb580999f43208f8562f1fb22b554 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_e98910a4f82e3914094f7eeae45e87d1_b6beb580999f43208f8562f1fb22b554);
		}
	}
}
