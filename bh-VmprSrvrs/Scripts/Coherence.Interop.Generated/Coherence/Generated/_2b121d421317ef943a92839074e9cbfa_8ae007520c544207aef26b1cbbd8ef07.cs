using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _2b121d421317ef943a92839074e9cbfa_8ae007520c544207aef26b1cbbd8ef07 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _2b121d421317ef943a92839074e9cbfa_8ae007520c544207aef26b1cbbd8ef07 FromInterop(IntPtr data, int dataSize)
		{
			return default(_2b121d421317ef943a92839074e9cbfa_8ae007520c544207aef26b1cbbd8ef07);
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

		public _2b121d421317ef943a92839074e9cbfa_8ae007520c544207aef26b1cbbd8ef07(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_2b121d421317ef943a92839074e9cbfa_8ae007520c544207aef26b1cbbd8ef07 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _2b121d421317ef943a92839074e9cbfa_8ae007520c544207aef26b1cbbd8ef07 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_2b121d421317ef943a92839074e9cbfa_8ae007520c544207aef26b1cbbd8ef07);
		}
	}
}
