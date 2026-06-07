using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _428511d43dcea284a88597578067b45b_2da94a7f4d2a4142a064a7a6b5618d3e : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _428511d43dcea284a88597578067b45b_2da94a7f4d2a4142a064a7a6b5618d3e FromInterop(IntPtr data, int dataSize)
		{
			return default(_428511d43dcea284a88597578067b45b_2da94a7f4d2a4142a064a7a6b5618d3e);
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

		public _428511d43dcea284a88597578067b45b_2da94a7f4d2a4142a064a7a6b5618d3e(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_428511d43dcea284a88597578067b45b_2da94a7f4d2a4142a064a7a6b5618d3e commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _428511d43dcea284a88597578067b45b_2da94a7f4d2a4142a064a7a6b5618d3e Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_428511d43dcea284a88597578067b45b_2da94a7f4d2a4142a064a7a6b5618d3e);
		}
	}
}
