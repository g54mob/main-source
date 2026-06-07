using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _f11f3c87b586d4b4e867cd143a1d76e1_c8efba26bdd9422ba5ae6a7a40034c53 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _f11f3c87b586d4b4e867cd143a1d76e1_c8efba26bdd9422ba5ae6a7a40034c53 FromInterop(IntPtr data, int dataSize)
		{
			return default(_f11f3c87b586d4b4e867cd143a1d76e1_c8efba26bdd9422ba5ae6a7a40034c53);
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

		public static void Serialize(_f11f3c87b586d4b4e867cd143a1d76e1_c8efba26bdd9422ba5ae6a7a40034c53 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _f11f3c87b586d4b4e867cd143a1d76e1_c8efba26bdd9422ba5ae6a7a40034c53 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_f11f3c87b586d4b4e867cd143a1d76e1_c8efba26bdd9422ba5ae6a7a40034c53);
		}
	}
}
