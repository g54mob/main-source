using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _88b68dbaed804624b8f27ed0be24b05d_effbc6bc1ef54df98e44cc3652031682 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _88b68dbaed804624b8f27ed0be24b05d_effbc6bc1ef54df98e44cc3652031682 FromInterop(IntPtr data, int dataSize)
		{
			return default(_88b68dbaed804624b8f27ed0be24b05d_effbc6bc1ef54df98e44cc3652031682);
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

		public static void Serialize(_88b68dbaed804624b8f27ed0be24b05d_effbc6bc1ef54df98e44cc3652031682 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _88b68dbaed804624b8f27ed0be24b05d_effbc6bc1ef54df98e44cc3652031682 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_88b68dbaed804624b8f27ed0be24b05d_effbc6bc1ef54df98e44cc3652031682);
		}
	}
}
