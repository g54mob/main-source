using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _42ecfda1fe762ea429ca7f033594798a_bb3e0a4bd0924272888130f8a2ce601b : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _42ecfda1fe762ea429ca7f033594798a_bb3e0a4bd0924272888130f8a2ce601b FromInterop(IntPtr data, int dataSize)
		{
			return default(_42ecfda1fe762ea429ca7f033594798a_bb3e0a4bd0924272888130f8a2ce601b);
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

		public static void Serialize(_42ecfda1fe762ea429ca7f033594798a_bb3e0a4bd0924272888130f8a2ce601b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _42ecfda1fe762ea429ca7f033594798a_bb3e0a4bd0924272888130f8a2ce601b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_42ecfda1fe762ea429ca7f033594798a_bb3e0a4bd0924272888130f8a2ce601b);
		}
	}
}
