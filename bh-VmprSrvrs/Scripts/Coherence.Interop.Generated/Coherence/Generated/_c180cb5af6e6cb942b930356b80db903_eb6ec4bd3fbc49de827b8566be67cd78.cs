using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _c180cb5af6e6cb942b930356b80db903_eb6ec4bd3fbc49de827b8566be67cd78 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _c180cb5af6e6cb942b930356b80db903_eb6ec4bd3fbc49de827b8566be67cd78 FromInterop(IntPtr data, int dataSize)
		{
			return default(_c180cb5af6e6cb942b930356b80db903_eb6ec4bd3fbc49de827b8566be67cd78);
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

		public _c180cb5af6e6cb942b930356b80db903_eb6ec4bd3fbc49de827b8566be67cd78(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_c180cb5af6e6cb942b930356b80db903_eb6ec4bd3fbc49de827b8566be67cd78 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _c180cb5af6e6cb942b930356b80db903_eb6ec4bd3fbc49de827b8566be67cd78 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_c180cb5af6e6cb942b930356b80db903_eb6ec4bd3fbc49de827b8566be67cd78);
		}
	}
}
