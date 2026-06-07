using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _caa33b0f80bb9184397c5ef77b881389_46c6a8254e09468985c6c613b50a4b14 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _caa33b0f80bb9184397c5ef77b881389_46c6a8254e09468985c6c613b50a4b14 FromInterop(IntPtr data, int dataSize)
		{
			return default(_caa33b0f80bb9184397c5ef77b881389_46c6a8254e09468985c6c613b50a4b14);
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

		public static void Serialize(_caa33b0f80bb9184397c5ef77b881389_46c6a8254e09468985c6c613b50a4b14 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _caa33b0f80bb9184397c5ef77b881389_46c6a8254e09468985c6c613b50a4b14 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_caa33b0f80bb9184397c5ef77b881389_46c6a8254e09468985c6c613b50a4b14);
		}
	}
}
