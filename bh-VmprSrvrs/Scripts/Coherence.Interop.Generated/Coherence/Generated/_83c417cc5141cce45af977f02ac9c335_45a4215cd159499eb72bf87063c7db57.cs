using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _83c417cc5141cce45af977f02ac9c335_45a4215cd159499eb72bf87063c7db57 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public Entity requestingPlayer;
		}

		public Entity requestingPlayer;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _83c417cc5141cce45af977f02ac9c335_45a4215cd159499eb72bf87063c7db57 FromInterop(IntPtr data, int dataSize)
		{
			return default(_83c417cc5141cce45af977f02ac9c335_45a4215cd159499eb72bf87063c7db57);
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

		public _83c417cc5141cce45af977f02ac9c335_45a4215cd159499eb72bf87063c7db57(Entity entity, Entity requestingPlayer)
		{
			this.requestingPlayer = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_83c417cc5141cce45af977f02ac9c335_45a4215cd159499eb72bf87063c7db57 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _83c417cc5141cce45af977f02ac9c335_45a4215cd159499eb72bf87063c7db57 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_83c417cc5141cce45af977f02ac9c335_45a4215cd159499eb72bf87063c7db57);
		}
	}
}
