using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _8a89a95790d365c47a9531647830e336_ac9b8d4a584544c897d78e7204fbbdb3 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public uint clientId;
		}

		public uint clientId;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _8a89a95790d365c47a9531647830e336_ac9b8d4a584544c897d78e7204fbbdb3 FromInterop(IntPtr data, int dataSize)
		{
			return default(_8a89a95790d365c47a9531647830e336_ac9b8d4a584544c897d78e7204fbbdb3);
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

		public _8a89a95790d365c47a9531647830e336_ac9b8d4a584544c897d78e7204fbbdb3(Entity entity, uint clientId)
		{
			this.clientId = 0u;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_8a89a95790d365c47a9531647830e336_ac9b8d4a584544c897d78e7204fbbdb3 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _8a89a95790d365c47a9531647830e336_ac9b8d4a584544c897d78e7204fbbdb3 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_8a89a95790d365c47a9531647830e336_ac9b8d4a584544c897d78e7204fbbdb3);
		}
	}
}
