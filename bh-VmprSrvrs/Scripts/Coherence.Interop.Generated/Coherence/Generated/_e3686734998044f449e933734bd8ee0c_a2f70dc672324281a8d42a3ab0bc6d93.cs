using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _e3686734998044f449e933734bd8ee0c_a2f70dc672324281a8d42a3ab0bc6d93 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _e3686734998044f449e933734bd8ee0c_a2f70dc672324281a8d42a3ab0bc6d93 FromInterop(IntPtr data, int dataSize)
		{
			return default(_e3686734998044f449e933734bd8ee0c_a2f70dc672324281a8d42a3ab0bc6d93);
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

		public static void Serialize(_e3686734998044f449e933734bd8ee0c_a2f70dc672324281a8d42a3ab0bc6d93 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _e3686734998044f449e933734bd8ee0c_a2f70dc672324281a8d42a3ab0bc6d93 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_e3686734998044f449e933734bd8ee0c_a2f70dc672324281a8d42a3ab0bc6d93);
		}
	}
}
