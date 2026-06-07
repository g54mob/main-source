using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a3be66cd680a8814d85b2135a540fcaa_52bf6be43dc04d3ba097179910a950c4 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _a3be66cd680a8814d85b2135a540fcaa_52bf6be43dc04d3ba097179910a950c4 FromInterop(IntPtr data, int dataSize)
		{
			return default(_a3be66cd680a8814d85b2135a540fcaa_52bf6be43dc04d3ba097179910a950c4);
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

		public _a3be66cd680a8814d85b2135a540fcaa_52bf6be43dc04d3ba097179910a950c4(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_a3be66cd680a8814d85b2135a540fcaa_52bf6be43dc04d3ba097179910a950c4 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a3be66cd680a8814d85b2135a540fcaa_52bf6be43dc04d3ba097179910a950c4 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a3be66cd680a8814d85b2135a540fcaa_52bf6be43dc04d3ba097179910a950c4);
		}
	}
}
