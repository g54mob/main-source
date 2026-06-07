using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _caa33b0f80bb9184397c5ef77b881389_3f9ce31d4e564714acd129f56ba45118 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _caa33b0f80bb9184397c5ef77b881389_3f9ce31d4e564714acd129f56ba45118 FromInterop(IntPtr data, int dataSize)
		{
			return default(_caa33b0f80bb9184397c5ef77b881389_3f9ce31d4e564714acd129f56ba45118);
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

		public static void Serialize(_caa33b0f80bb9184397c5ef77b881389_3f9ce31d4e564714acd129f56ba45118 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _caa33b0f80bb9184397c5ef77b881389_3f9ce31d4e564714acd129f56ba45118 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_caa33b0f80bb9184397c5ef77b881389_3f9ce31d4e564714acd129f56ba45118);
		}
	}
}
