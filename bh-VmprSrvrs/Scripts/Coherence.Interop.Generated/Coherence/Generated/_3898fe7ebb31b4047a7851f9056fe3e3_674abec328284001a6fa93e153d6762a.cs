using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _3898fe7ebb31b4047a7851f9056fe3e3_674abec328284001a6fa93e153d6762a : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _3898fe7ebb31b4047a7851f9056fe3e3_674abec328284001a6fa93e153d6762a FromInterop(IntPtr data, int dataSize)
		{
			return default(_3898fe7ebb31b4047a7851f9056fe3e3_674abec328284001a6fa93e153d6762a);
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

		public _3898fe7ebb31b4047a7851f9056fe3e3_674abec328284001a6fa93e153d6762a(Entity entity, long startingSimFrame, bool instantRevival)
		{
			this.startingSimFrame = 0L;
			this.instantRevival = false;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_3898fe7ebb31b4047a7851f9056fe3e3_674abec328284001a6fa93e153d6762a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _3898fe7ebb31b4047a7851f9056fe3e3_674abec328284001a6fa93e153d6762a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_3898fe7ebb31b4047a7851f9056fe3e3_674abec328284001a6fa93e153d6762a);
		}
	}
}
