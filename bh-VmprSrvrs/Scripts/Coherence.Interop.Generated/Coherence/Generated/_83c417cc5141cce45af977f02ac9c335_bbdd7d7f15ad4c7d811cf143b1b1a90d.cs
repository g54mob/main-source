using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _83c417cc5141cce45af977f02ac9c335_bbdd7d7f15ad4c7d811cf143b1b1a90d : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public uint clientId;
		}

		public uint clientId;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _83c417cc5141cce45af977f02ac9c335_bbdd7d7f15ad4c7d811cf143b1b1a90d FromInterop(IntPtr data, int dataSize)
		{
			return default(_83c417cc5141cce45af977f02ac9c335_bbdd7d7f15ad4c7d811cf143b1b1a90d);
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

		public _83c417cc5141cce45af977f02ac9c335_bbdd7d7f15ad4c7d811cf143b1b1a90d(Entity entity, uint clientId)
		{
			this.clientId = 0u;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_83c417cc5141cce45af977f02ac9c335_bbdd7d7f15ad4c7d811cf143b1b1a90d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _83c417cc5141cce45af977f02ac9c335_bbdd7d7f15ad4c7d811cf143b1b1a90d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_83c417cc5141cce45af977f02ac9c335_bbdd7d7f15ad4c7d811cf143b1b1a90d);
		}
	}
}
