using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _0d7141adc7d8713458495f6487ff57b1_d45608f42ad54b299d2af7ae13b71145 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public float damageAmount;
		}

		public float damageAmount;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _0d7141adc7d8713458495f6487ff57b1_d45608f42ad54b299d2af7ae13b71145 FromInterop(IntPtr data, int dataSize)
		{
			return default(_0d7141adc7d8713458495f6487ff57b1_d45608f42ad54b299d2af7ae13b71145);
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

		public _0d7141adc7d8713458495f6487ff57b1_d45608f42ad54b299d2af7ae13b71145(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_0d7141adc7d8713458495f6487ff57b1_d45608f42ad54b299d2af7ae13b71145 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _0d7141adc7d8713458495f6487ff57b1_d45608f42ad54b299d2af7ae13b71145 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_0d7141adc7d8713458495f6487ff57b1_d45608f42ad54b299d2af7ae13b71145);
		}
	}
}
