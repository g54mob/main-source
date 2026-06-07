using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _03c1f4b7bee855a40bc8b8c91cc978b6_152886b542bc4e83966b7dd44c229c2c : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _03c1f4b7bee855a40bc8b8c91cc978b6_152886b542bc4e83966b7dd44c229c2c FromInterop(IntPtr data, int dataSize)
		{
			return default(_03c1f4b7bee855a40bc8b8c91cc978b6_152886b542bc4e83966b7dd44c229c2c);
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

		public _03c1f4b7bee855a40bc8b8c91cc978b6_152886b542bc4e83966b7dd44c229c2c(Entity entity, long startingSimFrame, Entity requestingPlayer)
		{
			this.startingSimFrame = 0L;
			this.requestingPlayer = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_03c1f4b7bee855a40bc8b8c91cc978b6_152886b542bc4e83966b7dd44c229c2c commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _03c1f4b7bee855a40bc8b8c91cc978b6_152886b542bc4e83966b7dd44c229c2c Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_03c1f4b7bee855a40bc8b8c91cc978b6_152886b542bc4e83966b7dd44c229c2c);
		}
	}
}
