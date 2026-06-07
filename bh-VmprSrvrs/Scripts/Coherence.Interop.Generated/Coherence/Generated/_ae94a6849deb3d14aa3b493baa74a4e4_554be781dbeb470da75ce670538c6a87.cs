using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ae94a6849deb3d14aa3b493baa74a4e4_554be781dbeb470da75ce670538c6a87 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _ae94a6849deb3d14aa3b493baa74a4e4_554be781dbeb470da75ce670538c6a87 FromInterop(IntPtr data, int dataSize)
		{
			return default(_ae94a6849deb3d14aa3b493baa74a4e4_554be781dbeb470da75ce670538c6a87);
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

		public static void Serialize(_ae94a6849deb3d14aa3b493baa74a4e4_554be781dbeb470da75ce670538c6a87 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ae94a6849deb3d14aa3b493baa74a4e4_554be781dbeb470da75ce670538c6a87 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ae94a6849deb3d14aa3b493baa74a4e4_554be781dbeb470da75ce670538c6a87);
		}
	}
}
