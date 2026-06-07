using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _183315916130b8948be02b0eecfa8bd7_7de7004da1a640be9b6c1f62495b45aa : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _183315916130b8948be02b0eecfa8bd7_7de7004da1a640be9b6c1f62495b45aa FromInterop(IntPtr data, int dataSize)
		{
			return default(_183315916130b8948be02b0eecfa8bd7_7de7004da1a640be9b6c1f62495b45aa);
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

		public _183315916130b8948be02b0eecfa8bd7_7de7004da1a640be9b6c1f62495b45aa(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_183315916130b8948be02b0eecfa8bd7_7de7004da1a640be9b6c1f62495b45aa commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _183315916130b8948be02b0eecfa8bd7_7de7004da1a640be9b6c1f62495b45aa Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_183315916130b8948be02b0eecfa8bd7_7de7004da1a640be9b6c1f62495b45aa);
		}
	}
}
