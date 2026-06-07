using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _caa33b0f80bb9184397c5ef77b881389_b24d42eba6d24cfaafa8bee47c0884fe : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _caa33b0f80bb9184397c5ef77b881389_b24d42eba6d24cfaafa8bee47c0884fe FromInterop(IntPtr data, int dataSize)
		{
			return default(_caa33b0f80bb9184397c5ef77b881389_b24d42eba6d24cfaafa8bee47c0884fe);
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

		public _caa33b0f80bb9184397c5ef77b881389_b24d42eba6d24cfaafa8bee47c0884fe(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_caa33b0f80bb9184397c5ef77b881389_b24d42eba6d24cfaafa8bee47c0884fe commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _caa33b0f80bb9184397c5ef77b881389_b24d42eba6d24cfaafa8bee47c0884fe Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_caa33b0f80bb9184397c5ef77b881389_b24d42eba6d24cfaafa8bee47c0884fe);
		}
	}
}
