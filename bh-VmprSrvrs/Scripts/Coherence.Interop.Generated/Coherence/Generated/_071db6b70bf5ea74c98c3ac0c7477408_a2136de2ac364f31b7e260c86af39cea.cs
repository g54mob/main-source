using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _071db6b70bf5ea74c98c3ac0c7477408_a2136de2ac364f31b7e260c86af39cea : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public byte skipTriggers;
		}

		public bool skipTriggers;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _071db6b70bf5ea74c98c3ac0c7477408_a2136de2ac364f31b7e260c86af39cea FromInterop(IntPtr data, int dataSize)
		{
			return default(_071db6b70bf5ea74c98c3ac0c7477408_a2136de2ac364f31b7e260c86af39cea);
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

		public _071db6b70bf5ea74c98c3ac0c7477408_a2136de2ac364f31b7e260c86af39cea(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_071db6b70bf5ea74c98c3ac0c7477408_a2136de2ac364f31b7e260c86af39cea commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _071db6b70bf5ea74c98c3ac0c7477408_a2136de2ac364f31b7e260c86af39cea Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_071db6b70bf5ea74c98c3ac0c7477408_a2136de2ac364f31b7e260c86af39cea);
		}
	}
}
