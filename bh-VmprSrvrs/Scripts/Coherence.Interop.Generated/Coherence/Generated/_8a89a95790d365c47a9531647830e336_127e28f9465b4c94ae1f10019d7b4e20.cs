using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _8a89a95790d365c47a9531647830e336_127e28f9465b4c94ae1f10019d7b4e20 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _8a89a95790d365c47a9531647830e336_127e28f9465b4c94ae1f10019d7b4e20 FromInterop(IntPtr data, int dataSize)
		{
			return default(_8a89a95790d365c47a9531647830e336_127e28f9465b4c94ae1f10019d7b4e20);
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

		public _8a89a95790d365c47a9531647830e336_127e28f9465b4c94ae1f10019d7b4e20(Entity entity, Entity requestingPlayer)
		{
			this.requestingPlayer = default(Entity);
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_8a89a95790d365c47a9531647830e336_127e28f9465b4c94ae1f10019d7b4e20 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _8a89a95790d365c47a9531647830e336_127e28f9465b4c94ae1f10019d7b4e20 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_8a89a95790d365c47a9531647830e336_127e28f9465b4c94ae1f10019d7b4e20);
		}
	}
}
