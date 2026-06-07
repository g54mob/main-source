using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _83c417cc5141cce45af977f02ac9c335_7056110de0d444a2beca7ce9dc5b6b0b : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public Entity requestingPlayer;
		}

		public long startingSimFrame;

		public Entity requestingPlayer;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _83c417cc5141cce45af977f02ac9c335_7056110de0d444a2beca7ce9dc5b6b0b FromInterop(IntPtr data, int dataSize)
		{
			return default(_83c417cc5141cce45af977f02ac9c335_7056110de0d444a2beca7ce9dc5b6b0b);
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

		public _83c417cc5141cce45af977f02ac9c335_7056110de0d444a2beca7ce9dc5b6b0b(Entity entity, long startingSimFrame, Entity requestingPlayer)
		{
			this.startingSimFrame = 0L;
			this.requestingPlayer = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_83c417cc5141cce45af977f02ac9c335_7056110de0d444a2beca7ce9dc5b6b0b commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _83c417cc5141cce45af977f02ac9c335_7056110de0d444a2beca7ce9dc5b6b0b Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_83c417cc5141cce45af977f02ac9c335_7056110de0d444a2beca7ce9dc5b6b0b);
		}
	}
}
