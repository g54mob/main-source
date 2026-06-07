using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _402d4b50cec4a664d887ebe993393dea_7566e2f20df54d76b10dfad45b9eea52 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _402d4b50cec4a664d887ebe993393dea_7566e2f20df54d76b10dfad45b9eea52 FromInterop(IntPtr data, int dataSize)
		{
			return default(_402d4b50cec4a664d887ebe993393dea_7566e2f20df54d76b10dfad45b9eea52);
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

		public _402d4b50cec4a664d887ebe993393dea_7566e2f20df54d76b10dfad45b9eea52(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_402d4b50cec4a664d887ebe993393dea_7566e2f20df54d76b10dfad45b9eea52 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _402d4b50cec4a664d887ebe993393dea_7566e2f20df54d76b10dfad45b9eea52 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_402d4b50cec4a664d887ebe993393dea_7566e2f20df54d76b10dfad45b9eea52);
		}
	}
}
