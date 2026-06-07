using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _728cd6037975de34a9c410d6903798fd_1262688c42a740b6a766e341833de579 : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _728cd6037975de34a9c410d6903798fd_1262688c42a740b6a766e341833de579 FromInterop(IntPtr data, int dataSize)
		{
			return default(_728cd6037975de34a9c410d6903798fd_1262688c42a740b6a766e341833de579);
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

		public _728cd6037975de34a9c410d6903798fd_1262688c42a740b6a766e341833de579(Entity entity, long startingSimFrame, bool instantRevival)
		{
			this.startingSimFrame = 0L;
			this.instantRevival = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_728cd6037975de34a9c410d6903798fd_1262688c42a740b6a766e341833de579 commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _728cd6037975de34a9c410d6903798fd_1262688c42a740b6a766e341833de579 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_728cd6037975de34a9c410d6903798fd_1262688c42a740b6a766e341833de579);
		}
	}
}
