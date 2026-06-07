using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _1ccf9b50cda6be6458909551c52517aa_b18aeef3e95748f8824baff12e77b2b6 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _1ccf9b50cda6be6458909551c52517aa_b18aeef3e95748f8824baff12e77b2b6 FromInterop(IntPtr data, int dataSize)
		{
			return default(_1ccf9b50cda6be6458909551c52517aa_b18aeef3e95748f8824baff12e77b2b6);
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

		public _1ccf9b50cda6be6458909551c52517aa_b18aeef3e95748f8824baff12e77b2b6(Entity entity, long startingClientFrame)
		{
			this.startingClientFrame = 0L;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_1ccf9b50cda6be6458909551c52517aa_b18aeef3e95748f8824baff12e77b2b6 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _1ccf9b50cda6be6458909551c52517aa_b18aeef3e95748f8824baff12e77b2b6 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_1ccf9b50cda6be6458909551c52517aa_b18aeef3e95748f8824baff12e77b2b6);
		}
	}
}
