using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _0d7141adc7d8713458495f6487ff57b1_1fcc27874a8c4ce09a4414bf67fad1cb : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
		}

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _0d7141adc7d8713458495f6487ff57b1_1fcc27874a8c4ce09a4414bf67fad1cb FromInterop(IntPtr data, int dataSize)
		{
			return default(_0d7141adc7d8713458495f6487ff57b1_1fcc27874a8c4ce09a4414bf67fad1cb);
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

		public static void Serialize(_0d7141adc7d8713458495f6487ff57b1_1fcc27874a8c4ce09a4414bf67fad1cb commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _0d7141adc7d8713458495f6487ff57b1_1fcc27874a8c4ce09a4414bf67fad1cb Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_0d7141adc7d8713458495f6487ff57b1_1fcc27874a8c4ce09a4414bf67fad1cb);
		}
	}
}
