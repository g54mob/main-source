using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a46bf8b4e8e1b0842a181ef94e3818b9_74db9c989b6747e78bf7a4048959ee19 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _a46bf8b4e8e1b0842a181ef94e3818b9_74db9c989b6747e78bf7a4048959ee19 FromInterop(IntPtr data, int dataSize)
		{
			return default(_a46bf8b4e8e1b0842a181ef94e3818b9_74db9c989b6747e78bf7a4048959ee19);
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

		public _a46bf8b4e8e1b0842a181ef94e3818b9_74db9c989b6747e78bf7a4048959ee19(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_a46bf8b4e8e1b0842a181ef94e3818b9_74db9c989b6747e78bf7a4048959ee19 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a46bf8b4e8e1b0842a181ef94e3818b9_74db9c989b6747e78bf7a4048959ee19 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a46bf8b4e8e1b0842a181ef94e3818b9_74db9c989b6747e78bf7a4048959ee19);
		}
	}
}
