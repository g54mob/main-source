using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _ce0df8e5912f90943882b6184d83ea28_04453ce5be3240dda34052b14e09824a : IEntityCommand, IEntityMessage, IBaseRequest
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

		public static _ce0df8e5912f90943882b6184d83ea28_04453ce5be3240dda34052b14e09824a FromInterop(IntPtr data, int dataSize)
		{
			return default(_ce0df8e5912f90943882b6184d83ea28_04453ce5be3240dda34052b14e09824a);
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

		public _ce0df8e5912f90943882b6184d83ea28_04453ce5be3240dda34052b14e09824a(Entity entity, long startingClientFrame)
		{
			this.startingClientFrame = 0L;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_ce0df8e5912f90943882b6184d83ea28_04453ce5be3240dda34052b14e09824a commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _ce0df8e5912f90943882b6184d83ea28_04453ce5be3240dda34052b14e09824a Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_ce0df8e5912f90943882b6184d83ea28_04453ce5be3240dda34052b14e09824a);
		}
	}
}
