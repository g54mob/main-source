using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _66c7ea260d90fcb4e9fef1c5cc7f6533_20ed55436c394e8993538c1b6f0c32e4 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _66c7ea260d90fcb4e9fef1c5cc7f6533_20ed55436c394e8993538c1b6f0c32e4 FromInterop(IntPtr data, int dataSize)
		{
			return default(_66c7ea260d90fcb4e9fef1c5cc7f6533_20ed55436c394e8993538c1b6f0c32e4);
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

		public _66c7ea260d90fcb4e9fef1c5cc7f6533_20ed55436c394e8993538c1b6f0c32e4(Entity entity, Entity requestingPlayer)
		{
			this.requestingPlayer = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_66c7ea260d90fcb4e9fef1c5cc7f6533_20ed55436c394e8993538c1b6f0c32e4 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _66c7ea260d90fcb4e9fef1c5cc7f6533_20ed55436c394e8993538c1b6f0c32e4 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_66c7ea260d90fcb4e9fef1c5cc7f6533_20ed55436c394e8993538c1b6f0c32e4);
		}
	}
}
