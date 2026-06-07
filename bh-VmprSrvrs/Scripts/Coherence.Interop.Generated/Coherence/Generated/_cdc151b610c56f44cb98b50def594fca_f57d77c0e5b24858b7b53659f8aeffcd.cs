using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _cdc151b610c56f44cb98b50def594fca_f57d77c0e5b24858b7b53659f8aeffcd : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public byte skipTriggers;
		}

		public bool skipTriggers;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _cdc151b610c56f44cb98b50def594fca_f57d77c0e5b24858b7b53659f8aeffcd FromInterop(IntPtr data, int dataSize)
		{
			return default(_cdc151b610c56f44cb98b50def594fca_f57d77c0e5b24858b7b53659f8aeffcd);
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

		public _cdc151b610c56f44cb98b50def594fca_f57d77c0e5b24858b7b53659f8aeffcd(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_cdc151b610c56f44cb98b50def594fca_f57d77c0e5b24858b7b53659f8aeffcd commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _cdc151b610c56f44cb98b50def594fca_f57d77c0e5b24858b7b53659f8aeffcd Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_cdc151b610c56f44cb98b50def594fca_f57d77c0e5b24858b7b53659f8aeffcd);
		}
	}
}
