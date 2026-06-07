using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _7da04e07cab36834bb9c2cbe01890c4e_9b2e4f4e4884415ba1ee054d5d3c560b : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _7da04e07cab36834bb9c2cbe01890c4e_9b2e4f4e4884415ba1ee054d5d3c560b FromInterop(IntPtr data, int dataSize)
		{
			return default(_7da04e07cab36834bb9c2cbe01890c4e_9b2e4f4e4884415ba1ee054d5d3c560b);
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

		public static void Serialize(_7da04e07cab36834bb9c2cbe01890c4e_9b2e4f4e4884415ba1ee054d5d3c560b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _7da04e07cab36834bb9c2cbe01890c4e_9b2e4f4e4884415ba1ee054d5d3c560b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_7da04e07cab36834bb9c2cbe01890c4e_9b2e4f4e4884415ba1ee054d5d3c560b);
		}
	}
}
