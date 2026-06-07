using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _9554c42f3c82c79478c055749f76ba4c_6c190c395d524de69353a57c273af276 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _9554c42f3c82c79478c055749f76ba4c_6c190c395d524de69353a57c273af276 FromInterop(IntPtr data, int dataSize)
		{
			return default(_9554c42f3c82c79478c055749f76ba4c_6c190c395d524de69353a57c273af276);
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

		public _9554c42f3c82c79478c055749f76ba4c_6c190c395d524de69353a57c273af276(Entity entity, Entity requestingPlayer)
		{
			this.requestingPlayer = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_9554c42f3c82c79478c055749f76ba4c_6c190c395d524de69353a57c273af276 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _9554c42f3c82c79478c055749f76ba4c_6c190c395d524de69353a57c273af276 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_9554c42f3c82c79478c055749f76ba4c_6c190c395d524de69353a57c273af276);
		}
	}
}
