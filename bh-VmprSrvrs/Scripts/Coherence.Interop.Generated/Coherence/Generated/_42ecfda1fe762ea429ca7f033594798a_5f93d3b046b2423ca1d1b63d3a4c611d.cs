using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _42ecfda1fe762ea429ca7f033594798a_5f93d3b046b2423ca1d1b63d3a4c611d : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public long frame;

			[FieldOffset(8)]
			public int weaponType;
		}

		public long frame;

		public int weaponType;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _42ecfda1fe762ea429ca7f033594798a_5f93d3b046b2423ca1d1b63d3a4c611d FromInterop(IntPtr data, int dataSize)
		{
			return default(_42ecfda1fe762ea429ca7f033594798a_5f93d3b046b2423ca1d1b63d3a4c611d);
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

		public _42ecfda1fe762ea429ca7f033594798a_5f93d3b046b2423ca1d1b63d3a4c611d(Entity entity, long frame, int weaponType)
		{
			this.frame = 0L;
			this.weaponType = 0;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_42ecfda1fe762ea429ca7f033594798a_5f93d3b046b2423ca1d1b63d3a4c611d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _42ecfda1fe762ea429ca7f033594798a_5f93d3b046b2423ca1d1b63d3a4c611d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_42ecfda1fe762ea429ca7f033594798a_5f93d3b046b2423ca1d1b63d3a4c611d);
		}
	}
}
