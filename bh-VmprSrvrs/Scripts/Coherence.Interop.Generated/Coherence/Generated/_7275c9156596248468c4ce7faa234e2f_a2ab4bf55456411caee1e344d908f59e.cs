using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _7275c9156596248468c4ce7faa234e2f_a2ab4bf55456411caee1e344d908f59e : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _7275c9156596248468c4ce7faa234e2f_a2ab4bf55456411caee1e344d908f59e FromInterop(IntPtr data, int dataSize)
		{
			return default(_7275c9156596248468c4ce7faa234e2f_a2ab4bf55456411caee1e344d908f59e);
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

		public static void Serialize(_7275c9156596248468c4ce7faa234e2f_a2ab4bf55456411caee1e344d908f59e commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _7275c9156596248468c4ce7faa234e2f_a2ab4bf55456411caee1e344d908f59e Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_7275c9156596248468c4ce7faa234e2f_a2ab4bf55456411caee1e344d908f59e);
		}
	}
}
