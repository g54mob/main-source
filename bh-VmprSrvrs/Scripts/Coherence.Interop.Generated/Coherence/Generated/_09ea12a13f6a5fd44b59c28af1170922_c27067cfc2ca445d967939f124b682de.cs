using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _09ea12a13f6a5fd44b59c28af1170922_c27067cfc2ca445d967939f124b682de : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _09ea12a13f6a5fd44b59c28af1170922_c27067cfc2ca445d967939f124b682de FromInterop(IntPtr data, int dataSize)
		{
			return default(_09ea12a13f6a5fd44b59c28af1170922_c27067cfc2ca445d967939f124b682de);
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

		public _09ea12a13f6a5fd44b59c28af1170922_c27067cfc2ca445d967939f124b682de(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_09ea12a13f6a5fd44b59c28af1170922_c27067cfc2ca445d967939f124b682de commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _09ea12a13f6a5fd44b59c28af1170922_c27067cfc2ca445d967939f124b682de Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_09ea12a13f6a5fd44b59c28af1170922_c27067cfc2ca445d967939f124b682de);
		}
	}
}
