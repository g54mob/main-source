using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _05f0f0d4f11de094bbb7f644d0aa80ab_151cb13ae8a84d52af669c50d90d07ee : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _05f0f0d4f11de094bbb7f644d0aa80ab_151cb13ae8a84d52af669c50d90d07ee FromInterop(IntPtr data, int dataSize)
		{
			return default(_05f0f0d4f11de094bbb7f644d0aa80ab_151cb13ae8a84d52af669c50d90d07ee);
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

		public _05f0f0d4f11de094bbb7f644d0aa80ab_151cb13ae8a84d52af669c50d90d07ee(Entity entity, uint clientId)
		{
			this.clientId = 0u;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_05f0f0d4f11de094bbb7f644d0aa80ab_151cb13ae8a84d52af669c50d90d07ee commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _05f0f0d4f11de094bbb7f644d0aa80ab_151cb13ae8a84d52af669c50d90d07ee Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_05f0f0d4f11de094bbb7f644d0aa80ab_151cb13ae8a84d52af669c50d90d07ee);
		}
	}
}
