using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _9554c42f3c82c79478c055749f76ba4c_76432ba32e6e4e36982c0d3e4f2e9a4e : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _9554c42f3c82c79478c055749f76ba4c_76432ba32e6e4e36982c0d3e4f2e9a4e FromInterop(IntPtr data, int dataSize)
		{
			return default(_9554c42f3c82c79478c055749f76ba4c_76432ba32e6e4e36982c0d3e4f2e9a4e);
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

		public static void Serialize(_9554c42f3c82c79478c055749f76ba4c_76432ba32e6e4e36982c0d3e4f2e9a4e commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _9554c42f3c82c79478c055749f76ba4c_76432ba32e6e4e36982c0d3e4f2e9a4e Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_9554c42f3c82c79478c055749f76ba4c_76432ba32e6e4e36982c0d3e4f2e9a4e);
		}
	}
}
