using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _93ed3567057e7b84e9083504ebf79a8c_acbeab690f0643dfa7b558cecd8a4ede : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public float percentage;
		}

		public long startingSimFrame;

		public float percentage;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _93ed3567057e7b84e9083504ebf79a8c_acbeab690f0643dfa7b558cecd8a4ede FromInterop(IntPtr data, int dataSize)
		{
			return default(_93ed3567057e7b84e9083504ebf79a8c_acbeab690f0643dfa7b558cecd8a4ede);
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

		public _93ed3567057e7b84e9083504ebf79a8c_acbeab690f0643dfa7b558cecd8a4ede(Entity entity, long startingSimFrame, float percentage)
		{
			this.startingSimFrame = 0L;
			this.percentage = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_93ed3567057e7b84e9083504ebf79a8c_acbeab690f0643dfa7b558cecd8a4ede commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _93ed3567057e7b84e9083504ebf79a8c_acbeab690f0643dfa7b558cecd8a4ede Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_93ed3567057e7b84e9083504ebf79a8c_acbeab690f0643dfa7b558cecd8a4ede);
		}
	}
}
