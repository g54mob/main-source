using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _020faf22b8e701447823f5b4d632326c_975e0302792f42c3b940f65c2c4fe11a : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _020faf22b8e701447823f5b4d632326c_975e0302792f42c3b940f65c2c4fe11a FromInterop(IntPtr data, int dataSize)
		{
			return default(_020faf22b8e701447823f5b4d632326c_975e0302792f42c3b940f65c2c4fe11a);
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

		public _020faf22b8e701447823f5b4d632326c_975e0302792f42c3b940f65c2c4fe11a(Entity entity, bool skipTriggers)
		{
			this.skipTriggers = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_020faf22b8e701447823f5b4d632326c_975e0302792f42c3b940f65c2c4fe11a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _020faf22b8e701447823f5b4d632326c_975e0302792f42c3b940f65c2c4fe11a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_020faf22b8e701447823f5b4d632326c_975e0302792f42c3b940f65c2c4fe11a);
		}
	}
}
