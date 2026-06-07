using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _3bf6e50b07f36de4eb0862c8139e9ab8_578364e1968d49b394b7e8860b6d2382 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _3bf6e50b07f36de4eb0862c8139e9ab8_578364e1968d49b394b7e8860b6d2382 FromInterop(IntPtr data, int dataSize)
		{
			return default(_3bf6e50b07f36de4eb0862c8139e9ab8_578364e1968d49b394b7e8860b6d2382);
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

		public static void Serialize(_3bf6e50b07f36de4eb0862c8139e9ab8_578364e1968d49b394b7e8860b6d2382 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _3bf6e50b07f36de4eb0862c8139e9ab8_578364e1968d49b394b7e8860b6d2382 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_3bf6e50b07f36de4eb0862c8139e9ab8_578364e1968d49b394b7e8860b6d2382);
		}
	}
}
