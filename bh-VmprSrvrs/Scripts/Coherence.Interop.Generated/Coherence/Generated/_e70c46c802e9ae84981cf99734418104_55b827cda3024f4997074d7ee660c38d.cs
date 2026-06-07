using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.Generated
{
	public struct _e70c46c802e9ae84981cf99734418104_55b827cda3024f4997074d7ee660c38d : IEntityCommand, IEntityMessage, IBaseRequest
	{
		[StructLayout((LayoutKind)2)]
		public struct Interop
		{
			[FieldOffset(0)]
			public float damageAmount;
		}

		public float damageAmount;

		public Entity Entity { get; set; }

		public ChannelID ChannelID { get; set; }

		public MessageTarget Routing { get; set; }

		public uint Sender { get; set; }

		public static _e70c46c802e9ae84981cf99734418104_55b827cda3024f4997074d7ee660c38d FromInterop(IntPtr data, int dataSize)
		{
			return default(_e70c46c802e9ae84981cf99734418104_55b827cda3024f4997074d7ee660c38d);
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

		public _e70c46c802e9ae84981cf99734418104_55b827cda3024f4997074d7ee660c38d(Entity entity, float damageAmount)
		{
			this.damageAmount = 0f;
			Entity = default(Entity);
			ChannelID = default(ChannelID);
			Routing = default(MessageTarget);
			Sender = 0u;
		}

		public static void Serialize(_e70c46c802e9ae84981cf99734418104_55b827cda3024f4997074d7ee660c38d commandData, IOutProtocolBitStream bitStream)
		{
		}

		public static _e70c46c802e9ae84981cf99734418104_55b827cda3024f4997074d7ee660c38d Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
		{
			return default(_e70c46c802e9ae84981cf99734418104_55b827cda3024f4997074d7ee660c38d);
		}
	}
}
