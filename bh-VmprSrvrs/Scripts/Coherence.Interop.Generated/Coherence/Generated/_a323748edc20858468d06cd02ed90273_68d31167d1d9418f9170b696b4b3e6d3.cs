using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _a323748edc20858468d06cd02ed90273_68d31167d1d9418f9170b696b4b3e6d3 : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long startingSimFrame;

			[FieldOffset(8)]
			public byte instantRevival;
		}

		public long startingSimFrame;

		public bool instantRevival;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _a323748edc20858468d06cd02ed90273_68d31167d1d9418f9170b696b4b3e6d3 FromInterop(IntPtr data, int dataSize)
		{
			return default(_a323748edc20858468d06cd02ed90273_68d31167d1d9418f9170b696b4b3e6d3);
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

		public _a323748edc20858468d06cd02ed90273_68d31167d1d9418f9170b696b4b3e6d3(Entity entity, long startingSimFrame, bool instantRevival)
		{
			this.startingSimFrame = 0L;
			this.instantRevival = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_a323748edc20858468d06cd02ed90273_68d31167d1d9418f9170b696b4b3e6d3 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _a323748edc20858468d06cd02ed90273_68d31167d1d9418f9170b696b4b3e6d3 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_a323748edc20858468d06cd02ed90273_68d31167d1d9418f9170b696b4b3e6d3);
		}
	}
}
