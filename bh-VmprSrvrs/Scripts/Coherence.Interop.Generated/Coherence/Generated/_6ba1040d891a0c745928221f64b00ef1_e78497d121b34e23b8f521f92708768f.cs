using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _6ba1040d891a0c745928221f64b00ef1_e78497d121b34e23b8f521f92708768f : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingClientFrame;
		}

		public long startingClientFrame;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _6ba1040d891a0c745928221f64b00ef1_e78497d121b34e23b8f521f92708768f FromInterop(IntPtr data, int dataSize)
		{
			return default(_6ba1040d891a0c745928221f64b00ef1_e78497d121b34e23b8f521f92708768f);
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

		public _6ba1040d891a0c745928221f64b00ef1_e78497d121b34e23b8f521f92708768f(Entity entity, long startingClientFrame)
		{
			this.startingClientFrame = 0L;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_6ba1040d891a0c745928221f64b00ef1_e78497d121b34e23b8f521f92708768f commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _6ba1040d891a0c745928221f64b00ef1_e78497d121b34e23b8f521f92708768f Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_6ba1040d891a0c745928221f64b00ef1_e78497d121b34e23b8f521f92708768f);
		}
	}
}
